using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Cors;
using DAL;

namespace Extension.User
{
   
   public  class User
    {
        public List<CompanyUser> getAllUsers()
        {
            using(var db = new TRMDbContext())
            {
               var temp= db.CompanyUser.ToList();
                return temp;
               
            }
        }
    }
}
