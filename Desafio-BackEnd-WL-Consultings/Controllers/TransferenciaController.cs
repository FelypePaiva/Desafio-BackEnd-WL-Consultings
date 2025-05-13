using Microsoft.AspNetCore.Mvc;
using Modelo.Domain.Modelos;
using Modelo.Infra.Data.Desafio_BackEnd_WL_Consultings.Data;
using Modelo.Domain.Entidades;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Modelo.Domain.Modelos.FormValidation;

namespace Desafio_BackEnd_WL_Consultings.Controllers
{
    public class TransferenciaController : Controller
    {
        #region Context

        private readonly ApplicationDbContext _context;

        public TransferenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("ListarTransferencias")]
        public ActionResult ListarTransferencias( DateTime? dataInicial,  DateTime? dataFinal)
        {
            var idUsuario = User.FindFirst("id").Value;
            List<Transferencias> transferenciasDB = new List<Transferencias>();
            if(dataInicial == null || dataFinal == null)
            {
                transferenciasDB = _context.Transferencias
                    .Include(r => r.Remetente)
                    .Include(r => r.Destinatario)
                    .Where(t => t.Remetente.Id == Int32.Parse(idUsuario))
                    .ToList();
            }
            else
            {
                dataFinal = dataFinal.Value.Date.AddDays(1);
                transferenciasDB = _context.Transferencias
                    .Include(r => r.Remetente)
                    .Include(r => r.Destinatario)
                    .Where(t => t.Remetente.Id == Int32.Parse(idUsuario) && t.DataTransferencia > dataInicial.Value && t.DataTransferencia < dataFinal.Value)
                    .ToList();
            }

                List<ListaTransferenciaModel> transferencias = new List<ListaTransferenciaModel>();
            if (transferenciasDB == null || transferenciasDB.Count == 0)
                return NotFound("Nenhuma transferência encontrada para o usuário logado.");
            else
            {
                foreach (var transferencia in transferenciasDB)
                {
                    transferencias.Add(new ListaTransferenciaModel
                    {
                        numeroContaDestinatario = transferencia.Destinatario.numeroConta,
                        DestinatarioNome = transferencia.Destinatario.Nome,
                        valorTransferencia = transferencia.valorTransferencia,
                        dataTransferencia = transferencia.DataTransferencia
                    });
                }
                return Ok(transferencias);
            }
        }

        #endregion
        [Authorize]
        [HttpPost("TransferirSaldo")]
        public IActionResult TransferirSaldo(TransferenciaModel transferencia)
        {
            try
            {
                if (transferencia != null)
                {
                    //Validação dos dados
                    TransferenciaValidator.ValidarDados(transferencia);

                    var idUsuario = User.FindFirst("id").Value;
                    var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == Int32.Parse(idUsuario));

                    if (usuario != null)
                    {
                        if(usuario.saldo < transferencia.valorTransferencia)
                            throw new Exception("Saldo insuficiente para realizar a transferência!");
                        var usuarioDestinatario = _context.Usuarios.FirstOrDefault(u => u.numeroConta == transferencia.numeroContaDestinatario);
                        if (usuarioDestinatario != null)
                        {
                            usuario.saldo -= transferencia.valorTransferencia;
                            usuarioDestinatario.saldo += transferencia.valorTransferencia;

                            _context.Transferencias.Add(new Transferencias
                            {
                                Destinatario = usuarioDestinatario,
                                Remetente = usuario,
                                valorTransferencia = transferencia.valorTransferencia
                            });
                            _context.SaveChanges();
                            return Ok("Transferência realizada com sucesso!");
                        }
                        else
                        {
                            throw new Exception("Usuário destinatário não encontrado!");
                        }
                    }

                }
            }
            catch (Exception ex)
            {

                return StatusCode((int)HttpStatusCode.InternalServerError, new { erro = ex.Message });
            }
            return Ok();
        }
    }
}
