using IP_Manager.Models;

namespace IP_Manager.ViewModels
{
    public class subnetListViewModel
    {
        public IEnumerable<Subnet> subnetList {  get; set; }
        public Subnet newSubnet { get; set; }
    }
}
