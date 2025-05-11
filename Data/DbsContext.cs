using Microsoft.EntityFrameworkCore;
using IP_Manager.Models;

namespace IP_Manager.Data
{
    public class DbsContext:DbContext
    {
        public DbsContext(DbContextOptions<DbsContext> options) : base(options) 
        {
            
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Subnet> SubnetS { get; set; }
        public DbSet<IP_Assigned> IP_Assigned { get; set; }
        public DbSet<Device> Devices { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.Client)      //one project has one client
                .WithMany(c => c.projects)          // one client has many projects 
                .HasForeignKey(p => p.clientID);    //use clientID as the foreign Key 

            modelBuilder.Entity<Subnet>()
                .HasOne(s => s.projects)
                .WithMany(p => p.Subnets)
                .HasForeignKey(s => s.projectID);

            modelBuilder.Entity<IP_Assigned>()
                .HasOne(a => a.subnets)
                .WithMany(s => s.iP_Assignements)
                .HasForeignKey(a => a.subnetID);
                
            modelBuilder.Entity<Device>()
                .HasOne(d => d.IP_assined)
                .WithOne(a => a.device)
                .HasForeignKey<IP_Assigned>(a => a.deviceID);
        }


    }
}
