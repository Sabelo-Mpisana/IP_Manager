using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace IP_Manager.Models
{
    public class IP_Assigned
    {
        [Key]
        public int IPID { get; set; }
        public int IpAddress { get; set; }
        public char status { get; set; }
        public DateOnly dateReleased { get; set; }

        public int? subnetID { get; set; }
        public Subnet subnets { get; set; } = null!;

        public int? deviceID { get; set; }
        public Device device { get; set; } = null!;


        [NotMapped]
        public string IpAddressString => new IPAddress(BitConverter.GetBytes(IpAddress)).ToString();

    }
}
