using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    public partial class Patient
    {
        public Patient()
        {
            Images = new HashSet<Image>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string UserName { get; set; } = null!;
        public int Age { get; set; }
        [StringLength(10)]
        [Unicode(false)]
        public string Sex { get; set; } = null!;
        [Unicode(false)]
        public string OtherInfo { get; set; } = null!;
        [Column("doctor_id")]
        public int? DoctorId { get; set; }

        [ForeignKey("DoctorId")]
        [InverseProperty("Patients")]
        public virtual Doctor? Doctor { get; set; }
        [InverseProperty("Patient")]
        public virtual ICollection<Image> Images { get; set; }
    }
}
