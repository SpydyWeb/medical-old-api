using CORE.Interfaces;
using Domain.Common;
using InsuranceAPIs.Models.ExternalAPIs;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace InsuranceAPIs.WorkFlow.Steps
{
	public class ClaimsBatchService : StepBody
	{
		private IMotorClaims _WSServiceUnitOfWork;

		public ClaimsBatchService(IMotorClaims WSServiceUnitOfWork)
		{
			_WSServiceUnitOfWork = WSServiceUnitOfWork;
		}

		public override ExecutionResult Run(IStepExecutionContext context)
		{
			if (!SharedSettings.aPIsSchedulersConfig.IsPolicyRunning)
			{
				SharedSettings.aPIsSchedulersConfig.IsPolicyRunning = true;
				SharedSettings.aPIsSchedulersConfig.IsPolicyRunning = !RegisterClaims.RegisterClaim(SharedSettings.aPIsSchedulersConfig.WebsiteConnection, _WSServiceUnitOfWork, SharedSettings.aPIsSchedulersConfig.NajmConnection, SharedSettings.aPIsSchedulersConfig.insuranceCompanyID);
			}
			return ExecutionResult.Next();
		}
	}
}
