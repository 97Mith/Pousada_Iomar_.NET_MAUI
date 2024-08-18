using SQLite;

namespace IomarPousada.MVVM.Model;

public abstract class Base
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [NotNull, MaxLength(50)]
    public string Name { get; set; }
}
