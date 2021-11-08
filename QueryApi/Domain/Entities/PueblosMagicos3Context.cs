using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace QueryApi.Domain.Entities
{
    public partial class PueblosMagicos3Context : DbContext
    {
        public PueblosMagicos3Context()
        {
        }

        public PueblosMagicos3Context(DbContextOptions<PueblosMagicos3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Artesano> Artesanos { get; set; }
        public virtual DbSet<ContactoArtesano> ContactoArtesanos { get; set; }
        public virtual DbSet<ContactoRst> ContactoRsts { get; set; }
        public virtual DbSet<FotosProducto> FotosProductos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }
        public virtual DbSet<RedSocialArtesano> RedSocialArtesanos { get; set; }
        public virtual DbSet<Restaurante> Restaurantes { get; set; }
        public virtual DbSet<UbicacionArtesano> UbicacionArtesanos { get; set; }
        public virtual DbSet<UbicacionRst> UbicacionRsts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-HE7PPRF;Initial Catalog=PueblosMagicos3;User Id=UserOAS; Password=1qaz1qaz;Persist Security Info=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<Artesano>(entity =>
            {
                entity.HasKey(e => e.IdA)
                    .HasName("Artesanos_pk");

                entity.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Materno");

                entity.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Apellido_Paterno");

                entity.Property(e => e.Logo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreNegocio)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_Negocio");
            });

            modelBuilder.Entity<ContactoArtesano>(entity =>
            {
                entity.HasKey(e => e.IdC)
                    .HasName("Contacto_Artesano_pk");

                entity.ToTable("Contacto_Artesano");

                entity.Property(e => e.ArtesanosIdA).HasColumnName("Artesanos_IdA");

                entity.Property(e => e.Correo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtesanosIdANavigation)
                    .WithMany(p => p.ContactoArtesanos)
                    .HasForeignKey(d => d.ArtesanosIdA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contacto_Artesano_Artesanos");
            });

            modelBuilder.Entity<ContactoRst>(entity =>
            {
                entity.ToTable("Contacto_Rst");

                entity.Property(e => e.RestaurantesIdRts).HasColumnName("Restaurantes_IdRts");

                entity.HasOne(d => d.RestaurantesIdRtsNavigation)
                    .WithMany(p => p.ContactoRsts)
                    .HasForeignKey(d => d.RestaurantesIdRts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Contacto_Rst_Restaurantes");
            });

            modelBuilder.Entity<FotosProducto>(entity =>
            {
                entity.HasKey(e => e.Idf)
                    .HasName("Fotos_Productos_pk");

                entity.ToTable("Fotos_Productos");

                entity.Property(e => e.ProductoIdP).HasColumnName("Producto_idP");

                entity.HasOne(d => d.ProductoIdPNavigation)
                    .WithMany(p => p.FotosProductos)
                    .HasForeignKey(d => d.ProductoIdP)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fotos_Productos_Producto");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdP)
                    .HasName("Producto_pk");

                entity.ToTable("Producto");

                entity.Property(e => e.ArtesanosIdA).HasColumnName("Artesanos_IdA");

                entity.Property(e => e.MateriaPrima).HasColumnName("Materia_prima");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtesanosIdANavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.ArtesanosIdA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Producto_Artesanos");
            });

            modelBuilder.Entity<RedSocialArtesano>(entity =>
            {
                entity.HasKey(e => e.IdRs)
                    .HasName("RedSocial_Artesanos_pk");

                entity.ToTable("RedSocial_Artesanos");

                entity.Property(e => e.ArtesanosIdA).HasColumnName("Artesanos_IdA");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtesanosIdANavigation)
                    .WithMany(p => p.RedSocialArtesanos)
                    .HasForeignKey(d => d.ArtesanosIdA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("RedSocial_Artesanos_Artesanos");
            });

            modelBuilder.Entity<UbicacionArtesano>(entity =>
            {
                entity.HasKey(e => e.IdU)
                    .HasName("Ubicacion_Artesano_pk");

                entity.ToTable("Ubicacion_Artesano");

                entity.Property(e => e.ArtesanosIdA).HasColumnName("Artesanos_IdA");

                entity.Property(e => e.Geoubicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.ArtesanosIdANavigation)
                    .WithMany(p => p.UbicacionArtesanos)
                    .HasForeignKey(d => d.ArtesanosIdA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ubicacion_Artesano_Artesanos");
            });

            modelBuilder.Entity<UbicacionRst>(entity =>
            {
                entity.ToTable("Ubicacion_Rst");

                entity.Property(e => e.Geoubicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RestaurantesIdRts).HasColumnName("Restaurantes_IdRts");

                entity.Property(e => e.Ubicacion)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RestaurantesIdRtsNavigation)
                    .WithMany(p => p.UbicacionRsts)
                    .HasForeignKey(d => d.RestaurantesIdRts)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Ubicacion_Rst_Restaurantes");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
