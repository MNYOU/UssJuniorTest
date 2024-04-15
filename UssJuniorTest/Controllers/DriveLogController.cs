using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using UssJuniorTest.Application.Models.Request;
using UssJuniorTest.Application.Services;
using UssJuniorTest.Application.Sieve;

namespace UssJuniorTest.Controllers;

/// <summary>
/// Контроллер для управления данными журнала поездок.
/// </summary>
[Route("api/driveLog")]
public class DriveLogController : ControllerBase
{
    private readonly IDriverReportsGenerator driverReportsGenerator;
    
    /// <summary>
    /// Инициализирует новый экземпляр класса <see cref="DriveLogController"/>.
    /// </summary>
    /// <param name="driverReportsGenerator">Генератор отчетов о водителях.</param>
    public DriveLogController(IDriverReportsGenerator driverReportsGenerator)
    {
        this.driverReportsGenerator = driverReportsGenerator;
    }

    /// <summary>
    /// Получает агрегированные данные журнала поездок на основе указанных параметров.
    /// </summary>
    /// <param name="parameters">Параметры для фильтрации и агрегации журнала поездок.</param>
    /// <returns>Агрегированные данные журнала поездок.</returns>
    [HttpGet]
    public IActionResult GetDriveLogsAggregation([FromQuery] Parameters parameters)
    {
        var res = driverReportsGenerator.CreateReport(parameters);

        return Ok(res);
    }
}