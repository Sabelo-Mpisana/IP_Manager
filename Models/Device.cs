using System.ComponentModel.DataAnnotations;

namespace IP_Manager.Models
{
    public class Device
    {
        [Key]
        public int deviceID { get; set; }
        public string deviceName { get; set; }
        public string macAddress { get; set; }
        public string deviceType { get; set; }
        public string location { get; set; }

        public IP_Assigned IP_assined { get; set; } = null!;
    }
}
