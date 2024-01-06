using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Core.Entities;

namespace Twitter.DataAccess.Configurations
{
    public class PostConfig : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasOne(p => p.Owner).WithMany(u => u.Posts);
            builder.HasMany(p => p.Medias).WithOne(m => m.Post);
            
            builder.Property(p=>p.Body).HasMaxLength(280);
        }
    }
}
