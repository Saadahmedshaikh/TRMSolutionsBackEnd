using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class PrognosDBContext :DbContext
    {
        public virtual DbSet<Equipment> Equipment { get; set; }
    }
}