namespace UssJuniorTest.Application.Models.Response;

/// <summary>
/// Модель представления автомобиля.
/// </summary>
public class CarView
{
    /// <summary>
    /// Производитель.
    /// </summary>
    public string Manufacturer { get; set; }
    
    /// <summary>
    /// Модель автомобиля.
    /// </summary>
    public string Model { get; set; }
}