using Microsoft.EntityFrameworkCore;

namespace FormulaOne.API.Models
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>options):base(options)
        {
            
        }

        public DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Acheivement> Acheives { get; set; }
        public DbSet<Event> Events { get;set; }
        public virtual DbSet<Ticket> Ticket { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Specify the relationship between the entities

            modelBuilder.Entity<Acheivement>(entity =>
            {
                entity.HasOne(d => d.Driver)
                .WithMany(s => s.Acheivements)
                .HasForeignKey(s => s.DriverId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_Acheivement_Driver");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasMany(s => s.Tickets)
                .WithOne()
                .HasForeignKey(t => t.EventId)
                .IsRequired();

                var demoEvent = new Event()
                {
                    Id = 1,
                    Location = "Silverstone",
                    Name = "British GrandPrix"
                };
                

                entity.HasData(demoEvent);
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                var ticket = Enumerable.Range(1, 30)
                .Select(id => new Ticket()
                {
                    Id=id,
                    EventDate = DateTime.UtcNow.AddDays(20),
                    Price=100,
                     Status=1,
                     EventId=1,
                     TicketLevel="Bronze"
                });


                entity.HasData(ticket);
            });
        }
    }
}
