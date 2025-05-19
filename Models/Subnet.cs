using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IP_Manager.Models
{
    public class Subnet
    {
        [Key]
        public int subnetID { get; set; }

        [NotMapped]
        [Required]
        [Display(Name = "IPV4 Address")]
        [RegularExpression(@"^(?:\d{1,3}\.){3}\d{1,3}$", ErrorMessage = "Invalid IPv4 address")]
        public string IPV4String { get; set; }

        [NotMapped]
        [Required]
        [Display(Name ="Subnet Mask")]
        [RegularExpression(@"^(?:\d{1,3}\.){3}\d{1,3}$", ErrorMessage = "Invalid subnet mask")]
        public string maskString {  get; set; }


        public DateOnly createdAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public byte[] IPV4 {  get; set; }

        [Column(TypeName ="binary(4)")]
        public byte[] Mask { get; set; }


        public int? projectID { get; set; }
        public Project? projects { get; set; }

        public ICollection<IP_Assigned>? iP_Assignements { get;} = new List<IP_Assigned>();
    }
}
