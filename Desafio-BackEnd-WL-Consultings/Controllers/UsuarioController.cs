using Desafio_BackEnd_WL_Consultings.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Entidades;
using Modelo.Domain.Modelos;
using Modelo.Domain.Modelos.FormValidation;
using Modelo.Infra.Data.Desafio_BackEnd_WL_Consultings.Data;
using System.Net;

namespace Desafio_BackEnd_WL_Consultings.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        #region Context

        private readonly ApplicationDbContext _context;


        public UsuarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        #endregion

        [HttpGet]
        [Authorize]
        public ActionResult Index()
        {
            var usuarios = _context.Usuarios.ToList();
            return Ok(usuarios); 
        }

        [HttpGet("ConsultarSaldo")]
        [Authorize]
        public ActionResult ConsultarSaldo()
        {
            try
            {
                Usuario usuario = new();
                var idUsuario = User.Claims.FirstOrDefault(c => c.Type == "id")?.Value;
                if (idUsuario != null && Int32.Parse(idUsuario) > 0)
                {
                    usuario = _context.Usuarios.FirstOrDefault(u => u.Id == Int32.Parse(idUsuario));
                    if (usuario != null)
                        return Ok(usuario);
                    else
                        return BadRequest("Usuario não encontrado!");
                }
                else
                    throw new Exception("Usuario Logado inválido!");

            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, new { erro = ex.Message });
            }
        }
        [HttpPost("AdicionarSaldo")]
        [Authorize]
        public ActionResult AdicionarSaldo([FromBody] decimal valor)
        {
            try
            {
                if (valor <= 0)
                    return BadRequest("Valor informado inválido!");

                var idUsuario = Int32.Parse(User.Claims.FirstOrDefault(c => c.Type == "id")?.Value);
                
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.Id == idUsuario);
                if (usuario != null)
                {
                    usuario.saldo += valor;
                    _context.SaveChanges();
                    return Ok("Saldo adicionado com Sucesso!!");
                }
                else
                {
                    return BadRequest("Usuario não encontrado!");
                }

            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, new { erro = ex.Message });
            }
        }


        [HttpPost]
        public ActionResult Create(CreateUsuario userData)
        {
            try
            {
                //Valida os dados do usuário
                CreateUsuarioValidator.ValidarDados(userData);

                if (_context.Usuarios.Any( u => u.numeroConta == userData.numeroConta))
                {
                    return BadRequest("Usuario com numero da Conta informado já existe!");
                }

                Usuario user = new Usuario
                {
                    Nome = userData.Name,
                    numeroConta = userData.numeroConta,
                    senha = HashSenha.GerarHashMd5(userData.senha),
                    saldo = userData.saldo
                };

                _context.Usuarios.Add(user);
                _context.SaveChanges();
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new {erro= ex.Message});
            }
        }

    }

}
