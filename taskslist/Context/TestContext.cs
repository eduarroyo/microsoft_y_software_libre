using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using taskslist.Models;

namespace taskslist.Context
{
    public partial class TestContext : DbContext
    {
        public TestContext()
        {
        }

        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Mensajes> Mensajes { get; set; }
        public virtual DbSet<Tareas> Tareas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=TestDB;User Id=TestDbUser;Password=S4lm0r3j0.C0rd0b35");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mensajes>(entity =>
            {
                entity.HasKey(e => e.MensajeId)
                    .HasName("PK__Mensajes__6B304DCDBE52DD52");

                entity.Property(e => e.MensajeId).HasColumnName("mensaje_id");

                entity.Property(e => e.FechaEnvio)
                    .HasColumnName("fecha_envio")
                    .HasColumnType("datetime");

                entity.Property(e => e.Mensaje).HasColumnName("mensaje");

                entity.Property(e => e.Remitente)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tareas>(entity =>
            {
                entity.HasKey(e => e.TareaId)
                    .HasName("PK__Tareas__0CA80258E409ECFC");

                entity.Property(e => e.TareaId).HasColumnName("tarea_id");

                entity.Property(e => e.CreadoFecha)
                    .HasColumnName("creado_fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.ModificadoFecha)
                    .HasColumnName("modificado_fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Resuelta).HasColumnName("resuelta");

                entity.Property(e => e.Tarea)
                    .HasColumnName("tarea")
                    .HasMaxLength(500);

                entity.Property(e => e.Usuario)
                    .HasColumnName("usuario")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
