using coreData.Data;
using coreModel.Model.viewModel;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
using System.Linq;

namespace ProjectTeam.Controllers
{

    public class ReportsController : Controller

    {
        public readonly ApplicationDbContext context;
        public ReportsController(ApplicationDbContext context)
        {
            this.context = context;
        }


        public IActionResult Index()
        {
            var data = (from r in context.Roles
                        join p in context.Personels on r.RoleID equals p.RoleID
                        select new PersRoleViewModel
                        {
                           PersonelNameSurname = p.PersonelNameSurname,
                           RoleName =r.RoleName,
                           RoleDescription = r.RoleDescription
                        }).ToList();


            return View(data);  

        }
    }
}
