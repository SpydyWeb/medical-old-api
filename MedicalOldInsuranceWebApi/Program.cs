using System;
using System.Runtime.CompilerServices;
using API.Config;
using CORE.Interfaces;
using CORE.Services;
using DataAccessLayer;
using DataAccessLayer.Oracle.Eskadenia.Setups;
using Domain.Common;
using Domain.Context;
using Domain.Models.DTOs;
using Fluentx;
using InfraStructure.Services;
using InsuranceAPIs.Models;
using InsuranceAPIs.Models.Configuration_Objects;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Oracle.EntityFrameworkCore.Infrastructure;
using Service.Interfaces;
using Service.Services;
using Service.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddJsonOptions(delegate (JsonOptions options)
{
	options.JsonSerializerOptions.IgnoreNullValues = true;
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
IConfigurationSection appsetting = builder.Configuration.GetSection("AppSettings");
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IServiceUnitOfWork, ServiceUnitOfWork>();
builder.Services.AddScoped<IWSCoreUniteOfWork, WSCoreUniteOfWork>();
builder.Services.AddScoped<IWSServiceUnitOfWork, WSServiceUnitOfWork>();
builder.Services.AddHttpClient<ITPServiceUnitOfWork, TPServiceUnitOfWork>();
builder.Services.AddScoped<IWSCoreService, WSCoreImplementations>();
builder.Services.AddScoped<IMotorClaims, MotorClaim>();
builder.Services.AddTransient<IEwsService, EwsService>();
builder.Services.AddScoped<IFinance, Finance>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IWSServiceUnitOfWork, WSServiceUnitOfWork>();
ConfigurationManager configuration = builder.Configuration;
SharedSettings.aPIsSchedulersConfig = configuration.GetSection("APIsSchedulersConfig").Get<APIsSchedulersConfig>();
builder.Services.Configure<AppSettings>(appsetting);
AppSettings appSettings = appsetting.Get<AppSettings>();
string Connection = appSettings.Connection;
builder.Services.AddEntityFrameworkSqlServer().AddDbContextPool<DataBaseContext>(delegate (DbContextOptionsBuilder options)
{
	options.UseSqlServer(Connection);
});
builder.Services.AddDbContext<DataBaseContext>(options =>
	options.UseSqlServer(Connection));

builder.Services.AddDbContext<testDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<testDBContext>(options =>
    options.UseSqlServer(Connection));
builder.Services.AddDbContext<CchiDbContext>(delegate (DbContextOptionsBuilder options)
{
	options.UseOracle(SharedSettings.OracleConnectionString, delegate (OracleDbContextOptionsBuilder b)
	{
		b.UseOracleSQLCompatibility("11");
	}).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISvc, Svc>();
builder.Services.AddScoped<IUserManagment, UserMangement>();
builder.Services.AddScoped<ITracker, Tracker>();
builder.Services.AddScoped<IMapping, Mapping>();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IProcess, Process>();
builder.Services.AddMemoryCache();
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DataBaseContext>().AddDefaultTokenProviders();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddWorkFlows(configuration);
WebApplication app = builder.Build();
app.RegisterWorkFlows(configuration);
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
