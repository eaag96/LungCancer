using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    public partial class Doctor
    {
        public Doctor()
        {
            Patients = new HashSet<Patient>();
            Predictions = new HashSet<Prediction>();
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? UserName { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? UserEmail { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? UserPassword { get; set; }
        [Unicode(false)]
        public string? OtherInfo { get; set; }

        [InverseProperty("Doctor")]
        public virtual ICollection<Patient> Patients { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<Prediction> Predictions { get; set; }
        [InverseProperty("Doctor")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
