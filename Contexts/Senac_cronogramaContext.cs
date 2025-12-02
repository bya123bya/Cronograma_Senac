using System;
using System.Collections.Generic;
using CronogramaSenac.Models;
using Microsoft.EntityFrameworkCore;


namespace CronogramaSenac.Contexts;

public partial class Senac_cronogramaContext : DbContext
{
    public Senac_cronogramaContext()
    {
    }

    public Senac_cronogramaContext(DbContextOptions<Senac_cronogramaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DiasSemana> DiasSemanas { get; set; }

    public virtual DbSet<DiasTurma> DiasTurmas { get; set; }

    public virtual DbSet<Falta> Faltas { get; set; }

    public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }

    public virtual DbSet<Turma> Turmas { get; set; }

    public virtual DbSet<TurmaUc> TurmaUcs { get; set; }

    public virtual DbSet<Uc> Ucs { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioTurma> UsuarioTurmas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Senac_cronograma;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DiasSemana>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Dias_Sem__3213E83F0BA05F99");

            entity.ToTable("Dias_Semana");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Dia)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DiasTurma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DiasTurm__3213E83F91C05513");

            entity.ToTable("DiasTurma");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiasSemanaId).HasColumnName("Dias_Semana_id");
            entity.Property(e => e.TurmaId).HasColumnName("Turma_id");

            entity.HasOne(d => d.DiasSemana).WithMany(p => p.DiasTurmas)
                .HasForeignKey(d => d.DiasSemanaId)
                .HasConstraintName("FK__DiasTurma__Dias___52593CB8");

            entity.HasOne(d => d.Turma).WithMany(p => p.DiasTurmas)
                .HasForeignKey(d => d.TurmaId)
                .HasConstraintName("FK__DiasTurma__Turma__534D60F1");
        });

        modelBuilder.Entity<Falta>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Faltas__3213E83FF70431FC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Justificado)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.TurmaId).HasColumnName("Turma_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Turma).WithMany(p => p.Falta)
                .HasForeignKey(d => d.TurmaId)
                .HasConstraintName("FK__Faltas__Turma_id__60A75C0F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Falta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Faltas__Usuario___5FB337D6");
        });

        modelBuilder.Entity<TipoUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoUsua__3213E83FA6BF032A");

            entity.ToTable("TipoUsuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Tipo)
                .HasMaxLength(120)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Turma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Turma__3213E83FF0FF1F8E");

            entity.ToTable("Turma");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DataAula).HasColumnName("dataAula");
            entity.Property(e => e.DataFim).HasColumnName("dataFim");
            entity.Property(e => e.DataInicio).HasColumnName("dataInicio");
            entity.Property(e => e.HoraChegada)
                .HasPrecision(0)
                .HasColumnName("horaChegada");
            entity.Property(e => e.HoraSaida)
                .HasPrecision(0)
                .HasColumnName("horaSaida");
            entity.Property(e => e.Lancamento).HasColumnName("lancamento");
            entity.Property(e => e.QtsAulas).HasColumnName("qtsAulas");
        });

        modelBuilder.Entity<TurmaUc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TurmaUC__3213E83F1D91C155");

            entity.ToTable("TurmaUC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.TurmaId).HasColumnName("Turma_id");
            entity.Property(e => e.UcId).HasColumnName("UC_id");

            entity.HasOne(d => d.Turma).WithMany(p => p.TurmaUcs)
                .HasForeignKey(d => d.TurmaId)
                .HasConstraintName("FK__TurmaUC__Turma_i__6477ECF3");

            entity.HasOne(d => d.Uc).WithMany(p => p.TurmaUcs)
                .HasForeignKey(d => d.UcId)
                .HasConstraintName("FK__TurmaUC__UC_id__6383C8BA");
        });

        modelBuilder.Entity<Uc>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UC__3213E83F60FA4EB2");

            entity.ToTable("UC");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Descrição).HasColumnType("text");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83FF38B8922");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Email, "UQ__Usuario__A9D105347B97429A").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.Senha)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.TipoUsuarioId).HasColumnName("TipoUsuario_id");

            entity.HasOne(d => d.TipoUsuario).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.TipoUsuarioId)
                .HasConstraintName("FK__Usuario__TipoUsu__5CD6CB2B");
        });

        modelBuilder.Entity<UsuarioTurma>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UsuarioT__3213E83FB32D97AB");

            entity.ToTable("UsuarioTurma");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nome)
                .HasMaxLength(120)
                .IsUnicode(false);
            entity.Property(e => e.TurmaId).HasColumnName("Turma_id");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_id");

            entity.HasOne(d => d.Turma).WithMany(p => p.UsuarioTurmas)
                .HasForeignKey(d => d.TurmaId)
                .HasConstraintName("FK__UsuarioTu__Turma__68487DD7");

            entity.HasOne(d => d.Usuario).WithMany(p => p.UsuarioTurmas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__UsuarioTu__Usuar__6754599E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
