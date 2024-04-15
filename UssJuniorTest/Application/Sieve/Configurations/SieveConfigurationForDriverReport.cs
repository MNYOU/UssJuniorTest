using Sieve.Services;
using UssJuniorTest.Application.Models.Response;

namespace UssJuniorTest.Application.Sieve.Configurations;

/// <summary>
/// Класс настройки кофигурации для Sieve
/// </summary>
public class SieveConfigurationForDriverReport : ISieveConfiguration
{
    /// <summary>
    /// Настраивает маппинг свойств
    /// </summary>
    /// <param name="mapper">Маппер свойств для настройки фильтрации и сортировки</param>
    public void Configure(SievePropertyMapper mapper)
    {
        mapper.Property<DriverReport>(info => info.Driver.Name)
            .CanFilter()
            .CanSort()
            .HasName("driver");

        mapper.Property<DriverReport>(info => info.Car.Manufacturer)
            .CanFilter()
            .CanSort()
            .HasName("car");
    }
}