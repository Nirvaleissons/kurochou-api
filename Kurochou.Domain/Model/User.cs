using System.ComponentModel.DataAnnotations;

namespace Kurochou.Domain.Model;

public class User : BaseEntity
{
    [Required]
    public string Username { get; set; } = string.Empty;

    [Required]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string PasswordHash { get; set; } = string.Empty;

    public List<Clip> Clips { get; set; } = [];
}
