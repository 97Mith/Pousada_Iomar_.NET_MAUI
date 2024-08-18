using IomarPousada.Data.Interface;
using IomarPousada.MVVM.ViewModel;


namespace IomarPousada.MVVM.View;

public partial class HomePage : TabbedPage
{
    private readonly ICompanyRepository _companyRepository;
    public HomePage(ICompanyRepository company)
    {
        InitializeComponent();
        _companyRepository = company;

        var page1 = new AccomodationPage()
        {
            Title = "Acomodações",
            IconImageSource = "bedicon.svg"
        };

        var page2 = new GuestsPage()
        {
            Title = "Hóspedes",
            IconImageSource = "personicon.svg"
        };

        var page3 = new CompaniesPage(_companyRepository)
        {
            Title = "Empresas",
            IconImageSource = "companyicon.svg"
        };

        var page4 = new FinancesPage()
        {
            Title = "Finanças",
            IconImageSource = "financeicon.svg"
        };

        this.Children.Add(page1);
        this.Children.Add(page2);
        this.Children.Add(page3);
        this.Children.Add(page4);

    }
}