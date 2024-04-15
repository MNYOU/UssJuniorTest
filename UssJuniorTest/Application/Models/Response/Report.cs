namespace UssJuniorTest.Application.Models.Response;

/// <summary>
/// 
/// </summary>
public class Report
{
    public Report(ICollection<DriverReport> driversReports)
    {
        DriversReports = driversReports;
    }

    public ICollection<DriverReport> DriversReports { get; }
}