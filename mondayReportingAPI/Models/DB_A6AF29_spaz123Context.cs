using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace mondayReportingAPI.Models
{
    public partial class DB_A6AF29_spaz123Context : DbContext
    {
        public DB_A6AF29_spaz123Context()
        {
        }

        public DB_A6AF29_spaz123Context(DbContextOptions<DB_A6AF29_spaz123Context> options)
            : base(options)
        {
        }

        public virtual DbSet<CtRole> CtRoles { get; set; }
        public virtual DbSet<CtUser> CtUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=sql5053.site4now.net;Database=DB_A6AF29_spaz123;User ID=DB_A6AF29_spaz123_admin;Password=F#HCCVY!2ffn2tw;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CtRole>(entity =>
            {
                entity.ToTable("CT_Roles");

                entity.Property(e => e.Id).HasColumnName("id");
            });

            modelBuilder.Entity<CtUser>(entity =>
            {
                entity.ToTable("CT_Users");

                entity.HasIndex(e => e.RoleId, "IX_CT_Users_RoleId");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.CtUsers)
                    .HasForeignKey(d => d.RoleId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
