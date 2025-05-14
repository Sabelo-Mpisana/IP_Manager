using IP_Manager.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IP_Manager.Controllers
{
    public class SubnetsController : Controller
    {
        public readonly DbsContext _dbsContext;

        public SubnetsController(DbsContext dbsContext)
        {
            _dbsContext = dbsContext;
        }

        public async Task<IActionResult> subnetList()
        {
            return View( await _dbsContext.Subnet.ToListAsync());
        }



    }
}
