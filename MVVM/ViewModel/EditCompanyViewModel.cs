using CommunityToolkit.Mvvm.ComponentModel;
using IomarPousada.Data.Interface;
using IomarPousada.MVVM.Model;
using System.Windows.Input;

namespace IomarPousada.MVVM.ViewModel;

public partial class EditCompanyViewModel : ObservableObject
{
    [ObservableProperty]
    private Company _company;

    public ICommand SaveCommand { get; set; }
    private readonly ICompanyRepository _companyRepository;
    private readonly INavigation _navigation;
    public EditCompanyViewModel()
    { }

    public EditCompanyViewModel(ICompanyRepository companyRepository, Company company, INavigation navigation)
    {
        _companyRepository = companyRepository;
        _company = company;
        _navigation = navigation;

        SaveCommand = new Command(async () => await SaveCompany());
    }

    public async Task SaveCompany()
    {
        await _companyRepository.InitializeAsync();
        await _companyRepository.UpdateAsync(Company);
        await _navigation.PopModalAsync();
    }
}


