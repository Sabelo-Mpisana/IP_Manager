using System.ComponentModel.DataAnnotations;

namespace IP_Manager.Models
{
    public class IP_Assigned
    {
        [Key]
        public int IPID { get; set; }
        public string ipAddress { get; set; }
        public char status { get; set; }
        public DateOnly dateReleased { get; set; }

        public int subnetID { get; set; }
        public Subnet subnets { get; set; } = null!;

        public int deviceID { get; set; }
        public Device device { get; set; } = null!;
    }
}
