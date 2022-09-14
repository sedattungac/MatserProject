using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfPersonalDal : GenericRepository<Personal>, IPersonalDal
    {
        public List<Personal> GetPersonalWithDepartment()
        {
            using (var c = new Context())
            {
                return c.Personals.Include(x => x.Department).ToList();
            }
        }
    }
}
