

using CommunityToolkit.Mvvm.ComponentModel;
using IomarPousada.Data.Interface;
using IomarPousada.MVVM.Model;
using IomarPousada.MVVM.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace IomarPousada.MVVM.ViewModel;

public partial class PersonViewModel : ObservableObject
{
    [ObservableProperty]
    private ObservableCollection<Company> _companies;

    [ObservableProperty]
    private ObservableCollection<Person> _people;

    [ObservableProperty]
    private bool _isRefreshing;

    [ObservableProperty]
    private string _errorMessage;

    [ObservableProperty]
    private bool _isErrorVisible;

    [ObservableProperty]
    private Person _person;

    public ICommand AddCommand { get; set; }
    public ICommand RemoveCommand { get; set; }
    public ICommand UpdateCommand { get; set; }
    public ICommand LoadCompaniesCommand { get; set; }
    public ICommand DisplayCommand { get; set; }
    public ICommand DisplayByIdCommand { get; set; }
    public ICommand RefreshCommand { get; set; }
    public ICommand ToEditCommand {  get; set; }

    private readonly IPersonRepository _personRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly INavigation _navigation;

    public PersonViewModel(){ }

    public PersonViewModel(ICompanyRepository companyRepository, IPersonRepository personRepository, INavigation navigation)
    {
        _personRepository = personRepository;
        _companyRepository = companyRepository;
        _navigation = navigation;
        Companies = new ObservableCollection<Company>();
        People = new ObservableCollection<Person>();
        Person = new Person();

        AddCommand = new Command(async () => await AddPerson());
        RemoveCommand = new Command<Person>(async (person) => await DeletePerson(person));
        UpdateCommand = new Command(async () => await UpdatePerson());
        DisplayCommand = new Command(async () => await DisplayPeople());
        RefreshCommand = new Command(async () => await Refresh());
        ToEditCommand = new Command<Person>(async (person) => await ToEditPerson(person));
        LoadCompaniesCommand = new Command(async () => await DisplayCompanies());

        LoadPeopleAndCompanies();
    }

    
    public async Task AddPerson()
    {
        await _personRepository.InitializeAsync();
        await _personRepository.AddAsync(Person);
        //await Refresh();
        await _navigation.PopModalAsync();
    }
    
    private async Task DeletePerson(Person person)
    {
        await _personRepository.InitializeAsync();
        await _personRepository.DeleteAsync(person);
        await Refresh();
    }

    private async Task UpdatePerson()
    {
        await _personRepository.InitializeAsync();
        await _personRepository.UpdateAsync(Person);
    }

    private async Task DisplayPeople()
    {
        await _personRepository.InitializeAsync();
        var people = await _personRepository.GetAllAsync();
        People.Clear();
        foreach (var person in people)
        {
            People.Add(person);
        }
    }

    private async Task DisplayPersonById(int id)
    {
        await _personRepository.InitializeAsync();
        Person = await _personRepository.GetByIdAsync(id);
    }

    private async Task DisplayPeopleByName(string name)
    {
        await _personRepository.InitializeAsync();
        var people = await _personRepository.GetByNameAsync(name);
        People.Clear();
        foreach (var person in people)
        {
            People.Add(person);
        }
    }

    private async Task Refresh()
    {
        IsRefreshing = true;
        await DisplayPeople();
        IsRefreshing = false;
    }

    private async Task ToEditPerson(Person person)
    {
        await _navigation.PushModalAsync(new EditPerson(_personRepository, person));
    }

    private async void LoadPeopleAndCompanies()
    {
        await DisplayPeople();
        await DisplayCompanies();
    }
    

    private async Task DisplayCompanies()
    {
        await _companyRepository.InitializeAsync();
        var companies = await _companyRepository.GetAllAsync();
        Companies.Clear();
        foreach (var company in companies)
        {
            Companies.Add(company);
        }
    }
}
