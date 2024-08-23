using IomarPousada.Data.Interface;
using IomarPousada.MVVM.ViewModel;

namespace IomarPousada.MVVM.View;

public partial class GuestsPage : ContentPage
{
	IPersonRepository _servicePerson;
    ICompanyRepository _serviceCompany;
    private PersonViewModel _personViewModel;
    public GuestsPage(IPersonRepository personRepository, ICompanyRepository companyRepository)
	{
		InitializeComponent();
		_servicePerson = personRepository;
        _serviceCompany = companyRepository;

        _personViewModel = new PersonViewModel
            (
            companyRepository: _serviceCompany, 
            personRepository: _servicePerson, 
            navigation: Navigation
            );

        BindingContext = _personViewModel;
    }

    private void AddPerson(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewPerson(companyRepository: _serviceCompany, personRepository: _servicePerson));
    }


    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {

    }
}