using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LungCancer.Models.DB;

namespace LungCancer.Models.DbContextDir
{
    public partial class LungCancerContext : DbContext
    {
        public LungCancerContext()
        {
        }

        public LungCancerContext(DbContextOptions<LungCancerContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Diagnosis> Diagnoses { get; set; } = null!;
        public virtual DbSet<Doctor> Doctors { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Patient> Patients { get; set; } = null!;
        public virtual DbSet<Prediction> Predictions { get; set; } = null!;
        public virtual DbSet<Prescription> Prescriptions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-CQ8LE47\\SQLEXPRESS;Initial Catalog=LungCancer;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.HasOne(d => d.Patient)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.PatientId)
                    .HasConstraintName("FK__Images__PatientI__300424B4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Images__UserId__30F848ED");
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Patients)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Patients_Doctors");
            });

            modelBuilder.Entity<Prediction>(entity =>
            {
                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Predictions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK_Predictions_Doctors");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Predictions)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Predictions_Images");

                entity.HasOne(d => d.Prescription)
                    .WithMany(p => p.Predictions)
                    .HasForeignKey(d => d.PrescriptionId)
                    .HasConstraintName("FK_Predictions_Prescription");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Predictions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Predictions_Users");
            });

            modelBuilder.Entity<Prescription>(entity =>
            {
                entity.HasOne(d => d.Diagnosis)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DiagnosisId)
                    .HasConstraintName("FK__Prescript__Diagn__3E52440B");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.Prescriptions)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("FK__Prescript__Docto__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
