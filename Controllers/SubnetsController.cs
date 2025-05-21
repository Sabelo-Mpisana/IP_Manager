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

        public async Task<IActionResult> subnetList(int projectId)
        {
            var viewModel = new subnetListViewModel
            {
               

                newSubnet = new Subnet {projectID = projectId}

            };
            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> subnetList(subnetListViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        Console.WriteLine(error.ErrorMessage); // or log it
                //    }
                //}

                //var projectJson = TempData["projectData"]?.ToString();
                //var project = JsonConvert.DeserializeObject<Project>(projectJson);

                //viewModel.newSubnet.IPV4 = IPAddress.Parse(viewModel.newSubnet.IPV4String).GetAddressBytes();
                //viewModel.newSubnet.Mask = IPAddress.Parse(viewModel.newSubnet.maskString).GetAddressBytes();


                //viewModel.newSubnet.projectID = project.projectID;
                //_dbsContext.Subnet.Add(viewModel.newSubnet);
                //await _dbsContext.SaveChangesAsync();

                //return RedirectToAction("subnetList","Subnets");

                var projectId = HttpContext.Session.GetInt32("ProjectID");

                try
                {
                    //viewModel.newSubnet.projectID = projectId.Value;
                    viewModel.newSubnet.projectID = null;
                    viewModel.newSubnet.IPV4 = IPAddress.Parse(viewModel.newSubnet.IPV4String).GetAddressBytes();
                    viewModel.newSubnet.Mask = IPAddress.Parse(viewModel.newSubnet.maskString).GetAddressBytes();

                    _dbsContext.Subnet.Add(viewModel.newSubnet);
                    await _dbsContext.SaveChangesAsync();

                    return RedirectToAction("subnetList", new { projectId = viewModel.newSubnet.projectID });
                }
                catch
                {
                    ModelState.AddModelError("", "Invalid IP address or mask format.");
                }


            }
            else
            {

            }

            return View(viewModel);

        }

    }
}
