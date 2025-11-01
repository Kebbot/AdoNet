using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AdoNet
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> Books => Set<Book>(); 
        public DbSet<Author> Authors => Set<Author>();
        //public DbSet<Books> Book { get; set; } = null!; // можно было и так
        public ApplicationContext() => Database.EnsureCreated(); // ГАРАНТИРУЕТ, что БД создана.
        //public ApplicationContext() => Database.EnsureDeleted(); // ГАРАНТИРУЕТ, что БД будет УДАЛЕНА .
        //public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .SetBasePath(Directory.GetCurrentDirectory())
                .Build();
           
            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
