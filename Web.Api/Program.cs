using Application;
using Infrastructure;
using Infrastructure.Data;
using Serilog;
using Web.Api;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddInfrastructure()
        .AddApplication()
        .AddWebApi();

    builder.Host.UseSerilog((context, configuration) => 
        configuration.ReadFrom.Configuration(context.Configuration));
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseSerilogRequestLogging();
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
}

using var scope = app.Services.CreateScope();
var appDbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();
Seed.Run(appDbContext);

app.Run();