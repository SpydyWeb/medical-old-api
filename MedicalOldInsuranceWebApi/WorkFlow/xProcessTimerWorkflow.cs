using System;
using Domain.Models.DTOs;
using InsuranceAPIs.WorkFlow.Steps;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace InsuranceAPIs.WorkFlow
{
	public class xProcessTimerWorkflow : IWorkflow<APIsSchedulersConfig>
	{
		public string Id => "xProcessTimerWorkflow";

		public int Version => 1;

		public void Build(IWorkflowBuilder<APIsSchedulersConfig> builder)
		{
			builder.StartWith(delegate
			{
				Console.WriteLine("CHECKING xProccess TIMER WORKFLOW");
				ExecutionResult.Next();
			}).If((APIsSchedulersConfig data) => data.IsEnabled && data.WorksEveryMnt > 0).Do(delegate(IWorkflowBuilder<APIsSchedulersConfig> then)
			{
				then.StartWith(delegate
				{
					Console.WriteLine("CHECKING xProccess TIMER STARTED ...");
					ExecutionResult.Next();
				}).While((APIsSchedulersConfig data) => true).Do(delegate(IWorkflowBuilder<APIsSchedulersConfig> context)
				{
					context.Parallel().Do(delegate(IWorkflowBuilder<APIsSchedulersConfig> then)
					{
						then.StartWith<ClaimsBatchService>().Schedule((APIsSchedulersConfig data) => TimeSpan.FromMinutes(data.WorksEveryMnt));
					}).Join();
				})
					.EndWorkflow();
			})
				.If((APIsSchedulersConfig data) => !data.IsEnabled || data.WorksEveryMnt <= 0)
				.Do(delegate(IWorkflowBuilder<APIsSchedulersConfig> then)
				{
					then.StartWith(delegate
					{
						Console.WriteLine("CHECKING CCHI TIMER WORKFLOW IS OFF (you need to check appsettings configration to turn it on ) ...");
						ExecutionResult.Next();
					}).EndWorkflow();
				});
		}
	}
}
