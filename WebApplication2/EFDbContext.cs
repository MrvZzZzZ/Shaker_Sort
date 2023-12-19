using System.Data.Entity;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public class EFDbContext : DbContext
    {
        public DbSet<DataBase> Numbers { get; set; }
    }
}