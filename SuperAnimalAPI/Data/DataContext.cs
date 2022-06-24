using Microsoft.EntityFrameworkCore;

namespace SuperAnimalAPI.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<SuperAnimal> SuperAnimals { get; set; }
    }
}
