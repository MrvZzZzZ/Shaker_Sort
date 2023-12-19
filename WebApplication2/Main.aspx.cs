using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace WebApplication2
{
    public partial class Main : System.Web.UI.Page
    {
        private DataBaseRepository repository = new DataBaseRepository();

        public IEnumerable<DataBase> GetNumbers()
        {
            return repository.Numbers;
        }

        public void Page_Load(object sender, EventArgs e)
        {

        }

        public void RunSort()
        { 
           
        }
    }
}