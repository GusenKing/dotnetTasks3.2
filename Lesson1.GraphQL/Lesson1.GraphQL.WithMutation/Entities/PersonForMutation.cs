using System.ComponentModel.DataAnnotations;

namespace Lesson1.GraphQL.WithMutation.Entities;

public class PersonForMutation
{
    [Key] public Guid Id { get; set; }
    [Required] public string Name { get; set; }

    [Range(0, 150)] public int Age { get; set; }

    [Required] public string Job { get; set; }
}