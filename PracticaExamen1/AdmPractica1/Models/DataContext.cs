using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AdmPractica1.Models
{
    public class DataContext:DbContext


    {
        public DataContext():base("DefaultConnection")
        {

        }

        public System.Data.Entity.DbSet<AdmPractica1.Models.lewensztain> lewensztains { get; set; }
    }


} 
