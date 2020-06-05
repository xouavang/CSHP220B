using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LaptopLoanerDB
{
    public partial class LoanersContext : DbContext
    {
        public LoanersContext()
        {
        }

        public LoanersContext(DbContextOptions<LoanersContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Loaner> Loaner { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=Loaners;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loaner>(entity =>
            {
                entity.Property(e => e.GuardianEmail).HasMaxLength(50);

                entity.Property(e => e.GuardianName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.GuardianPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.LaptopBrand)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LaptopModel).HasMaxLength(50);

                entity.Property(e => e.LaptopSerialNumber)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LoanerCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LoanerNotes).HasMaxLength(1000);

                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
