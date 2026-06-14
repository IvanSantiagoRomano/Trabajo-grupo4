namespace Domain.Entities.Concrete.Privileges.RefreshTokens
{
    public class RefreshToken
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public Guid UserId { get; private set; }
        public string Token { get; private set; } = null!;
        public DateTime Expires { get; private set; }

        /// <summary>
        /// Devuelve dinámicamente un Bool que indica si el Token está o no expirado.
        /// </summary>
        public bool IsExpired => DateTime.UtcNow >= Expires;

        /// <summary>
        /// Constructor privado. Se crea por factory estática Create();
        /// </summary>
        private RefreshToken() { }

        /// <summary>
        /// Factory estática. Todos los parámetros son obligatorios.
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="token"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        public static RefreshToken Create(Guid userId, string token, DateTime expires)
        {
            return new RefreshToken
            {
                UserId = userId,
                Token = token,
                Expires = expires
            };
        }
    }
}
