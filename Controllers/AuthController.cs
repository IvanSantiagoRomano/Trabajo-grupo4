using Application.Exceptions; // Para poder usar el método de extensión ex.Handle()
using Application.Users.UseCases.Process;
using Microsoft.AspNetCore.Mvc;

namespace FrontendReact.Server.Controllers // <--- Cambiado para que coincida con tu proyecto .Server
{
    [ApiController]
    [Route("api/[controller]")] // Esto mapea automáticamente a "api/auth" por el nombre del controlador
    public class AuthController : ControllerBase
    {
        private readonly IUCLoginUser _loginUseCase;

        public AuthController(IUCLoginUser loginUseCase)
        {
            _loginUseCase = loginUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            try
            {
                var result = await _loginUseCase.LogInAsync(request.Username, request.Password);
                return Ok(result);
            }
            catch (Exception ex)
            {
               
             //   ex.Handle();

                // Le devolvemos un mensaje genérico o controlado al cliente (React)
                return BadRequest(new { message = ex.Message });
            }
        }



        

    }

    public record LoginRequest(string Username, string Password);
}