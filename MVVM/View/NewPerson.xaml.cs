using IomarPousada.MVVM.ViewModel;
using IomarPousada.Validation;
using System.Text;

namespace IomarPousada.MVVM.View;

public partial class NewPerson : ContentPage
{
	private readonly IPersonRepository _personRepository;
	private PersonViewModel _personViewModel;
	public NewPerson(IPersonRepository personRepository)
	{
		InitializeComponent();
		_personRepository = personRepository;
		_personViewModel = new PersonViewModel(_personRepository, Navigation);
		BindingContext = _personViewModel;
	}

    private void BackOnClick(object sender, TappedEventArgs e)
    {
		Navigation.PopModalAsync();
    }

    private async void ValidateFieldsAndSave(object sender, EventArgs e)
    {
        bool isError = ValidateFields();

        if (isError)
        {
            LabelError.IsVisible = true;
        }
        else
        {
            LabelError.IsVisible = false;
            //await _personViewModel.AddPerson();
        }
    }

    private bool ValidateFields()
    {
        StringBuilder sb = new StringBuilder();
        bool isError = false;

        ValidateField(() => ExceptionValidation.IsEmptyOrBlank(EntryName.Text), "O campo 'Nome' não pode ficar em branco!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryName.Text, 3, 20), "O campo 'Nome' precisa ficar entre 3 e 20 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryLastName.Text, 3, 50), "O campo 'Sobre Nome' precisa ficar entre 3 e 50 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryCpf.Text, 11, 14), "O campo 'CPF' precisa ficar entre 14 e 18 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryPhoneNum.Text, 11, 14), "O campo 'Telefone' precisa ficar entre 14 e 18 caracteres!", sb, ref isError);

        if (isError)
        {
            LabelError.Text = sb.ToString();
        }

        return isError;
    }

    private void ValidateField(Func<bool> validationFunc, string errorMessage, StringBuilder sb, ref bool isError)
    {
        if (validationFunc())
        {
            sb.AppendLine(errorMessage);
            isError = true;
        }
    }
}