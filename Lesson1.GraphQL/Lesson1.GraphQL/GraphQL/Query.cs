using Lesson1.GraphQL.Entities;

namespace Lesson1.GraphQL.GraphQL;

public class Query
{
    [UsePaging]
    [UseProjection]
    [UseFiltering]
    [UseSorting]
    public IQueryable<Person> GetPeople(AppDbContext dbContext)
    {
        return dbContext.People;
    }
}