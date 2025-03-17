using Lesson1.GraphQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lesson1.GraphQL;

public class AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : DbContext(options)
{
    public DbSet<Person> People { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(config.GetConnectionString("DefaultConnection")
            )
            .UseSeeding((context, _) =>
            {
                context.Set<Person>().AddRange(
                    new Person { Id = Guid.NewGuid(), Name = "Person 1", Age = 21, Job = "Job 1" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 2", Age = 21, Job = "Job 1" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 3", Age = 31, Job = "Job 1" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 4", Age = 41, Job = "Job 2" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 5", Age = 20, Job = "Job 2" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 6", Age = 30, Job = "Job 2" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 7", Age = 40, Job = "Job 3" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 8", Age = 19, Job = "Job 3" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 9", Age = 18, Job = "Job 3" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 10", Age = 100, Job = "Job 1" });

                context.SaveChanges();
            })
            .UseAsyncSeeding(async (context, _, cancellationToken) =>
            {
                await context.Set<Person>().AddRangeAsync(
                    new Person { Id = Guid.NewGuid(), Name = "Person 1", Age = 21, Job = "Job 1" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 2", Age = 21, Job = "Job 1" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 3", Age = 31, Job = "Job 1" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 4", Age = 41, Job = "Job 2" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 5", Age = 20, Job = "Job 2" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 6", Age = 30, Job = "Job 2" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 7", Age = 40, Job = "Job 3" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 8", Age = 19, Job = "Job 3" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 9", Age = 18, Job = "Job 3" },
                    new Person { Id = Guid.NewGuid(), Name = "Person 10", Age = 100, Job = "Job 1" });

                await context.SaveChangesAsync(cancellationToken);
            });
    }
}