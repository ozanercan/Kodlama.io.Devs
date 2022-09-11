using FluentValidation;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.BusinessRules;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguageTechnologies.BusinessRules;
using Kodlama.io.Devs.Application.Pipelines.Validators;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Kodlama.io.Devs.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependencies(this IServiceCollection services)
    {
        var assembly = Assembly.GetExecutingAssembly();

        services.AddMediatR(assembly);
        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(assembly);

        services.AddScoped<ProgrammingLanguagesBusinessRules>();
        services.AddScoped<ProgrammingLanguageTechnologyBusinessRules>();

        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

        return services;
    }
}
