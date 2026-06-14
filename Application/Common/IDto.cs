namespace Application.Common
{
    public class IDto
    {
        public Guid Id { get; set; } = Guid.Empty;
        public bool IsDeleted { get; set; } = false;
    }
}
