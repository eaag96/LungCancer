using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    [Table("Diagnosis")]
    public partial class Diagnosis
    {
        public Diagnosis()
        {
            Prescriptions = new HashSet<Prescription>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? UserName { get; set; }
        [Unicode(false)]
        public string? OtherInfo { get; set; }

        [InverseProperty("Diagnosis")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
    }
}
