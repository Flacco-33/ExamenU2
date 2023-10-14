using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ExamenU2.Models;

public partial class ControlConsumoAguaContext : DbContext
{
    public ControlConsumoAguaContext()
    {
    }

    public ControlConsumoAguaContext(DbContextOptions<ControlConsumoAguaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionUsuariosDispositivo> AsignacionUsuariosDispositivos { get; set; }

    public virtual DbSet<Dispositivo> Dispositivos { get; set; }

    public virtual DbSet<RegistrosConsumo> RegistrosConsumos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Zona> Zonas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=Flacco-33;Database=ControlConsumoAgua;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionUsuariosDispositivo>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Asignaci__2B3DE798B9759E7C");

            entity.Property(e => e.UsuarioId)
                .ValueGeneratedOnAdd()
                .HasColumnName("UsuarioID");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.AsignacionUsuariosDispositivos)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("FK__Asignacio__Dispo__44FF419A");

            entity.HasOne(d => d.Usuario).WithOne(p => p.AsignacionUsuariosDispositivo)
                .HasForeignKey<AsignacionUsuariosDispositivo>(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Asignacio__Usuar__440B1D61");
        });

        modelBuilder.Entity<Dispositivo>(entity =>
        {
            entity.HasKey(e => e.DispositivoId).HasName("PK__Disposit__724C26412D2CA56A");

            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DireccionMac)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DireccionMAC");
            entity.Property(e => e.Identificador)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Latitud).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.Longitud).HasColumnType("decimal(9, 6)");
            entity.Property(e => e.NombreResponsable)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ZonaNavigation).WithMany(p => p.Dispositivos)
                .HasForeignKey(d => d.Zona)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Dispositiv__Zona__3E52440B");
        });

        modelBuilder.Entity<RegistrosConsumo>(entity =>
        {
            entity.HasKey(e => e.RegistroId).HasName("PK__Registro__B897313ED7191E2A");

            entity.ToTable("RegistrosConsumo");

            entity.Property(e => e.RegistroId).HasColumnName("RegistroID");
            entity.Property(e => e.DispositivoId).HasColumnName("DispositivoID");
            entity.Property(e => e.FechaHoraFin).HasColumnType("datetime");
            entity.Property(e => e.FechaHoraInicio).HasColumnType("datetime");
            entity.Property(e => e.LitrosRegistrados).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Dispositivo).WithMany(p => p.RegistrosConsumos)
                .HasForeignKey(d => d.DispositivoId)
                .HasConstraintName("FK__Registros__Dispo__412EB0B6");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__2A49584C351FB957");

            entity.ToTable("Rol");

            entity.Property(e => e.Rol1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__2B3DE7984D49FCB3");

            entity.Property(e => e.UsuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NombreUsuario)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoUsuarioNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__TipoUs__398D8EEE");
        });

        modelBuilder.Entity<Zona>(entity =>
        {
            entity.HasKey(e => e.ZonaId).HasName("PK__Zona__1F1E055657708230");

            entity.ToTable("Zona");

            entity.Property(e => e.ZonaId).HasColumnName("ZonaID");
            entity.Property(e => e.NombreZona)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
