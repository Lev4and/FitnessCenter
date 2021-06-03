using FitnessCenter.Model.Database.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessCenter.Model.Database
{
    public class FitnessCenterDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Blog> Blog { get; set; }

        public DbSet<BlogComment> BlogComments { get; set; }
        
        public DbSet<BlogCommentAnswer> BlogCommentAnswers { get; set; }
        
        public DbSet<Client> Clients { get; set; }
        
        public DbSet<ClientService> ClientServices { get; set; }
        
        public DbSet<Gender> Genders { get; set; }
        
        public DbSet<Service> Services { get; set; }

        public DbSet<ServiceCategory> ServiceCategories { get; set; }
        
        public DbSet<Testimonial> Testimonials { get; set; }
        
        public DbSet<Trainer> Trainers { get; set; }
        
        public DbSet<TrainerCategory> TrainerCategories { get; set; }

        public FitnessCenterDbContext(DbContextOptions<FitnessCenterDbContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-9CDGA5B;Database=FitnessCenter;User ID=sa;Password=sa;Trusted_Connection=True;", b => b.MigrationsAssembly("FitnessCenter.AspNetCore"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "B867520A-92DB-4658-BE39-84DA53A601C0",
                Name = "Администратор",
                NormalizedName = "АДМИНИСТРАТОР"
            });

            builder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "21F7B496-C675-4E8A-A34C-FC5EC0762FDB",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "ekaterina.arkhireeva.2001@gmail.com",
                NormalizedEmail = "EKATERINA.ARKHIREEVA.2001@GMAIL.COM",
                EmailConfirmed = true,
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "EkaterinaArkhireeva05032001"),
                SecurityStamp = string.Empty
            });

            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "B867520A-92DB-4658-BE39-84DA53A601C0",
                UserId = "21F7B496-C675-4E8A-A34C-FC5EC0762FDB"
            });

            builder.Entity<Blog>()
                .HasMany(blog => blog.Comments)
                .WithOne(comment => comment.Blog)
                .HasForeignKey(comment => comment.BlogId);

            builder.Entity<BlogComment>()
                .HasMany(comment => comment.Answers)
                .WithOne(answer => answer.Comment)
                .HasForeignKey(answer => answer.CommentId);

            builder.Entity<Client>()
                .HasOne(client => client.Testimonial)
                .WithOne(testimonial => testimonial.Client)
                .HasForeignKey<Testimonial>(testimonial => testimonial.ClientId);

            builder.Entity<Client>()
                .HasMany(client => client.Comments)
                .WithOne(comment => comment.Client)
                .HasForeignKey(comment => comment.ClientId);

            builder.Entity<Client>()
                .HasMany(client => client.Answers)
                .WithOne(answer => answer.Client)
                .HasForeignKey(answer => answer.ClientId);
            
            builder.Entity<Client>()
                .HasMany(client => client.Services)
                .WithOne(service => service.Client)
                .HasForeignKey(service => service.ClientId);

            builder.Entity<Gender>()
                .HasMany(gender => gender.Clients)
                .WithOne(client => client.Gender)
                .HasForeignKey(client => client.GenderId);
            
            builder.Entity<Gender>()
                .HasMany(gender => gender.Trainers)
                .WithOne(trainers => trainers.Gender)
                .HasForeignKey(trainers => trainers.GenderId);

            builder.Entity<TrainerCategory>()
                .HasMany(category => category.Trainers)
                .WithOne(trainer => trainer.Category)
                .HasForeignKey(trainer => trainer.CategoryId);

            builder.Entity<Service>()
                .HasMany(service => service.ClientServices)
                .WithOne(client => client.Service)
                .HasForeignKey(client => client.ServiceId);

            builder.Entity<ServiceCategory>()
                .HasMany(category => category.Services)
                .WithOne(service => service.Category)
                .HasForeignKey(service => service.CategoryId);
        }
    }
}
