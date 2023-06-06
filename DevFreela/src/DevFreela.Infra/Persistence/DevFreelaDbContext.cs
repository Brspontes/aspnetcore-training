using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection;

namespace DevFreela.Infra.Persistence
{
    public class DevFreelaDbContext : DbContext
    {
        public DevFreelaDbContext(DbContextOptions<DevFreelaDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<UserSkill> UserSkills { get; set; }
        public DbSet<ProjectsComments> ProjectsComments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
