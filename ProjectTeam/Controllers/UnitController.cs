using coreData.Data;
using coreData.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ProjectTeam.Controllers
{
 

    public class UnitController : Controller
    {
        readonly ApplicationDbContext Context;

        public UnitController(ApplicationDbContext Context)
        {
            this.Context = Context; 
        }

        public async Task< IActionResult> Index()
        {
            var result = await Context.Units.ToListAsync();

            return View(result);
        }


        public  IActionResult Create()
        {
         
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Create(Unit unit )
        {
            Context.Add(unit);
            await Context.SaveChangesAsync(); 

            return RedirectToAction("Index");
        }


        public async Task <IActionResult> Edit(int id )
        {
            var update = await Context.Units.FindAsync(id); 
            
            return View(update);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Unit unit)
        {
            Context.Units.Update(unit);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> Delete(int id)
        {
            var delete = await Context.Units.FindAsync(id);

            return View(delete);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Unit unit)
        {
            Context.Units.Remove(unit);
            await Context.SaveChangesAsync();
            return RedirectToAction("Index");


        }









    }
}
