using Microsoft.EntityFrameworkCore;
using WebApplication1.Data.Entitis;

namespace WebApplication1.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base (options)    
        {

        }
        public  DbSet<Moovie> Moovies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MoovieCategory> MovieCategories{ get; set; }
        public DbSet<MoovieActor> MoovieActors { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Country> Countries { get; set; }

    }
}
