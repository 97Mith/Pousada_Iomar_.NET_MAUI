using IomarPousada.Data.Interface;
using IomarPousada.MVVM.ViewModel;

namespace IomarPousada.MVVM.View;

public partial class CompaniesPage : ContentPage
{
    private readonly ICompanyRepository _companyRepository;

    public CompaniesPage(ICompanyRepository company)
    {
        InitializeComponent();
        _companyRepository = company;
        BindingContext = new CompanyViewModel(_companyRepository, Navigation);
    }

    private void AddCompany(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new NewCompany(_companyRepository));
    }

}