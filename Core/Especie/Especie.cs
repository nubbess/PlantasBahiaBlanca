namespace Core.Especie;
using Core.Usuario;

public partial class Especie
{
    public int EspecieId { get; set; }

    public string NombreComun { get; set; } = null!;

    public string NombreCientifico { get; set; } = null!;

    public int ResponsableUserId { get; set; }

    public virtual Usuario ResponsableUser { get; set; } = null!;
}
