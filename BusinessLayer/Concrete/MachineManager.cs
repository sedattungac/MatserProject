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
    public class MachineManager : IMachineService
    {
        IMachineDal _machineDal;

        public MachineManager(IMachineDal machineDal)
        {
            _machineDal = machineDal;
        }

        public void TAdd(Machine t)
        {
            _machineDal.Insert(t);
        }

        public void TDelete(Machine t)
        {
            _machineDal.Delete(t);
        }

        public Machine TGetById(int id)
        {
            return _machineDal.GetById(id);
        }

        public List<Machine> TGetList()
        {
            return _machineDal.GetList();
        }

        public void TUpdate(Machine t)
        {
            _machineDal.Update(t);
        }
    }
}
