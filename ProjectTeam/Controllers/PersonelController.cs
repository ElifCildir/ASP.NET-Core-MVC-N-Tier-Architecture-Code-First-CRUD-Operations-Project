using coreData.Data;
using coreData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ProjectTeam.Controllers
{
    public class PersonelController : Controller
    {
        readonly ApplicationDbContext Context;
        public PersonelController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }

        
        public IActionResult Index()
        {
            var result = Context.Personels.Include("Roles").Include("Units").Include("Projects").ToList();


            return View(result);
        }

      
        public IActionResult Create()
        {
            ViewData["RoleID"] = new SelectList(Context.Roles, "RoleID", "RoleName");

            ViewData["UnitID"] = new SelectList(Context.Units, "UnitID", "UnitName");

            ViewData["ProjectID"] = new SelectList(Context.Units, "ProjectID", "ProjectName");

            return View();

        }

        [HttpPost]
        public IActionResult Create(Personel personel)
        {
            Context.Add(personel);
            Context.SaveChanges();


            return RedirectToAction("Index");

        }

        public IActionResult Edit(int id )
        {
            ViewData["RoleID"] = new SelectList(Context.Roles, "RoleID", "RoleName");

            ViewData["UnitID"] = new SelectList(Context.Units, "UnitID", "UnitName");
            ViewData["ProjectID"] = new SelectList(Context.Units, "ProjectID", "ProjectName");

            var update = Context.Personels.Find(id);

            return View(update);

        }

        [HttpPost]
        public IActionResult Edit(Personel personel)
        {
            Context.Update(personel);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }


        public IActionResult Delete(int id)
        {
            ViewData["RoleID"] = new SelectList(Context.Roles, "RoleID", "RoleName");

            ViewData["UnitID"] = new SelectList(Context.Units, "UnitID", "UnitName");

            ViewData["ProjectID"] = new SelectList(Context.Units, "ProjectID", "ProjectName");

            var delete = Context.Personels.Find(id);

            return View(delete);

        }

        [HttpPost]
        public IActionResult Delete(Personel personel)
        {
            Context.Remove(personel);
            Context.SaveChanges();
            return RedirectToAction("Index");

        }




    }
}
