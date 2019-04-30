using System;
using System.Data.Entity;

namespace CharacterDevelopment.Data
{
    public interface IApplicationDbContext : IDisposable
    {
        DbSet<Post> Posts { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Skill> Skills { get; set; }
        int SaveChanges();
        void MarkAsModified(object model);
    }
}
