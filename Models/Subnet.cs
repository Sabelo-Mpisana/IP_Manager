using System.ComponentModel.DataAnnotations;

namespace IP_Manager.Models
{
    public class Subnet
    {
        [Key]
        public int subnetID { get; set; }
        public int IPV4 { get; set; }
        public int mask {  get; set; }
        public DateOnly createdAt { get; set; } = DateOnly.FromDateTime(DateTime.Now);

        public int? projectID { get; set; }
        public Project projects { get; set; }

        public ICollection<IP_Assigned> iP_Assignements { get;} = new List<IP_Assigned>();
    }
}
