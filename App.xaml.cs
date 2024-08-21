using IomarPousada.Data.Interface;
using IomarPousada.MVVM.View;

namespace IomarPousada;

public partial class App : Application
{
    public App(ICompanyRepository company, IPersonRepository person)
    {
        InitializeComponent();

        MainPage = new NavigationPage(new HomePage(company, person));
    }
}
