using log_events_admin_api.Models;
using log_events_admin_api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var env = builder.Environment;
var Cors = "MyCors";

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables();


builder.Services.AddDbContext<RegistrationContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("Connection"));
});


builder.Services.AddScoped<IEventLogService, EventLogService>();


builder.Services.AddCors(
    options => options.AddPolicy(name: Cors, buid =>
    buid.AllowAnyOrigin()
    //WithOrigins("http://localhost:4200")
    .AllowAnyHeader()
    .AllowAnyMethod()));


var app = builder.Build();


if(app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors(Cors);
}


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
