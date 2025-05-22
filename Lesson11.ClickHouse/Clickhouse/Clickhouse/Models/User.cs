using System.ComponentModel.DataAnnotations;

namespace Clickhouse.Models;

public class User
{
    [Required] [Key] public uint Id { get; set; }

    [Required] public string Name { get; set; } = null!;

    [Required] public ushort Age { get; set; }

    [Required] public decimal TotalSpending { get; set; }
}