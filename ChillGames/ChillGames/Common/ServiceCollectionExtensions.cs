namespace ChillGames.WebApi.Common
{
    using System.Reflection;
    using FluentValidation;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Расширения для <see cref="IServiceCollection"/>.
    /// </summary>
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services, Assembly assembly)
        {
            AssemblyScanner
                .FindValidatorsInAssembly(assembly)
                .ForEach(validatorInfo =>
                {
                    var abstractValidatorType = 
                        typeof(AbstractValidator<>)
                            .MakeGenericType(validatorInfo.InterfaceType.GenericTypeArguments[0]);
                    
                    services.AddTransient(abstractValidatorType, validatorInfo.ValidatorType);
                });

            return services;
        }
    }
}