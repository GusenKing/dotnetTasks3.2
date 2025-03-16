using System.ComponentModel.DataAnnotations;

namespace Lesson1.GraphQL.Entities;

public class Person
{
    [Key] [Required] public string Name { get; set; }

    [Range(0, 150)] public int Age { get; set; }

    [Required] public string Job { get; set; }
}