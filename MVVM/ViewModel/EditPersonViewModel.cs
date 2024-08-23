using CommunityToolkit.Mvvm.ComponentModel;
using IomarPousada.Data.Interface;
using System.Windows.Input;

namespace IomarPousada.MVVM.ViewModel;

public partial class EditPersonViewModel : ObservableObject
{
    [ObservableProperty]
    private Person _person;

    public ICommand SaveCommand {  get; set; }
    private readonly IPersonRepository _personRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly INavigation _navigation;

    public EditPersonViewModel()
    { }

    public EditPersonViewModel(ICompanyRepository companyRepository, IPersonRepository personRepository, Person person, INavigation navigation)
    {
        _companyRepository = companyRepository;
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
