using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreData.Model
{
    public class Unit
    {
        [Key]
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public int NumberofStaff { get; set; }



    }
}
