using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WPFLearn.Model;

namespace WPFLearn
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=BDLearn;Trusted_Connection=True;"); //Строка подключения к БД
        }
    }
}
