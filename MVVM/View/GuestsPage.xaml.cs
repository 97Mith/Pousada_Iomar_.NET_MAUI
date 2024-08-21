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
}