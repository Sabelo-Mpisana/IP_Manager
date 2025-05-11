using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using IP_Manager.Data;
using IP_Manager.Models;

namespace IP_Manager.Controllers
{
    public class ClientsController : Controller
    {
        public readonly DbsContext _context;

        public ClientsController(DbsContext context)
        {
            _context = context;
        }

        // GET: Clients
        public async Task<IActionResult> DashBoard()
        {
            return View(await _context.Clients.ToListAsync());
        }



        

      
       

        


    }
}
