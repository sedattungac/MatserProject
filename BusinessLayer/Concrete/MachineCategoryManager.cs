using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MachineCategoryManager : IMachineCategoryService
    {
        IMachineCategoryDal _machineCategoryDal;

        public MachineCategoryManager(IMachineCategoryDal machineCategoryDal)
        {
            _machineCategoryDal = machineCategoryDal;
        }

        public void TAdd(MachineCategory t)
        {
            _machineCategoryDal.Insert(t);
        }

        public void TDelete(MachineCategory t)
        {
            _machineCategoryDal.Delete(t);
        }

        public MachineCategory TGetById(int id)
        {
            return _machineCategoryDal.GetById(id);
        }

        public List<MachineCategory> TGetList()
        {
            return _machineCategoryDal.GetList();
        }

        public void TUpdate(MachineCategory t)
        {
            _machineCategoryDal.Update(t);
        }
    }
}
