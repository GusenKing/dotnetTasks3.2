using Lesson1.GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.GraphQL;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Person> People { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Person>().HasData(new Person { Name = "Person 1", Age = 21, Job = "Job 1" },
            new Person { Name = "Person 2", Age = 21, Job = "Job 1" },
            new Person { Name = "Person 3", Age = 31, Job = "Job 1" },
            new Person { Name = "Person 4", Age = 41, Job = "Job 2" },
            new Person { Name = "Person 5", Age = 20, Job = "Job 2" },
            new Person { Name = "Person 6", Age = 30, Job = "Job 2" },
            new Person { Name = "Person 7", Age = 40, Job = "Job 3" },
            new Person { Name = "Person 8", Age = 19, Job = "Job 3" },
            new Person { Name = "Person 9", Age = 18, Job = "Job 3" },
            new Person { Name = "Person 10", Age = 100, Job = "Job 1" });
    }
}