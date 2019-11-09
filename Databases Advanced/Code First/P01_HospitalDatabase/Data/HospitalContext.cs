using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {

        }

        public HospitalContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Visitation> Visitations { get; set; }
        public DbSet<Diagnose> Diagnoses { get; set; }
        public DbSet<Medicament> Medicaments { get; set; }
        public DbSet<PatientMedicament> PatientMedicaments { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=HospitalDatabase;Integrated Security=True;");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Visitation>(entity =>
            {

                entity.Property(v => v.Comments).IsUnicode();

                entity
                .HasOne(v => v.Patient)
                .WithMany(p => p.Visitations)
                .HasForeignKey(v => v.PatientId);

            });

            modelBuilder.Entity<Diagnose>(entity =>
            {
                entity.Property(v => v.Name).IsUnicode();
                entity.Property(v => v.Comments).IsUnicode();

                entity
                .HasOne(d => d.Patient)
                .WithMany(p => p.Diagnoses)
                .HasForeignKey(d => d.PatientId);

            });

            modelBuilder.Entity<PatientMedicament>(entity =>
            {
                entity
                .HasKey(x => new { x.PatientId, x.MedicamentId });

            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(x => x.FirstName).IsUnicode();
                entity.Property(x => x.LastName).IsUnicode();
                entity.Property(x => x.Address).IsUnicode();
                entity.Property(x => x.Email).IsUnicode(false);

                entity
                .HasMany(x => x.Prescriptions)
                .WithOne(x => x.Patient)
                .HasForeignKey(x => x.PatientId);

            });

            modelBuilder.Entity<Medicament>(entity =>
            {
                entity.Property(x => x.Name).IsUnicode();

                entity
                .HasMany(x => x.Prescriptions)
                .WithOne(x => x.Medicament)
                .HasForeignKey(x => x.MedicamentId);

            });

            modelBuilder.Entity<Doctor>(entity =>
            {
                entity.Property(d => d.Name).IsUnicode();
                entity.Property(d => d.Specialty).IsUnicode();

                entity
                .HasMany(d => d.Visitations)
                .WithOne(v => v.Doctor)
                .HasForeignKey(d => d.DoctorId);

            });
        }
    }
}
