using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarritoFinal.Models;

public partial class CarritoC : DbContext
{
    public CarritoC()
    {
    }

    public CarritoC(DbContextOptions<CarritoC> options)
        : base(options)
    {
    }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<DetalleVenta> DetalleVenta { get; set; }

    public virtual DbSet<Distrito> Distritos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Provincia> Provincia { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=SQL8001.site4now.net;Initial Catalog=db_a9b687_juan1diaz;User Id=db_a9b687_juan1diaz_admin;Password=1ALDAIR2.lago3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CdCarrito).HasName("PK__CARRITO__49B36D4A6B0F2441");

            entity.ToTable("CARRITO");

            entity.Property(e => e.CdCarrito)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CdCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CdProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();

            entity.HasOne(d => d.CdClienteNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.CdCliente)
                .HasConstraintName("FK__CARRITO__CdClien__440B1D61");

            entity.HasOne(d => d.CdProductoNavigation).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.CdProducto)
                .HasConstraintName("FK__CARRITO__CdProdu__44FF419A");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CdCategoria).HasName("PK__CATEGORI__AD61B959544E088F");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.CdCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.CdCliente).HasName("PK__CLIENTE__FE6512F15623C9AA");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.CdCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("CLave");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reestablecer).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DEPARTAMENTO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.Iddepartamento)
                .HasMaxLength(2)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleVenta>(entity =>
        {
            entity.HasKey(e => e.CdDetalleVenta).HasName("PK__DETALLE___57C3F098B4BE504A");

            entity.ToTable("DETALLE_VENTA");

            entity.Property(e => e.CdDetalleVenta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CdDetalle_Venta");
            entity.Property(e => e.CdProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CdvEnta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CdvENTA");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.CdProductoNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CdProducto)
                .HasConstraintName("FK__DETALLE_V__CdPro__4CA06362");

            entity.HasOne(d => d.CdvEntaNavigation).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.CdvEnta)
                .HasConstraintName("FK__DETALLE_V__CdvEN__4BAC3F29");
        });

        modelBuilder.Entity<Distrito>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DISTRITO");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IdDepartamento)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.IdDistrito)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.IdProvincia)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.CdMarca).HasName("PK__MARCA__007F085A8FD15CA7");

            entity.ToTable("MARCA");

            entity.Property(e => e.CdMarca)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CdProducto).HasName("PK__PRODUCTO__DA2ED4563CC1F93F");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.CdProducto)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.CdCategoria)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.CdMarca)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio)
                .HasDefaultValueSql("((0))")
                .HasColumnType("decimal(10, 2)");
            entity.Property(e => e.RutaImagen)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.CdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CdCategoria)
                .HasConstraintName("FK__PRODUCTO__CdCate__37A5467C");

            entity.HasOne(d => d.CdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CdMarca)
                .HasConstraintName("FK__PRODUCTO__CdMarc__36B12243");
        });

        modelBuilder.Entity<Provincia>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("PROVINCIA");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(45)
                .IsUnicode(false);
            entity.Property(e => e.IdDepartamento)
                .HasMaxLength(2)
                .IsUnicode(false);
            entity.Property(e => e.IdProvincia)
                .HasMaxLength(4)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CdUsuario).HasName("PK__USUARIO__0F869DD694BC7F7E");

            entity.ToTable("USUARIO");

            entity.Property(e => e.CdUsuario)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Activo).HasDefaultValueSql("((1))");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Clave)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Reestablecer).HasDefaultValueSql("((1))");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.CdvEnta).HasName("PK__VENTA__A4E1AE1A48E4D7ED");

            entity.ToTable("VENTA");

            entity.Property(e => e.CdvEnta)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("CdvENTA");
            entity.Property(e => e.CdCliente)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Contacto)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaVenta)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.IdDistrito)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.IdTransaccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MontoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.CdClienteNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CdCliente)
                .HasConstraintName("FK__VENTA__CdCliente__47DBAE45");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
