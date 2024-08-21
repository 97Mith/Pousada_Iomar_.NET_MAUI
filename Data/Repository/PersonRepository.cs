using SQLite;

namespace IomarPousada.Data.Repository;

public class PersonRepository : IPersonRepository
{
    private SQLiteAsyncConnection _connection;
    public async Task InitializeAsync()
    {
        await SetUpDb();
    }

    private async Task SetUpDb()
    {
        if (_connection == null)
        {
            string dbPath = Path.Combine(Environment
                .GetFolderPath(
                Environment
                .SpecialFolder
                .LocalApplicationData),
                "dbPath.db1");

            _connection = new SQLiteAsyncConnection(dbPath);
            await _connection.CreateTableAsync<Person>();
        }
    }
    public async Task ResetDatabaseAsync()
    {
        await _connection.DropTableAsync<Person>();
        await _connection.CreateTableAsync<Person>();
    }

    public Task<List<Person>> GetAllAsync()
    {
        return _connection.Table<Person>().ToListAsync();
    }

    public Task<int> AddAsync(Person person)
    {
        return _connection.InsertAsync(person);
    }

    public Task<int> UpdateAsync(Person person)
    {
        return _connection.UpdateAsync(person);
    }

    public Task<int> DeleteAsync(Person person)
    {
        return _connection.DeleteAsync(person);
    }

    public Task<Person> GetByIdAsync(int id)
    {
        return _connection.Table<Person>().Where(p => p.Id == id).FirstOrDefaultAsync();
    }

    public async Task<List<Person>> GetByNameAsync(string name)
    {
        var allPersons = await _connection.Table<Person>().ToListAsync();
        return allPersons.Where(p => p.Name.Contains(name)).ToList();
    }

    public Task<List<Person>> GetByCompanyAsync(int companyId)
    {
        return _connection.Table<Person>().Where(p => p.CompanyId == companyId).ToListAsync();
    }
}
