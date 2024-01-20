﻿using Core.Plantas.Model;
using Core.Usuarios.Model;
namespace Core.Direcciones.Model
{
    public partial class Direccion
    {
        public int DireccionId { get; set; }

        public string Calle { get; set; } = null!;

        public string Numero { get; set; } = null!;

        public string? EntreCalle1 { get; set; }

        public string? EntreCalle2 { get; set; }

        public virtual ICollection<Planta> PlantaDireccions { get; set; } = new List<Planta>();

        public virtual ICollection<Planta> PlantaEspecies { get; set; } = new List<Planta>();

        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}