<<<<<<< Updated upstream
﻿using System.Collections.Generic;
=======
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
>>>>>>> Stashed changes

namespace WebApplication2
{
    public class DataBase
    {
<<<<<<< Updated upstream
        public string _conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Михаил\\Documents\\NumbersLists.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True";
        public int Id { get; private set; }
        public bool SortStatus { get; private set; }
        public List<int> Numbers { get; private set; }
    }

=======
        public int Id { get; private set; }
        public int ListSize {  get; private set; }
        public bool SortStatuc { get; private set; }
        public List<int> Numbers {  get; private set; }
    }

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<DataBase> DataBases { get; private set; }
    }
>>>>>>> Stashed changes
}