namespace UssJuniorTest.Application.Models.Request;

/// <summary>
/// Набор параметров, используемых для фильтрации и агрегации данных.
/// </summary>
public class Parameters
{
    private int pageSize = 2;
    private const int MaxPageSize = 10;

    /// <summary>
    /// Фильтры для данных.
    /// </summary>
    /// <remarks>Допустимые варианты: driver, car</remarks>
    public string Filters { get; set; } = "";

    /// <summary>
    /// Сортировка данных.
    /// </summary>
    /// <remarks>Допустимые варианты: driver, car</remarks>
    public string Sorts { get; set; } = "";

    /// <summary>
    /// Начальная дата диапазона для фильтрации.
    /// </summary>
    public DateTime From { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Конечная дата диапазона для фильтрации.
    /// </summary>
    public DateTime To { get; set; } = DateTime.MaxValue;

    /// <summary>
    /// Номер страницы с данными.
    /// </summary>
    public int Page { get; set; } = 1;

    /// <summary>
    /// Размер страницы с данными.
    /// </summary>
    public int PageSize
    {
        get => pageSize;
        set
        {
            pageSize = value > MaxPageSize
                ? MaxPageSize
                : value;
        }
    }
}