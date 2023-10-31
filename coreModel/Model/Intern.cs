using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreData.Model
{
    public class Intern
    {
        [Key]
        public int InternID { get; set; }
        public string InternNameSurname { get; set; }

        public string InternDateofBirth { get; set; }

        public string InternGender { get; set; }

        public ICollection<Personel> Personel { get; set; }




    }
}
