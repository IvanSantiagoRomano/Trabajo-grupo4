using Application.Common;
using Application.Interfaces;
using Domain;
using Domain.Exceptions;


namespace Application.Users.UseCases.Process
{
    public class UCLoginUser : IUCLoginUser
    {
        private readonly IUnitOfWork _uow;
        private readonly IPasswordHasher _hasher;


        public UCLoginUser
        (
            IUnitOfWork uow,
            IPasswordHasher hasher
        )
        {
            _uow = uow ?? throw new ArgumentNullException("La Unit Of Work no puede ser nula");
            _hasher = hasher ?? throw new ArgumentNullException("El hasher no puede ser nulo");
        }

        public async Task<OperationResult> LogInAsync(string userInput, string passInput)
        {            
            try
            {
                //1. Se obtiene el usuario a partir del nombre
                var user = (await _uow.Users.GetAllAsync()).FirstOrDefault(u => u.Username.Value == userInput);

                //2. Se valida que el nombre sea válido
                if (user == null) throw new InvalidCredentialsException("");

                //3. Se verifica que las contraseñas coincidan
                if (_hasher.Hash(passInput) != user.HashedPassword.Value) throw new InvalidCredentialsException("");

                //4. De existir la cuenta y coincidir la clave, se devuelve un resultado exitoso
                return OperationResult.Ok();
            }

            catch (InvalidCredentialsException ex)
            {
                return OperationResult.Fail(ex.Message);
            }

        }
    }
}

