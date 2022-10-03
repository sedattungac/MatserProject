using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatserProject.Models.ListDataClass
{
    public class MachineListData
    {
        public List<Machine> MachineList { get; set; }
        public List<MachineCategory> MachineCategoryList { get; set; }
    }
}
