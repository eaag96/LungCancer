using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    [Table("Prescription")]
    public partial class Prescription
    {
        public Prescription()
        {
            Predictions = new HashSet<Prediction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? MedicineName { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Dosage { get; set; }
        public int? DiagnosisId { get; set; }
        public int? DoctorId { get; set; }

        [ForeignKey("DiagnosisId")]
        [InverseProperty("Prescriptions")]
        public virtual Diagnosis? Diagnosis { get; set; }
        [ForeignKey("DoctorId")]
        [InverseProperty("Prescriptions")]
        public virtual Doctor? Doctor { get; set; }
        [InverseProperty("Prescription")]
        public virtual ICollection<Prediction> Predictions { get; set; }
    }
}
