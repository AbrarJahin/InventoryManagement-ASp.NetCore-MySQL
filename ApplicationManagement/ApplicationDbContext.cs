using ApplicationManagement.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

public class ApplicationDbContext : DbContext
{
    //List all tables here
    public DbSet<Advertisement> Advertisements { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryPerson> CountryPersons { get; set; }
    public DbSet<EducationResult> EducationResults { get; set; }
    public DbSet<Experience> Experiences { get; set; }
    public DbSet<JobCircular> JobCirculars { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Office> Offices { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Reference> References { get; set; }
    public DbSet<Research> Researches { get; set; }
    public DbSet<ResearchDegree> ResearchDegrees { get; set; }
    public DbSet<TeacherApplication> TeacherApplications { get; set; }
    public DbSet<Training> Trainings { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
: base(options)
    {}

    public override int SaveChanges()
    {
        AddTimestamps();
        return base.SaveChanges();
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        AddTimestamps();
        return base.SaveChanges(acceptAllChangesOnSuccess);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        AddTimestamps();
        return base.SaveChangesAsync(cancellationToken);
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
    {
        AddTimestamps();
        return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
    }

    //Fluent API to make Composite Key
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(e =>
        {
            e.HasAlternateKey(c => new { c.BengaliName });
            e.HasAlternateKey(c => new { c.EnglishName });
            e.HasAlternateKey(c => new { c.ShortName });
        });

        modelBuilder.Entity<CountryPerson>(cp =>
        {
            cp.HasOne(p => p.Person).WithMany(c => c.VisitedCountries).HasForeignKey(p => p.PersonID);
            cp.HasOne(c => c.Country).WithMany(p => p.Visitors).HasForeignKey(c => c.CountryID);

            //For Ensuring only 1 entry per person
            cp.HasAlternateKey(c => new { c.CountryID, c.PersonID });
        });
    }

    private void AddTimestamps()
    {
        var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity && (x.State == EntityState.Added || x.State == EntityState.Modified));

        /*
        var currentUsername = !string.IsNullOrEmpty(System.Web.HttpContext.Current?.User?.Identity?.Id)
            ? HttpContext.Current.User.Identity.Id
            : -1;   //-1 for Anonimous
        */
        long currentUserId = -1;    //-1 for Anonimous

        foreach (var entity in entities)
        {
            //Should store location also from here- http://www.jerriepelser.com/blog/aspnetcore-geo-location-from-ip-address/

            if (entity.State == EntityState.Added)
            {
                ((BaseEntity)entity.Entity).CreatedTime = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).CreatorUserId = currentUserId;
                //((BaseEntity)entity.Entity).CreatorIPAddress = _httpContext.Connection.RemoteIpAddress.ToString();
            }
            else
            {
                this.Entry(((BaseEntity)entity.Entity)).Property(e => e.CreatedTime).IsModified = false;
                this.Entry(((BaseEntity)entity.Entity)).Property(e => e.CreatorUserId).IsModified = false;
                //this.Entry(((BaseEntity)entity.Entity)).Property(e => e.CreatorUserId).CreatorIPAddress = false;

                //Set updated At time
                ((BaseEntity)entity.Entity).LastModifiedTime = DateTime.UtcNow;
                ((BaseEntity)entity.Entity).LastModifireUserId = currentUserId;
                //((BaseEntity)entity.Entity).LastModifireIPAddress = _httpContext.Connection.RemoteIpAddress.ToString();
            }
        }
    }

    internal void Seed(IApplicationBuilder app)
    {
        // Get an instance of the DbContext from the DI container
        using (ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>())
        {
            //... perform other seed operations
            context.AddRange(
                new Country { BengaliName = "England", EnglishName = "England", ShortName = "en" },
                new Country { BengaliName = "France", EnglishName = "France", ShortName = "fr" },
                new Country { BengaliName = "Bangladesh", EnglishName = "Bangladesh", ShortName = "bd" }
            );
            context.SaveChangesAsync();
        }
    }
}