using System.ComponentModel.DataAnnotations;

namespace Lesson1.GraphQL.Entities;

public class Person
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; }

    [Range(0, 150)] public int Age { get; set; }

    [Required] public string Job { get; set; }
}