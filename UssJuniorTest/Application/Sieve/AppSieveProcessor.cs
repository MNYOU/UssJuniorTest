using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using UssJuniorTest.Application.Sieve.Configurations;

namespace UssJuniorTest.Application.Sieve;

/// <summary>
/// Кастомная реализация процессора Sieve, настроенная под специфические требования приложения.
/// </summary>
public class AppSieveProcessor: SieveProcessor
{
    public AppSieveProcessor(IOptions<SieveOptions> options) : base(options)
    {
    }

    public AppSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods customSortMethods) : base(options, customSortMethods)
    {
    }

    public AppSieveProcessor(IOptions<SieveOptions> options, ISieveCustomFilterMethods customFilterMethods) : base(options, customFilterMethods)
    {
    }

    public AppSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods customSortMethods, ISieveCustomFilterMethods customFilterMethods) : base(options, customSortMethods, customFilterMethods)
    {
    }

    /// <summary>
    /// Отображает свойства для конфигурации Sieve.
    /// </summary>
    /// <param name="mapper">Маппер свойств Sieve.</param>
    /// <returns>Настроенный маппер свойств Sieve.</returns>
    protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
    {
        return mapper
            .ApplyConfiguration<SieveConfigurationForDriverReport>();
    }
}