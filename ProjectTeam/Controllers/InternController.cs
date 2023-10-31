using coreData.Data;
using coreData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectTeam.Controllers
{
   


    public class InternController : Controller
    {
        public readonly ApplicationDbContext context;

        public InternController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var result = context.Interns.ToList();

            return View(result);
        }

        public IActionResult Create()
        {
            

            return View();
        }

        [HttpPost]
        public IActionResult Create(Intern intern )
        {
            context.Add(intern);
            context.SaveChanges();

            return RedirectToAction("Index");
        }


        public IActionResult Edit(int id)
        {
            var update = context.Interns.Find(id);

            return View(update);
        }

        [HttpPost]
        public IActionResult Edit(Intern intern)
        {
            context.Update(intern);
           context.SaveChanges();


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var delete = context.Interns.Find(id);

            return View(delete);
        }

        [HttpPost]
        public IActionResult Delete(Intern intern)
        {
            context.Remove(intern);
            context.SaveChanges();


            return RedirectToAction("Index");
        }



    }
}
