using Lesson1.GraphQL.WithMutation.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Lesson1.GraphQL.WithMutation.GraphQL;

public class Mutation(IMemoryCache cache)
{
    [UseMutationConvention]
    public PersonForMutation AddPerson(string name, int age, string jobTitle)
    {
        var newPerson = new PersonForMutation { Id = Guid.NewGuid(), Name = name, Age = age, Job = jobTitle };
        cache.Set(newPerson.Id, newPerson);
        return newPerson;
    }

    [UseMutationConvention]
    public PersonForMutation UpdatePerson(Guid id, string name, int age, string jobTitle)
    {
        if (!cache.TryGetValue(id, out PersonForMutation person))
        {
            person.Name = name;
            person.Age = age;
            person.Job = jobTitle;
        }
        else
        {
            person = new PersonForMutation { Id = id, Name = name, Age = age, Job = jobTitle };
        }

        return person;
    }

    [UseMutationConvention]
    public void DeletePerson(Guid id)
    {
        cache.Remove(id);
    }
}