using blog.core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace blog.data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder
                .HasKey(m => m.Id);
            builder
                .Property(m => m.Id)
                .UseIdentityColumn();
            builder
                .Property(m => m.Context)
                .IsRequired()
                .HasMaxLength(180);
            builder
                .HasOne(m => m.User)
                .WithMany(a => a.Posts)
                .HasForeignKey(m => m.UserId);
            builder
                .ToTable("Posts");
        }
    }
}
