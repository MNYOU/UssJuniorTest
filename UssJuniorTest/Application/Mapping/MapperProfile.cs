using AutoMapper;
using Sieve.Models;
using UssJuniorTest.Application.Models.Request;
using UssJuniorTest.Application.Models.Response;
using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Application.Mapping;

/// <summary>
/// Профиль маппинга между различными объектами.
/// </summary>
/// <remarks>Содержит правила маппинга для конкретных типов данных.</remarks>
public class MapperProfile: Profile
{
    public MapperProfile()
    {
        CreateMap<Person, DriverView>();
        CreateMap<Car, CarView>();

        CreateMap<Parameters, SieveModel>();
    }
}