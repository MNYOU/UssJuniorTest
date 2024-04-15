namespace UssJuniorTest.Application.Models.Response;

/// <summary>
/// Отчет о водителе
/// </summary>
/// <remarks>Содержит информацию о времени вождения конкретного человека конкретным авто.</remarks>
public class DriverReport
{
    public CarView Car { get; set; }
    
    public DriverView Driver { get; set; }
    
    public TimeSpan TimeBehindTheWheel { get; set; }
}