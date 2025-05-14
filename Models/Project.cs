using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace IP_Manager.Models
{
    public class Project
    {
        [Key]
        public int projectID { get; set; }
        public string projectName { get; set; }
        public string projectDescription { get; set; }
        public char status { get; set; }
        public string location { get; set; }
        public DateOnly startDate { get; set; }
        public DateOnly endDate { get; set; }

       public int? clientID { get; set; }

        [BindNever]
        public Client? Client { get; set; } = null!;

        public ICollection<Subnet>? Subnets { get; } = new List<Subnet>();
             
    }
}
