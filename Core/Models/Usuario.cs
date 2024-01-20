using System;
using System.Collections.Generic;

namespace Core.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public int DireccionId { get; set; }

    public bool IsAdmin { get; set; }

    public virtual Direccion Direccion { get; set; } = null!;

    public virtual ICollection<Especie> Especies { get; set; } = new List<Especie>();
}
