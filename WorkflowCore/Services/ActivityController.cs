using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WorkflowCore.Exceptions;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowCore.Services
{
	public class ActivityController : IActivityController
	{
		private class Token
		{
			public string SubscriptionId { get; set; }

			public string ActivityName { get; set; }

			public string Nonce { get; set; }

			public string Encode()
			{
				string s = JsonConvert.SerializeObject(this);
				return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
			}

			public static Token Create(string subscriptionId, string activityName)
			{
				return new Token
				{
					SubscriptionId = subscriptionId,
					ActivityName = activityName,
					Nonce = Guid.NewGuid().ToString()
				};
			}

			public static Token Decode(string encodedToken)
			{
				byte[] bytes = Convert.FromBase64String(encodedToken);
				return JsonConvert.DeserializeObject<Token>(Encoding.UTF8.GetString(bytes));
			}
		}

		private readonly ISubscriptionRepository _subscriptionRepository;

		private readonly IDistributedLockProvider _lockProvider;

		private readonly IDateTimeProvider _dateTimeProvider;

		private readonly IWorkflowController _workflowController;

		public ActivityController(ISubscriptionRepository subscriptionRepository, IWorkflowController workflowController, IDateTimeProvider dateTimeProvider, IDistributedLockProvider lockProvider)
		{
			_subscriptionRepository = subscriptionRepository;
			_dateTimeProvider = dateTimeProvider;
			_lockProvider = lockProvider;
			_workflowController = workflowController;
		}

		public async Task<PendingActivity> GetPendingActivity(string activityName, string workerId, TimeSpan? timeout = null)
		{
			DateTime endTime = _dateTimeProvider.UtcNow.Add(timeout ?? TimeSpan.Zero);
			bool flag = true;
			EventSubscription subscription = null;
			while ((subscription == null && _dateTimeProvider.UtcNow < endTime) || flag)
			{
				if (!flag)
				{
					await Task.Delay(100);
				}
				subscription = await _subscriptionRepository.GetFirstOpenSubscription("WorkflowCore.Activity", activityName, _dateTimeProvider.Now);
				if (subscription != null && !(await _lockProvider.AcquireLock("sub:" + subscription.Id, CancellationToken.None)))
				{
					subscription = null;
				}
				flag = false;
			}
			if (subscription == null)
			{
				return null;
			}
			PendingActivity result2;
			try
			{
				Token token = Token.Create(subscription.Id, subscription.EventKey);
				PendingActivity result = new PendingActivity
				{
					Token = token.Encode(),
					ActivityName = subscription.EventKey,
					Parameters = subscription.SubscriptionData,
					TokenExpiry = DateTime.MaxValue
				};
				result2 = ((await _subscriptionRepository.SetSubscriptionToken(subscription.Id, result.Token, workerId, result.TokenExpiry)) ? result : null);
			}
			finally
			{
				await _lockProvider.ReleaseLock("sub:" + subscription.Id);
			}
			return result2;
		}

		public async Task ReleaseActivityToken(string token)
		{
			Token token2 = Token.Decode(token);
			await _subscriptionRepository.ClearSubscriptionToken(token2.SubscriptionId, token);
		}

		public async Task SubmitActivitySuccess(string token, object result)
		{
			await SubmitActivityResult(token, new ActivityResult
			{
				Data = result,
				Status = ActivityResult.StatusType.Success
			});
		}

		public async Task SubmitActivityFailure(string token, object result)
		{
			await SubmitActivityResult(token, new ActivityResult
			{
				Data = result,
				Status = ActivityResult.StatusType.Fail
			});
		}

		private async Task SubmitActivityResult(string token, ActivityResult result)
		{
			Token token2 = Token.Decode(token);
			EventSubscription eventSubscription = await _subscriptionRepository.GetSubscription(token2.SubscriptionId);
			if (eventSubscription == null)
			{
				throw new NotFoundException();
			}
			if (eventSubscription.ExternalToken != token)
			{
				throw new NotFoundException("Token mismatch");
			}
			result.SubscriptionId = eventSubscription.Id;
			await _workflowController.PublishEvent(eventSubscription.EventName, eventSubscription.EventKey, result);
		}
	}
}
