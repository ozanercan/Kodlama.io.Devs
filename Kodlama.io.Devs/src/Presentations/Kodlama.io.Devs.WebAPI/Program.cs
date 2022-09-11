using Application;
using Core.CrossCuttingConcerns.Exceptions;
using Kodlama.io.Devs.Application;
using Kodlama.io.Devs.Application.Dtos.ConnectionOptions;
using Kodlama.io.Devs.Persistence;
using Kodlama.io.Devs.WebAPI.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PostgreSqlConnectionOptions>(builder.Configuration.GetSection("ConnectionStrings").GetSection("PostgreSql"));

builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomAuthentication(builder.Configuration);

builder.Services.AddAuthorization();

builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies();
builder.Services.AddSecurityServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
    app.ConfigureCustomExceptionMiddleware();
}

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
