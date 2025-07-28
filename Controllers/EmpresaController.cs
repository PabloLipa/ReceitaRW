using Localiza_Aplicattion.Data;
using Localiza_Aplicattion.DTO.DTO_Empresa;
using Localiza_Aplicattion.Interfaces;
using Localiza_Aplicattion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Localiza_Aplicattion.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        [Authorize]
        public class EmpresaController : ControllerBase
        {
            private readonly DataContexto _context;
            private readonly IReceitaService _receitaWsService;

            public EmpresaController(DataContexto context, IReceitaService receitaWsService)
            {
                _context = context;
                _receitaWsService = receitaWsService;
            }

            [HttpPost]
            public async Task<IActionResult> CadastrarEmpresa([FromBody] CadastrarEmpresaDTO dto)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    return Unauthorized(new { Message = "Usuário não autenticado ou ID de usuário inválido." });
                }

                var existingEmpresa = await _context.Empresas.FirstOrDefaultAsync(e => e.Cnpj == dto.Cnpj && e.UsuarioId == userId);
                if (existingEmpresa != null)
                {
                    return Conflict(new { Message = "Esta empresa já foi cadastrada por você." });
                }

                var cnpjData = await _receitaWsService.ConsultarCnpj(dto.Cnpj);

                if (cnpjData == null || cnpjData.Status == "ERROR")
                {
                    return BadRequest(new { Message = cnpjData?.Message ?? "Não foi possível consultar o CNPJ na ReceitaWS." });
                }

                var empresa = new Empresa
                {
                    NomeEmpresarial = cnpjData.NomeEmpresarial,
                    NomeFantasia = cnpjData.NomeFantasia,
                    Cnpj = cnpjData.Cnpj,
                    Situacao = cnpjData.Situacao,
                    Abertura = cnpjData.Abertura,
                    Tipo = cnpjData.Tipo,
                    NaturezaJuridica = cnpjData.NaturezaJuridica,
                    AtividadePrincipal = cnpjData.AtividadePrincipal?.FirstOrDefault()?.Text,
                    Logradouro = cnpjData.Logradouro,
                    Numero = cnpjData.Numero,
                    Complemento = cnpjData.Complemento,
                    Bairro = cnpjData.Bairro,
                    Municipio = cnpjData.Municipio,
                    Uf = cnpjData.Uf,
                    Cep = cnpjData.Cep,
                    UsuarioId = userId
                };

                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                return StatusCode(201, new { Message = "Empresa cadastrada com sucesso!", EmpresaId = empresa.Id });
            }

            [HttpGet]
            public async Task<IActionResult> GetEmpresas()
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null || !int.TryParse(userIdClaim.Value, out int userId))
                {
                    return Unauthorized(new { Message = "Usuário não autenticado ou ID de usuário inválido." });
                }

                var empresas = await _context.Empresas
                                           .Where(e => e.UsuarioId == userId)
                                           .OrderBy(e => e.NomeEmpresarial)
                                           .Select(e => new EmpresaResponseDTO
                                           {
                                               Id = e.Id,
                                               NomeEmpresarial = e.NomeEmpresarial,
                                               NomeFantasia = e.NomeFantasia,
                                               Cnpj = e.Cnpj,
                                               Situacao = e.Situacao,
                                               Abertura = e.Abertura,
                                               Tipo = e.Tipo,
                                               NaturezaJuridica = e.NaturezaJuridica,
                                               AtividadePrincipal = e.AtividadePrincipal,
                                               Logradouro = e.Logradouro,
                                               Numero = e.Numero,
                                               Complemento = e.Complemento,
                                               Bairro = e.Bairro,
                                               Municipio = e.Municipio,
                                               Uf = e.Uf,
                                               Cep = e.Cep
                                           })
                                           .ToListAsync();

                if (!empresas.Any())
                {
                    return NotFound(new { Message = "Nenhuma empresa encontrada para este usuário." });
                }

                return Ok(empresas);
            }
        }
}
