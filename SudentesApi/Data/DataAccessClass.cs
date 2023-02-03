using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SudentesApi.Data
{
    public class DataAccessClass : DbContext
    {
        public DataAccessClass(DbContextOptions<DataAccessClass> options) : base(options) { }

        public DbSet<Students> Student { get; set; }
        
    }
}
