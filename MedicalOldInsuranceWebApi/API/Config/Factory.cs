using Domain.Models.DTOs;
using InsuranceAPIs.WorkFlow;
using InsuranceAPIs.WorkFlow.Steps;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace API.Config
{
	public static class Factory
	{
		public static IServiceCollection AddWorkFlows(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddWorkflow();
			services.AddScoped<ClaimsBatchService>();
			return services;
		}

		public static IApplicationBuilder RegisterWorkFlows(this IApplicationBuilder app, IConfiguration configuration)
		{
			IWorkflowHost host = app.ApplicationServices.GetService<IWorkflowHost>();
			host.RegisterWorkflow<xProcessTimerWorkflow, APIsSchedulersConfig>();
			host.Start();
			host.StartWorkflow("xProcessTimerWorkflow", 1, new APIsSchedulersConfig
			{
				IsEnabled = configuration.GetValue<bool>("APIsSchedulersConfig:IsEnabled"),
				WorksEveryMnt = configuration.GetValue<int>("APIsSchedulersConfig:WorksEveryMnt")
			});
			return app;
		}
	}
}
