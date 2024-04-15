using UssJuniorTest.Core.Models;

namespace UssJuniorTest.Infrastructure.Extensions;

/// <summary>
/// Предоставляет методы расширения для фильтрации коллекций объектов DriveLog по диапазону дат.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Фильтрует коллекцию журналов движения по диапазону дат.
    /// </summary>
    /// <param name="driveLogs">Коллекция логов поездок для фильтрации</param>
    /// <param name="from">Дата начала диапазона.</param>
    /// <param name="to">Дата конца диапазона.</param>
    /// <returns>Отфильтрованная коллекция логов поездок</returns>
    public static IEnumerable<DriveLog> FilterByDate(this IEnumerable<DriveLog> driveLogs, DateTime from, DateTime to)
    {
        foreach (var driveLog in driveLogs)
        {
            if (driveLog.StartDateTime.Date < from.Date) continue;
            if (driveLog.EndDateTime.Date > to.Date) continue;

            yield return driveLog;
        }
    }
}