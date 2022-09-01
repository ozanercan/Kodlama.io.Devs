using Kodlama.io.Devs.Application;
using Kodlama.io.Devs.Application.Dtos.ConnectionOptions;
using Kodlama.io.Devs.Application.Middlewares.Exceptions;
using Kodlama.io.Devs.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<PostgreSqlConnectionOptions>(builder.Configuration.GetSection("ConnectionStrings").GetSection("PostgreSql"));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationDependencies();
builder.Services.AddPersistenceDependencies();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
    app.UseMiddleware<ExceptionMiddleware>();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
