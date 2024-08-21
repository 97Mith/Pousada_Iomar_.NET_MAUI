namespace IomarPousada.MVVM.View;

public partial class GuestsPage : ContentPage
{
	IPersonRepository _service;
	public GuestsPage(IPersonRepository personRepository)
	{
		InitializeComponent();
		_service = personRepository;
		//BindingContext = new 
	}

    private void AddPerson(object sender, EventArgs e)
    {
		Navigation.PushModalAsync(new NewPerson());
    }

    private void EditPerson(object sender, TappedEventArgs e)
    {

    }
}