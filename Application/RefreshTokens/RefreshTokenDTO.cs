using Application.Common;


namespace Application.RefreshTokens
{
    public class RefreshTokenDTO: IDto
    {        
        public Guid UserId { get; set; }
        public string Token { get; set; } = null!;
        public DateTime Expires { get; set; }
        
        public bool IsExpired => DateTime.UtcNow >= Expires;

    }
}
