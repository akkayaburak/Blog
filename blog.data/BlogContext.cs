using blog.core.Models;
using blog.data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace blog.data
{
    public class BlogContext : DbContext
    {
        public  DbSet<Post> Posts { get; set; }
        public  DbSet<User> Users { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new PostConfiguration());
            builder
                .ApplyConfiguration(new UserConfiguration());
        }
    }
}
