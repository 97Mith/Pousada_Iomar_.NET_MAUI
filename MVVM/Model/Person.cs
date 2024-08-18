using IomarPousada.MVVM.Model;
using SQLite;

public class Person : Base
{
    [MaxLength(80)]
    public string LastName { get; set; }

    [MaxLength(20)]
    public string Cpf { get; set; }

    [MaxLength(20)]
    public string PhoneNumber { get; set; }

    [MaxLength(255)]
    public string Obs { get; set; }

    [MaxLength(255)]
    public string Photo { get; set; }


    //propriedades de navegação

    public int CompanyId { get; set; }
    public int AccomodationNum { get; set; }

    //................................


    public Person()
    {

    }

    public Person(string name, string? lastName, string? cpf, string? pn, string? obs, string? photo, int companyId)
    {
        Name = name;
        LastName = lastName ?? string.Empty;
        Cpf = cpf ?? string.Empty;
        PhoneNumber = pn ?? string.Empty;
        Obs = obs ?? string.Empty;
        Photo = photo ?? string.Empty;
        CompanyId = companyId;
    }
}