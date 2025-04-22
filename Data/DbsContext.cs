using Microsoft.EntityFrameworkCore;
namespace IP_Manager.Data
{
    public class DbsContext:DbContext
    {
        public DbsContext(DbContextOptions<DbsContext> options) : base(options) 
        {
            
        }


    }
}
