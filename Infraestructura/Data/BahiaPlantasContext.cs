using Microsoft.EntityFrameworkCore;
using Core.Models;
namespace Infraestructura;

public partial class BahiaPlantasContext : DbContext
{
    public BahiaPlantasContext()
    {
    }

    public BahiaPlantasContext(DbContextOptions<BahiaPlantasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Direccion> Direcciones { get; set; }

    public virtual DbSet<Especie> Especies { get; set; }

    public virtual DbSet<Planta> Plantas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=BahiaPlantas;Integrated security=True;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.DireccionId).HasName("PK__Direccio__68906D446E94AACA");

            entity.Property(e => e.DireccionId).HasColumnName("DireccionID");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntreCalle1)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.EntreCalle2)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Numero)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Especie>(entity =>
        {
            entity.HasKey(e => e.EspecieId).HasName("PK__Especies__9CF6045C18FF6AEB");

            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.NombreCientifico)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreComun)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ResponsableUserId).HasColumnName("ResponsableUserID");

            entity.HasOne(d => d.ResponsableUser).WithMany(p => p.Especies)
                .HasForeignKey(d => d.ResponsableUserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_ResponsableUserID");
        });

        modelBuilder.Entity<Planta>(entity =>
        {
            entity.HasKey(e => e.PlantaId).HasName("PK__Plantas__DAFD417F9A28CF50");

            entity.Property(e => e.PlantaId).HasColumnName("PlantaID");
            entity.Property(e => e.Altura).HasColumnType("decimal(2, 1)");
            entity.Property(e => e.DireccionId).HasColumnName("DireccionID");
            entity.Property(e => e.EspecieId).HasColumnName("EspecieID");
            entity.Property(e => e.Estado)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Direccion).WithMany(p => p.PlantaDireccions)
                .HasForeignKey(d => d.DireccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DireccionPlanta");

            entity.HasOne(d => d.Especie).WithMany(p => p.PlantaEspecies)
                .HasForeignKey(d => d.EspecieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_EspeciePlanta");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE79803420B4B");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.DireccionId).HasColumnName("DireccionID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.Username)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.Direccion).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.DireccionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DireccionUsuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
