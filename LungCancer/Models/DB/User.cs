using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    public partial class User
    {
        public User()
        {
            Images = new HashSet<Image>();
            Predictions = new HashSet<Prediction>();
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
        [StringLength(50)]
        [Unicode(false)]
        public string? UserRole { get; set; }

        [InverseProperty("User")]
        public virtual ICollection<Image> Images { get; set; }
        [InverseProperty("User")]
        public virtual ICollection<Prediction> Predictions { get; set; }
    }
}
