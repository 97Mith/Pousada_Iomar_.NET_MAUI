using IomarPousada.Data.Interface;
using IomarPousada.MVVM.ViewModel;

namespace IomarPousada.MVVM.View;

public partial class NewCompany : ContentPage
{
    private readonly ICompanyRepository _companyRepository;
    public NewCompany(ICompanyRepository companyRepository)
    {
        InitializeComponent();
        _companyRepository = companyRepository;
        BindingContext = new CompanyViewModel(_companyRepository, Navigation);
    }

    private void BackOnClick(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ValidateFields(object sender, EventArgs e)
    {

    }
}