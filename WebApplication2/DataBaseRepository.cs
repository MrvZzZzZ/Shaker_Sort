using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public class DataBaseRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<DataBase> Numbers
        {
            get { return context.Numbers; }
        }
    }
}