using Application.Interfaces;
using System.Security.Cryptography;

namespace Infrastructure.Security
{
    /// <summary>
    /// Implementa <see cref="IPasswordHasher"/> utilizando el algoritmo PBKDF2 con HMAC-SHA512.
    /// </summary>
    /// <remarks>
    /// Esta implementación incorpora salt aleatorio y múltiples iteraciones para reforzar la seguridad
    /// contra ataques por diccionario o fuerza bruta. El salt se embebe en el resultado final,
    /// por lo que no es necesario almacenarlo por separado.
    /// </remarks>
    public class PasswordHasher : IPasswordHasher
    {
        /// <summary>
        /// Tamaño del salt en bytes (128 bits).
        /// </summary>
        private const int SaltSize = 16;

        /// <summary>
        /// Tamaño del hash resultante en bytes (512 bits).
        /// </summary>
        private const int HashSize = 64;

        /// <summary>
        /// Número de iteraciones utilizadas en la derivación de clave PBKDF2.
        /// A mayor número de iteraciones, mayor costo computacional para ataques de fuerza bruta.
        /// </summary>
        private const int Iterations = 100_000;

        /// <summary>
        /// Genera un hash seguro a partir de una cadena de texto plano.
        /// Internamente genera un salt aleatorio, deriva el hash con PBKDF2 y embebe el salt
        /// en los primeros <see cref="SaltSize"/> bytes del resultado codificado en Base64.
        /// </summary>
        /// <param name="input">Texto plano a hashear. Típicamente una contraseña.</param>
        /// <returns>
        /// Cadena Base64 que contiene el salt embebido seguido del hash derivado.
        /// </returns>
        /// <inheritdoc/>
        public string Hash(string input)
        {
            var rng = RandomNumberGenerator.Create();
            var salt = new byte[SaltSize];
            rng.GetBytes(salt);
            var hash = GetPBKDF2Bytes(input, salt);
            var hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);
            return Convert.ToBase64String(hashBytes);
        }

        /// <summary>
        /// Verifica si una cadena de texto plano corresponde a un hash previamente generado.
        /// Extrae el salt embebido en el hash almacenado, recalcula el hash con el input
        /// y compara ambos en tiempo constante para prevenir ataques de temporización.
        /// </summary>
        /// <param name="input">Texto plano a verificar. Típicamente la contraseña ingresada por el usuario.</param>
        /// <param name="hashed">Hash almacenado previamente generado con <see cref="Hash"/>.</param>
        /// <returns>
        /// <c>true</c> si el input corresponde al hash almacenado; <c>false</c> en caso contrario.
        /// </returns>
        /// <inheritdoc/>
        public bool Verify(string input, string hashed)
        {
            var hashBytes = Convert.FromBase64String(hashed);
            var salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);
            var hash = GetPBKDF2Bytes(input, salt);
            
            // Comparación en tiempo constante para prevenir ataques de temporización (timing attacks).
            // Acumula diferencias bit a bit sin cortocircuitar la evaluación.
            uint diff = (uint)hashBytes.Length ^ (uint)(SaltSize + HashSize);
            for (int i = 0; i < HashSize; i++)
            {
                diff |= (uint)(hashBytes[i + SaltSize] ^ hash[i]);
            }
            return diff == 0;
        }

        /// <summary>
        /// Deriva un hash seguro utilizando PBKDF2 con HMAC-SHA512.
        /// </summary>
        /// <param name="input">Texto plano a hashear.</param>
        /// <param name="salt">Salt aleatorio de <see cref="SaltSize"/> bytes.</param>
        /// <returns>
        /// Array de bytes de longitud <see cref="HashSize"/> con el hash derivado.
        /// </returns>
        private byte[] GetPBKDF2Bytes(string input, byte[] salt)
        {
            var pbkdf2 = new Rfc2898DeriveBytes(input, salt, Iterations, HashAlgorithmName.SHA512);
            return pbkdf2.GetBytes(HashSize);
        }
    }
}