using IP_Manager.Data;
using IP_Manager.Models;
using IP_Manager.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace IP_Manager.Controllers
{
    public class ProjectsController : Controller
    {
        public readonly DbsContext _dbsContext;

        public ProjectsController(DbsContext dbsContext)
        {
            _dbsContext = dbsContext;
        }



        public async Task<IActionResult> createProject()
        {
            if (TempData["clientData"] == null)
            {
                return RedirectToAction("CreateClient");
            }

            TempData.Keep("clientData");

            return View();
        }

        //Creating a project 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createProject(Models.Project project)
        {
            if(ModelState.IsValid)
            {

                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        Console.WriteLine(error.ErrorMessage); // or log it
                    }
                }

                var clientJson = TempData["projectData"]?.ToString();
                var client = JsonConvert.DeserializeObject<Client>(clientJson);

                _dbsContext.Clients.Add(client);
                await _dbsContext.SaveChangesAsync();


                project.clientID = client.clientID;
                _dbsContext.Projects.Add(project);
                await _dbsContext.SaveChangesAsync();

                TempData["projectData"] = JsonConvert.SerializeObject(project);

                return RedirectToAction("Landing", "Clients");

            }

            return View(project);
        }

        //Viewing projects 
        public async Task<IActionResult> projectList(int id)
        {
            var ViewModel = await (from Project in _dbsContext.Projects
                                      // where (Patient.Status == "A")
                                      

                                       select new subnetListViewModel
                                       {
                                           ProjectID = id,

                                       }).ToListAsync();

            // return View( await _dbsContext.Projects.ToListAsync());
            return RedirectToAction("subnetList", "Subnets");
        }

        


    }
}
