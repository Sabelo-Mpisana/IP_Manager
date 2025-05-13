using IP_Manager.Data;
using IP_Manager.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> createProject(Project project)
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

                var clientJson = TempData["clientData"]?.ToString();
                var client = JsonConvert.DeserializeObject<Client>(clientJson);

                _dbsContext.Clients.Add(client);
                await _dbsContext.SaveChangesAsync();


                project.clientID = client.clientID;
                _dbsContext.Projects.Add(project);
                await _dbsContext.SaveChangesAsync();

                return RedirectToAction("Landing", "Clients");

            }

            return View(project);
        }

    }
}
