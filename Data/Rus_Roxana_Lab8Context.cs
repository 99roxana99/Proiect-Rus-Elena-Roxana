using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Rus_Roxana_Lab8.Models;

namespace Rus_Roxana_Lab8.Data
{
    public class Rus_Roxana_Lab8Context : DbContext
    {
        public Rus_Roxana_Lab8Context (DbContextOptions<Rus_Roxana_Lab8Context> options)
            : base(options)
        {
        }

        public DbSet<Rus_Roxana_Lab8.Models.Book> Book { get; set; }

        public DbSet<Rus_Roxana_Lab8.Models.Publisher> Publisher { get; set; }

        public DbSet<Rus_Roxana_Lab8.Models.Category> Category { get; set; }
    }
}
