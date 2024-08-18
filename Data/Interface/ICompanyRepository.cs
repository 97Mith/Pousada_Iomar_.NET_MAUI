using IomarPousada.MVVM.Model;

namespace IomarPousada.Data.Interface;

public interface ICompanyRepository
{
    Task InitializeAsync();
    Task<int> AddAsync(Company company);
    Task<int> DeleteAsync(Company company);
    Task<int> UpdateAsync(Company company);

    Task<List<Company>> GetAllAsync();
    Task<Company> GetByIdAsync(int id);
    Task<List<Company>> GetByNameAsync(string name);

}
