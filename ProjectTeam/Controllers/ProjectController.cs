using coreData.Data;
using coreData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectTeam.Controllers
{
    public class ProjectController : Controller
    {
        public readonly ApplicationDbContext context;
        public ProjectController(ApplicationDbContext context)
        {
            this.context = context;
        }



        public IActionResult Index()
        {
            var result = context.Projects.ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            

            return View();
        }


        [HttpPost]
        public IActionResult Create(Project project)
        {
            context.Projects.Add(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var update = context.Projects.Find(id);

            return View(update);
        }


        [HttpPost]
        public IActionResult Edit(Project project)
        {
            context.Projects.Update(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            var delete = context.Projects.Find(id);

            return View(delete);
        }


        [HttpPost]
        public IActionResult Delete(Project project)
        {
            context.Projects.Remove(project);
            context.SaveChanges();

            return RedirectToAction("Index");
        }





    }
}
