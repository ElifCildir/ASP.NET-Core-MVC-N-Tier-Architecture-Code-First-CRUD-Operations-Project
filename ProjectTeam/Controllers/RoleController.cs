using coreData.Data;
using coreData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjectTeam.Controllers
{
   



    public class RoleController : Controller

    {
        public readonly ApplicationDbContext Context;

        public RoleController(ApplicationDbContext Context)
        {
            this.Context = Context;
        }




        public async Task< IActionResult> Index()
        {
            var result = await Context.Roles.ToListAsync();


            return View(result);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Role role)
        { 
            Context.Add(role);
            await Context.SaveChangesAsync();


            return RedirectToAction("Index");
        }

        public async Task <IActionResult> Edit(int id)
        {
            var update = await Context.Roles.FindAsync(id);
            return View(update);
        }

        [HttpPost]
        public  async Task <IActionResult> Edit(Role role)
        {
            Context.Roles.Update(role);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");



            
        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await Context.Roles.FindAsync(id);
            return View(delete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Role role)
        {
            Context.Roles.Remove(role);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");




        }




    }
}
