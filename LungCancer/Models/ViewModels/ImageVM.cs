using LungCancer.Models.DB;

namespace LungCancer.Models.ViewModels
{
    public partial class ImageVM
    {
        public int ?Id { get; set; }
       
        public string? FileName { get; set; }
        public List<byte>? FilePath { get; set; }
        public DateTime? UploadDate { get; set; }
        public int? UserId { get; set; }
        public int? PatientId { get; set; }

        public virtual Patient? Patient { get; set; }
        
        public virtual User? User { get; set; }
    }
}
