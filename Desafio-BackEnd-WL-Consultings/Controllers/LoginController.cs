using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Modelo.Infra.Data.Desafio_BackEnd_WL_Consultings.Data;
using Modelo.Domain.Modelos;
using Desafio_BackEnd_WL_Consultings.Util;
using Modelo.Domain.Modelos.FormValidation;
using System.Net;


namespace Desafio_BackEnd_WL_Consultings.Controllers
{
    public class LoginController : Controller
    {
        #region Context

        private readonly ApplicationDbContext _context;

        private readonly IConfiguration _configuration;

        public LoginController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }


        #endregion

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel login)
        {

            try
            {
                // Validação dos dados de entrada
                LoginValidator.ValidarDados(login);

                // Validação do usuário (exemplo simples)
                var user = _context.Usuarios.FirstOrDefault(u => u.numeroConta == login.numeroConta && u.senha == HashSenha.GerarHashMd5(login.senha));
                if (user == null)
                {
                    return Unauthorized(new { sucesso = false, mensagem = "Falha ao realizar o login, favor informar numero da conta e senha corretos!" });
                }

                // Gerar o token JWT
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim("id", user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Nome),
                    new Claim("numeroConta", user.numeroConta)
                }),
                    Expires = DateTime.UtcNow.AddHours(1),
                    Issuer = _configuration["Jwt:Issuer"],
                    Audience = _configuration["Jwt:Audience"],
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);

                return Ok(new { Token = tokenHandler.WriteToken(token) });
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.Unauthorized, new { erro = ex.Message });
            }
        }
    }
}
