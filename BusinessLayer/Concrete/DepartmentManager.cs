﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }

        public void TAdd(Department t)
        {
            _departmentDal.Insert(t);
        }

        public void TDelete(Department t)
        {
            _departmentDal.Delete(t);
        }

        public Department TGetById(int id)
        {
            return _departmentDal.GetById(id);
        }

        public List<Department> TGetList()
        {
            return _departmentDal.GetList();
        }

        public void TUpdate(Department t)
        {
            _departmentDal.Update(t);
        }
    }
}
