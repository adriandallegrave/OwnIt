using Microsoft.Extensions.DependencyInjection;
using OwnIt.Application.Interfaces;
using OwnIt.Application.Services;
using OwnIt.Domain.Interfaces.Repositories;
using OwnIt.Domain.Interfaces.Services;
using OwnIt.Domain.Services;
using OwnIt.Persistence;

namespace OwnIt.Injection;

public static class InversionOfControl
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        RegisterApplicationServices(services);
        RegisterDomainServices(services);
        RegisterPersistenceServices(services);
        RegisterToolsServices(services);

        return services;
    }

    private static void RegisterApplicationServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryAppService, CategoryAppService>();
        services.AddScoped<ITransactionAppService, TransactionAppService>();
        services.AddScoped<IPaymentMethodAppService, PaymentMethodAppService>();
    }

    private static void RegisterDomainServices(IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ITransactionService, TransactionService>();
        services.AddScoped<IPaymentMethodService, PaymentMethodService>();
    }

    private static void RegisterPersistenceServices(IServiceCollection services)
    {
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
    }

    private static void RegisterToolsServices(IServiceCollection services)
    {
    }
}
