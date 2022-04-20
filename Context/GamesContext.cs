using Microsoft.EntityFrameworkCore;
using TEST_CRUD.Entities;

namespace TEST_CRUD.Context //Se define que este sector sera un contexto
{
    public class GamesContext : DbContext { // Se define que sera un contexto de DB
    
    public GamesContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Games> Games { get; set; }

        public DbSet<Dropdown> Dropdown { get; set; }

        public DbSet<Dropdown2> Dropdown2 { get; set; }

    }
}
