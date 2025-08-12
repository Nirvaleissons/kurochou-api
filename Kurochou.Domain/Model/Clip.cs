namespace Kurochou.Domain.Model;

public class Clip : BaseEntity
{
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public Guid UserId { get; set; }
        public int Like { get; set; } = 0;
        public bool IsPublic { get; set; } = true;
}