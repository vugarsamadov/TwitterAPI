using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.DataAccess.DbContexts
{
    public class ApplicationDbContext : IdentityDbContext<User,IdentityRole<int>,int>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        {
        }


        
        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in this.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Added)
                {
                    if(entry.Entity is IBaseEntity entity)
                    {
                        entity.CreatedAt = DateTime.Now;
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
                else if (entry.State == EntityState.Modified)
                {
                    if (entry.Entity is IBaseEntity entity)
                    {
                        entity.ModifiedAt = DateTime.Now;
                    }
                }
                else if (entry.State == EntityState.Deleted)
                {
                    if (entry.Entity is IBaseEntity entity)
                    {
                        entity.Delete();
                    }
                }
            }
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

    }
}
