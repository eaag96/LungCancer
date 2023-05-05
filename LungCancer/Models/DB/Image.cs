using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace LungCancer.Models.DB
{
    public partial class Image
    {
        public Image()
        {
            Predictions = new HashSet<Prediction>();
        }

        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        [Unicode(false)]
        public string? FileName { get; set; }
        public byte[]? FilePath { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UploadDate { get; set; }
        public int? UserId { get; set; }
        public int? PatientId { get; set; }

        [ForeignKey("PatientId")]
        [InverseProperty("Images")]
        public virtual Patient? Patient { get; set; }
        [ForeignKey("UserId")]
        [InverseProperty("Images")]
        public virtual User? User { get; set; }
        [InverseProperty("Image")]
        public virtual ICollection<Prediction> Predictions { get; set; }
    }
}
