using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreData.Model
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        public string PersonelNameSurname { get; set; }
        public string PersonelGender { get; set; }
        public string PersonelStartDate { get; set; }

        public decimal Salary { get; set; }

        [ForeignKey("Role")]
        public int RoleID { get; set; }

        public Role Roles { get; set; }

        [ForeignKey("Unit")]
        public int UnitID { get; set; }

        public Unit Units { get; set; }

        public ICollection<Intern> Interns { get; set; }
        public ICollection<Project> Projects { get; set; }



    }
}
