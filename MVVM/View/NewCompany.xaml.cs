using IomarPousada.Data.Interface;
using IomarPousada.MVVM.ViewModel;
using IomarPousada.Validation;
using System.Text;

namespace IomarPousada.MVVM.View;

public partial class NewCompany : ContentPage
{
    private readonly ICompanyRepository _companyRepository;
    private CompanyViewModel _companyViewModel;

    public NewCompany(ICompanyRepository companyRepository)
    {
        InitializeComponent();
        _companyRepository = companyRepository;
        _companyViewModel = new CompanyViewModel(_companyRepository, Navigation);
        BindingContext = _companyViewModel;
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
            await _companyViewModel.AddCompany();
            await DisplayAlert("Êxito", "A empresa foi salva com sucesso!", "OK");
        }
    }

    private bool ValidateFields()
    {
        StringBuilder sb = new StringBuilder();
        bool isError = false;

        ValidateField(() => ExceptionValidation.IsEmptyOrBlank(EntryName.Text), "O campo 'Nome' não pode ficar em branco!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryName.Text, 3, 20), "O campo 'Nome' precisa ficar entre 3 e 20 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsEmptyOrBlank(EntryCr.Text), "O campo 'Razão Social' não pode ficar em branco!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryCr.Text, 3, 50), "O campo 'Razão Social' precisa ficar entre 3 e 50 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsEmptyOrBlank(EntryCnpj.Text), "O campo 'CNPJ' não pode ficar em branco!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryCnpj.Text, 14, 18), "O campo 'CNPJ' precisa ficar entre 14 e 18 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryTel1.Text, 10, 18), "O campo 'Telefone 1' precisa ficar entre 10 e 18 caracteres!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryTel2.Text, 10, 18), "O campo 'Telefone 2' precisa ficar entre 10 e 18 caracteres!", sb, ref isError);

        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryStreet.Text, 5, 50), "O campo 'Rua' precisa ficar entre 5 e 50 caracteres!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryCity.Text, 3, 30), "O campo 'Cidade' precisa ficar entre 3 e 30 caracteres!", sb, ref isError);
        ValidateField(() => ExceptionValidation.IsValidLengthSize(EntryState.Text, 2, 30), "O campo 'Estado' precisa ficar entre 2 e 30 caracteres!", sb, ref isError);

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
