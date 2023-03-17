using Core.Entity;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class ThePerfectDotNetTemplateDbContext : DbContext
{
    public ThePerfectDotNetTemplateDbContext(DbContextOptions<ThePerfectDotNetTemplateDbContext> options)
        : base(options)
    {
    }

    public DbSet<UserEntity> Users { get; set; }
}