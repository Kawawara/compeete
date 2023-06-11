using Microsoft.EntityFrameworkCore;
using CompeeteData.Models;
using BC = BCrypt.Net.BCrypt;

namespace CompeeteData
{
    public class CompeeteDBContext : DbContext
    {
        public CompeeteDBContext(DbContextOptions<CompeeteDBContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Result> Results { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Constraint> Constraints { get; set; }
        public DbSet<Sport> Sports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasMany(c => c.Event).WithOne(c=>c.User);

            modelBuilder.Entity<Result>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Event>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Event>().HasMany(c => c.Tournaments).WithOne(c=>c.Event);

            modelBuilder.Entity<Tournament>().Property(c => c.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Tournament>().HasOne(c => c.Event).WithMany(c => c.Tournaments);

            modelBuilder.Entity<Constraint>().Property(c => c.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Sport>().Property(c => c.Id).ValueGeneratedOnAdd();

            User user = new User()
            {
                Birthdate = DateTime.Today.AddDays(-9999),
                Email = "nbc.theo@gmail.com",
                Id = 1,
                UserName = "Théo",
                Password = BC.HashPassword("test")
            };
            User user1 = new User()
            {
                Birthdate = DateTime.Today.AddDays(-9999),
                Email = "not.nbc.theo@gmail.com",
                Id = 2,
                UserName = "NotThéo",
                Password = BC.HashPassword("test")
            };
            modelBuilder.Entity<User>().HasData(
                    user, user1
                );
            modelBuilder.Entity<Sport>().HasData(
                new Sport() { Name = "Boxe", Id=1},
                new Sport() { Name = "Judo", Id = 2},
                new Sport() { Name = "Lutte", Id = 3},
                new Sport() { Name = "Natation", Id = 4},
                new Sport() { Name = "Badminton", Id = 5},
                new Sport() { Name = "Plongeon", Id = 6},
                new Sport() { Name = "Tennis", Id = 7},
                new Sport() { Name = "Tennis de Table", Id = 8},
                new Sport() { Name = "Cyclisme", Id = 9}
                );
            modelBuilder.Entity<Event>().HasData(
                new { Name = "next1", Id = 1, Start = DateTime.Today.AddDays(1), Adress = "123 rue du test", Description = "Un petit evenement bon pour les cochons", End = DateTime.Today.AddDays(2), UserId= user.Id},
                new { Name = "previous1", Id = 2, Start = DateTime.Today.AddDays(-2), Adress = "123 rue du test", Description = "Un petit evenement bon pour les cochons", End = DateTime.Today.AddDays(-1), UserId = user1.Id },
                new { Name = "next2", Id = 3, Start = DateTime.Today.AddDays(10), Adress = "123 rue du test", Description = "Un petit evenement bon pour les cochons", End = DateTime.Today.AddDays(11), UserId =  user.Id},
                new { Name = "previous2", Id = 4, Start = DateTime.Today.AddDays(-11), Adress = "123 rue du test", Description = "Un petit evenement bon pour les cochons", End = DateTime.Today.AddDays(-10), UserId =  user.Id}
                );
        }
    }
}