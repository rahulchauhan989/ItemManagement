using System.ComponentModel.DataAnnotations;

namespace ItemManagementSystem.Domain.DataModels;

public class Status
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
