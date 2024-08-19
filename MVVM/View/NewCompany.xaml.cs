using IomarPousada.Data.Interface;
using IomarPousada.MVVM.ViewModel;
using IomarPousada.Validation;
using System.Text;

namespace IomarPousada.MVVM.View;

public partial class NewCompany : ContentPage
{
    private readonly ICompanyRepository _companyRepository;

    public NewCompany(ICompanyRepository companyRepository)
    {
        InitializeComponent();
        _companyRepository = companyRepository;
        BindingContext = new CompanyViewModel(_companyRepository, Navigation);
    }

    private void BackOnClick(object sender, TappedEventArgs e)
    {
        Navigation.PopModalAsync();
    }

    private void ValidateFieldsAndSave(object sender, EventArgs e)
    {
        bool isError = ValidateFields();

        if (isError)
        {
            LabelError.IsVisible = true;
        }
        else
        {
            LabelError.IsVisible = false;
            // Lógica para salvar a empresa
        }
    }

    private bool ValidateFields()
    {
        StringBuilder sb = new StringBuilder();
        bool isError = false;

        if (ExceptionValidation.IsEmptyOrBlank(EntryName.Text))
        {
            sb.AppendLine("O campo 'Nome' não pode ficar em branco!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryName.Text, 3, 20))
        {
            sb.AppendLine("O campo 'Nome' precisa ficar entre 3 e 20 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsEmptyOrBlank(EntryCr.Text))
        {
            sb.AppendLine("O campo 'Razão Social' não pode ficar em branco!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryCr.Text, 3, 50))
        {
            sb.AppendLine("O campo 'Razão Social' precisa ficar entre 3 e 50 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsEmptyOrBlank(EntryCnpj.Text))
        {
            sb.AppendLine("O campo 'CNPJ' não pode ficar em branco!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryCnpj.Text, 14, 18))
        {
            sb.AppendLine("O campo 'CNPJ' precisa ficar entre 14 e 18 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryTel1.Text, 10, 18))
        {
            sb.AppendLine("O campo 'Telefone 1' precisa ficar entre 10 e 18 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryTel2.Text, 10, 18))
        {
            sb.AppendLine("O campo 'Telefone 2' precisa ficar entre 10 e 18 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryStreet.Text, 5, 50))
        {
            sb.AppendLine("O campo 'Rua' precisa ficar entre 5 e 50 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryCity.Text, 3, 30))
        {
            sb.AppendLine("O campo 'Cidade' precisa ficar entre 3 e 30 caracteres!");
            isError = true;
        }
        if (ExceptionValidation.IsValidLengthSize(EntryState.Text, 2, 30))
        {
            sb.AppendLine("O campo 'Estado' precisa ficar entre 2 e 30 caracteres!");
            isError = true;
        }

        if (isError)
        {
            LabelError.Text = sb.ToString();
        }

        return isError;
    }
}
