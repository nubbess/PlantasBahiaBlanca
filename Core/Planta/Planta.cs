namespace Core.Planta;
using Core.Direccion;
public partial class Planta
{
    public int PlantaId { get; set; }

    public string Estado { get; set; } = null!;

    public decimal Altura { get; set; }

    public int DireccionId { get; set; }

    public int EspecieId { get; set; }

    public virtual Direccion Direccion { get; set; } = null!;

    public virtual Direccion Especie { get; set; } = null!;
}
