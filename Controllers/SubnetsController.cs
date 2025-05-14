using IP_Manager.Data;
using IP_Manager.Models;
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


        //[HttpPost]
        //public IActionResult Create(string IPV4String, string MaskString)
        //{
        //    try
        //    {
        //        var subnet = new Subnet
        //        {
        //            IPV4 = ConvertIPv4ToInt(IPV4String),
        //            mask = MaskString, // you can also convert this to int
        //            createdAt = DateOnly.FromDateTime(DateTime.Now)
        //        };

        //        _context.Subnets.Add(subnet);
        //        _context.SaveChanges();

        //        return RedirectToAction("Index");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle invalid input here
        //        ModelState.AddModelError("", "Invalid IP address");
        //        return View();
        //    }
        //}

        //private int ConvertIPv4ToInt(string ip)
        //{
        //    var bytes = System.Net.IPAddress.Parse(ip).GetAddressBytes();
        //    if (BitConverter.IsLittleEndian)
        //        Array.Reverse(bytes);
        //    return BitConverter.ToInt32(bytes, 0);
        //}

    }
}
