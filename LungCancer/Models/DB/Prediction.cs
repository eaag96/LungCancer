using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    public partial class Prediction
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        [Unicode(false)]
        public string? Result { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? PredictionDate { get; set; }
        public int? ImageId { get; set; }
        public int? DoctorId { get; set; }
        public int? UserId { get; set; }
        public int? PrescriptionId { get; set; }

        [ForeignKey("DoctorId")]
        [InverseProperty("Predictions")]
        public virtual Doctor? Doctor { get; set; }
        [ForeignKey("ImageId")]
        [InverseProperty("Predictions")]
        public virtual Image? Image { get; set; }
        [ForeignKey("PrescriptionId")]
        [InverseProperty("Predictions")]
        public virtual Prescription? Prescription { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Predictions")]
        public virtual User? User { get; set; }
    }
}
