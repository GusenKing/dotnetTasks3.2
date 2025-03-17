using System.Reflection;
using HotChocolate.Data;
using Lesson1.GraphQL.WithMutation.Entities;
using Microsoft.Extensions.Caching.Memory;

namespace Lesson1.GraphQL.WithMutation.GraphQL;

public class Query
{
    [UseFiltering]
    public IQueryable<PersonForMutation> GetPersons(IMemoryCache cache)
    {
        var fieldInfo = typeof(MemoryCache).GetField("_coherentState", BindingFlags.Instance | BindingFlags.NonPublic);
        var propertyInfo =
            fieldInfo.FieldType.GetProperty("NonStringEntriesCollection",
                BindingFlags.Instance | BindingFlags.NonPublic);
        var value = fieldInfo.GetValue(cache);
        var dict = propertyInfo.GetValue(value) as dynamic;

        var cacheCollectionValues = new List<object>();

        foreach (var cacheItem in dict)
        {
            ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
            cacheCollectionValues.Add(cacheItemValue.Value);
        }

        return cacheCollectionValues.Cast<PersonForMutation>().AsQueryable();
    }
}