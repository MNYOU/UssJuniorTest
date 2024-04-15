using UssJuniorTest.Application.Models.Request;
using UssJuniorTest.Application.Models.Response;

namespace UssJuniorTest.Application.Services;

/// <summary>
/// Контракт для генерации отчетов.
/// </summary>
public interface IDriverReportsGenerator
{
    /// <summary>
    /// Генерирует отчет.
    /// </summary>
    /// <param name="parameters">Набор параметров, используемых для фильтрации и агрегации данных.</param>
    /// <returns></returns>
    public Report CreateReport(Parameters parameters);
}