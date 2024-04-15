using AutoMapper;
using Sieve.Models;
using Sieve.Services;
using UssJuniorTest.Application.Models.Request;
using UssJuniorTest.Application.Models.Response;
using UssJuniorTest.Core;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Extensions;

namespace UssJuniorTest.Application.Services;

/// <summary>
/// Класс, генерирующий отчеты
/// </summary>
public class DriverReportsGenerator : IDriverReportsGenerator
{
    private readonly IMapper mapper;
    private readonly IRepository<Car> carRepository;
    private readonly IRepository<Person> personRepository;
    private readonly IRepository<DriveLog> driveLogRepository;
    private readonly ISieveProcessor sieveProcessor;

    public DriverReportsGenerator(IRepository<Car> carRepository, IRepository<Person> personRepository,
        IRepository<DriveLog> driveLogRepository, IMapper mapper, ISieveProcessor sieveProcessor)
    {
        this.carRepository = carRepository;
        this.personRepository = personRepository;
        this.driveLogRepository = driveLogRepository;
        this.mapper = mapper;
        this.sieveProcessor = sieveProcessor;
    }

    /// <summary>
    /// Генерирует отчет.
    /// </summary>
    /// <param name="parameters">Набор параметров, используемых для фильтрации и агрегации данных.</param>
    /// <returns></returns>
    public Report CreateReport(Parameters parameters)
    {
        var trips = driveLogRepository
            .GetAll()
            .FilterByDate(parameters.From, parameters.To);

        var drivers = personRepository
            .GetAll()
            .ToDictionary(person => person.Id);

        var cars = carRepository
            .GetAll()
            .ToDictionary(car => car.Id);


        var logs = new Dictionary<long, Dictionary<long, TimeSpan>>();
        foreach (var trip in trips)
        {
            logs.TryAdd(trip.PersonId, new Dictionary<long, TimeSpan>());
            logs[trip.PersonId].TryAdd(trip.CarId, TimeSpan.Zero);
            logs[trip.PersonId][trip.CarId] += trip.EndDateTime - trip.StartDateTime;
        }

        var reports = new List<DriverReport>(logs.Count);
        foreach (var driverLog in logs)
        {
            var driver = mapper.Map<DriverView>(drivers[driverLog.Key]);
            foreach (var pair in driverLog.Value)
            {
                var carInfo = new DriverReport()
                {
                    Car = mapper.Map<CarView>(cars[pair.Key]),
                    Driver = driver,
                    TimeBehindTheWheel = pair.Value,
                };

                reports.Add(carInfo);
            }
        }

        var processed = sieveProcessor
            .Apply(mapper.Map<SieveModel>(parameters), reports.AsQueryable())
            .ToArray();

        return new Report(processed);
    }
}