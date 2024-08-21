using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows.Input;

namespace IomarPousada.MVVM.ViewModel;

public partial class EditPersonViewModel : ObservableObject
{
    [ObservableProperty]
    private Person _person;

    public ICommand SaveCommand {  get; set; }
    private readonly IPersonRepository _personRepository;
    private readonly INavigation _navigation;

    public EditPersonViewModel()
    { }

    public EditPersonViewModel(IPersonRepository personRepository, Person person, INavigation navigation)
    {
        _personRepository = personRepository;
        _navigation = navigation;
        _person = person;

        SaveCommand = new Command(async () => await SavePerson());
    }
    public async Task SavePerson()
    {
        await _personRepository.InitializeAsync();
        await _personRepository.UpdateAsync(Person);
        await _navigation.PopModalAsync();
    }
}
