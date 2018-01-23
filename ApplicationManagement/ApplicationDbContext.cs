using ApplicationManagement.DbModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class ApplicationDbContext :IdentityDbContext<User, UserRole, long>  //ID Type = long
{
    //Identity Tables
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }

    //Add all DB tablesOnModelCreating
    public DbSet<Entry> Entries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
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
        modelBuilder.Entity<User>(u =>
        {
            u.HasAlternateKey(user => new { user.UserName });   //Add unique user name for all
        });

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        base.OnModelCreating(modelBuilder);
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
                
            );
            context.SaveChangesAsync();
        }
    }
}