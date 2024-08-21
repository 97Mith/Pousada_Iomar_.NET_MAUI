using IomarPousada.MVVM.ViewModel;

namespace IomarPousada.MVVM.View;

public partial class GuestsPage : ContentPage
{
	IPersonRepository _servicePerson;
    private PersonViewModel _personViewModel;
    public GuestsPage(IPersonRepository personRepository)
	{
		InitializeComponent();
		_servicePerson = personRepository;
        _personViewModel = new PersonViewModel(_servicePerson, Navigation);
        BindingContext = _personViewModel;
    }

    private void AddPerson(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewPerson(_servicePerson));
    }


    private void OnSearchTextChanged(object sender, TextChangedEventArgs e)
    {

    }
}