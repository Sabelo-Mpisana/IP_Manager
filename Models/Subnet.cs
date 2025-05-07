using System.ComponentModel.DataAnnotations;

namespace IP_Manager.Models
{
    public class Subnet
    {
        [Key]
        public int subnetID { get; set; }
        public string IPV4 { get; set; }
        public string musk {  get; set; }
        public DateOnly createdAt { get; set; }

        public int projectID { get; set; }
        public Project projects { get; set; }

        public ICollection<IP_Assigned> iP_Assignements { get;} = new List<IP_Assigned>();
    }
}
