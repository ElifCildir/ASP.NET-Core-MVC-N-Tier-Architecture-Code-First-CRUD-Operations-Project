using coreData.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreModel.Model.viewModel
{
    public class PersRoleViewModel
    {
        public int PersonelID { get; set; }
        public string PersonelNameSurname { get; set; }
        public string PersonelGender { get; set; }
        public string PersonelStartDate { get; set; }

        public decimal Salary { get; set; }

        [ForeignKey("Unit")]
        public int UnitID { get; set; }

        public Unit Units { get; set; }
        public int RoleID { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }


    }
}
