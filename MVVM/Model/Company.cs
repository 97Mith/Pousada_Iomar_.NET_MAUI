using SQLite;

namespace IomarPousada.MVVM.Model;

[Table("Companies")]
public class Company : Base
{
    [NotNull, MaxLength(120)]
    public string CorporateReason { get; set; }

    [NotNull, MaxLength(20)]
    public string Cnpj { get; set; }

    [MaxLength(15)]
    public string PhoneNumber1 { get; set; }

    [MaxLength(15)]
    public string PhoneNumber2 { get; set; }

    [MaxLength(75)]
    public string Email { get; set; }

    [MaxLength(100)]
    public string Street { get; set; }

    [MaxLength(20)]
    public string City { get; set; }

    [MaxLength(20)]
    public string State { get; set; }

    public Company() { }

    public Company(string name, string corporateReason, string cnpj, string? phoneNumber1, string? phoneNumber2, string? email, string? street, string? city, string state)
    {
        Name = name;
        CorporateReason = corporateReason;
        Cnpj = cnpj;
        PhoneNumber1 = phoneNumber1 ?? string.Empty;
        PhoneNumber2 = phoneNumber2 ?? string.Empty;
        Email = email ?? string.Empty;
        Street = street ?? string.Empty;
        City = city ?? string.Empty;
        State = state ?? string.Empty;
    }
}
