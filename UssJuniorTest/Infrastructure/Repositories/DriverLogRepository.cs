using UssJuniorTest.Core;
using UssJuniorTest.Core.Models;
using UssJuniorTest.Infrastructure.Store;

namespace UssJuniorTest.Infrastructure.Repositories;

public class DriverLogRepository: IRepository<DriveLog>
{
    private readonly IStore _store;

    public DriverLogRepository(IStore store)
    {
        _store = store;
    }

    public DriveLog? Get(long id)
    {
        return _store.GetAllDriveLogs().FirstOrDefault(x => x.Id == id);
    }

    public IEnumerable<DriveLog> GetAll()
    {
        return _store.GetAllDriveLogs();
    }
}