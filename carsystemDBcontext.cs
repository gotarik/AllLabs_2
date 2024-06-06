using Microsoft.EntityFrameworkCore;

namespace AllLabs_2
{
    public class carsystemDBcontext : DbContext
    {
        public carsystemDBcontext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server = DESKTOP-GPO9ANR; Database = Rental; Trusted_Connection = SSPI; Encrypt = false; TrustServerCertificate = true");
            }
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<RentalSystem> RentalSystems { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RentalSystem>(rs =>
            {
                rs.HasMany(r => r.Clients)
                  .WithOne(c => c.RentalSystems)
                  .HasForeignKey(c => c.RentalSystemIdFK);  

                rs.HasMany(r => r.Administrators)
                  .WithOne(a => a.RentalSystems)
                  .HasForeignKey(a => a.RentalSystemIdFK);  

                rs.HasMany(r => r.Cars)
                  .WithOne(c => c.RentalSystems)
                  .HasForeignKey(c => c.RentalSystemIdFK); 
            });
            modelBuilder.Entity<Client>(c =>
            {
                c.HasOne(c => c.RentalSystems)
                 .WithMany(rs => rs.Clients)
                 .HasForeignKey(c => c.RentalSystemIdFK)
                 .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Entity<Order>(o =>
            {
                o.HasOne(o => o.Client)
                  .WithMany(cl => cl.Orders)
                  .HasForeignKey(o => o.ClientIdFK);  

                o.HasOne(o => o.Car)
                  .WithOne(car => car.Order)
                  .HasForeignKey<Order>(o => o.CarIdFK);
            });
            modelBuilder.Entity<Administrator>(a =>
            {
                a.HasOne(a => a.RentalSystems)
                 .WithMany(rs => rs.Administrators)
                 .HasForeignKey(a => a.RentalSystemIdFK)
                 .OnDelete(DeleteBehavior.NoAction);
            });
            modelBuilder.Ignore<Person>();
        }
    }
}
