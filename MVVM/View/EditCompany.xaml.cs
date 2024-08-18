using IomarPousada.Data.Interface;
using IomarPousada.MVVM.Model;
using IomarPousada.MVVM.ViewModel;

namespace IomarPousada.MVVM.View;

public partial class EditCompany : ContentPage
{
    private readonly ICompanyRepository _companyRepository;
    public EditCompany(ICompanyRepository companyRepository, Company company)
    {
        InitializeComponent();
        _companyRepository = companyRepository;
        BindingContext = new EditCompanyViewModel(companyRepository, company, Navigation);
    }

    private void BackOnClick(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }
}