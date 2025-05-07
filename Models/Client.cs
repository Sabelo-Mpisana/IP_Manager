using System.ComponentModel.DataAnnotations;

namespace IP_Manager.Models
{
    public class Client
    {
        [Key]
       public int clientID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }   
        public string contactNO { get; set; }
        public string physicalAddress { get; set; }

        public ICollection<Project> projects { get; } = new List<Project>();
             
    }
}
