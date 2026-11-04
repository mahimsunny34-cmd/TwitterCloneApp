using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastratcure.Persistance
{
    public class TwitterCloneDbContext: DbContext
    {
        public TwitterCloneDbContext(DbContextOptions<TwitterCloneDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TwitterCloneDbContext).Assembly);
        }
    }
}
