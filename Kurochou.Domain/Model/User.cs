using System.ComponentModel.DataAnnotations;

namespace Kurochou.Domain.Model;

public class User : BaseEntity
{
        [Required]
        public string Username { get; init; } = string.Empty;

        [Required]
        public string PasswordHash { get; init; } = string.Empty;

        public IEnumerable<Clip> Clips { get; init; } = [];
}
