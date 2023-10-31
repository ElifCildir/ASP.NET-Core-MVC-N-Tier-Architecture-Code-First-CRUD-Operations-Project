using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreData.Model
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        public string ProjectName { get; set; }
        public string ProjecytStartDate { get; set; }
        public string ProjectEndDate { get; set; }



        public ICollection<Personel> Personels { get; set; }




    }
}