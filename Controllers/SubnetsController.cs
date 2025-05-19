using IP_Manager.Data;
using IP_Manager.Migrations;
using IP_Manager.Models;
using IP_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json;
using System.Net;

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
            var viewModel = new subnetListViewModel
            {
                subnetList = await _dbsContext.Subnet.ToListAsync(),
                newSubnet = new Subnet()

            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> subnetList(subnetListViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                var projectJson = TempData["projectData"]?.ToString();
                var project = JsonConvert.DeserializeObject<Project>(projectJson);

                viewModel.newSubnet.IPV4 = IPAddress.Parse(viewModel.newSubnet.IPV4String).GetAddressBytes();
                viewModel.newSubnet.Mask = IPAddress.Parse(viewModel.newSubnet.maskString).GetAddressBytes();


                viewModel.newSubnet.projectID = project.projectID;
                _dbsContext.Subnet.Add(viewModel.newSubnet);
                await _dbsContext.SaveChangesAsync();

                return RedirectToAction("subnetList","Subnets");

            }
            else
            {

            }

            return View(viewModel);

        }

    }
}
