using SQLite;
using IomarPousada.Data.Interface;
using IomarPousada.MVVM.Model;

public class CompanyRepository : ICompanyRepository
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
            await _connection.CreateTableAsync<Company>();
        }
    }
    public async Task ResetDatabaseAsync()
    {
        await _connection.DropTableAsync<Company>();
        await _connection.CreateTableAsync<Company>();
    }

    public Task<List<Company>> GetAllAsync()
    {
        return _connection.Table<Company>().ToListAsync();
    }

    public Task<int> AddAsync(Company company)
    {
        return _connection.InsertAsync(company);
    }

    public Task<int> UpdateAsync(Company company)
    {
        return _connection.UpdateAsync(company);
    }

    public Task<int> DeleteAsync(Company company)
    {
        return _connection.DeleteAsync(company);
    }

    public Task<Company> GetByIdAsync(int id)
    {
        return _connection.Table<Company>()
            .Where(c => c.Id == id)
            .FirstOrDefaultAsync();
    }
    public async Task<List<Company>> GetByNameAsync(string name)
    {
        var allCompanies = await GetAllAsync();
        return allCompanies.Where(c => c.Name.Contains(name)).ToList();
    }
}
