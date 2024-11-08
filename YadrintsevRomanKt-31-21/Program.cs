using NLog;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using YadrintsevRomanKt_31_21.Database;
using System;

var builder = WebApplication.CreateBuilder(args);

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
	builder.Logging.ClearProviders();
	builder.Host.UseNLog();
	// Add services to the container.

	builder.Services.AddControllers();
	// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
	builder.Services.AddEndpointsApiExplorer();
	builder.Services.AddSwaggerGen();

	builder.Services.AddDbContext<TeacherDbContext>(options =>
	{
		options.UseSqlServer(builder.Configuration.GetConnectionString("ConnString"));
	});

	var app = builder.Build();

	// Configure the HTTP request pipeline.
	if (app.Environment.IsDevelopment())
	{
		app.UseSwagger();
		app.UseSwaggerUI();
	}


	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
catch (Exception ex)
{
	logger.Error(ex, "Stopped program because of exception");
}
finally
{
	LogManager.Shutdown();
}