using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Context;
using MaisEventosVsCode.Interfaces;
using MaisEventosVsCode.Models;
using MaisEventosVsCode.Utils;
using Microsoft.AspNetCore.Mvc;

namespace MaisEventosVsCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        /// <summary>
        /// Cadastrar usuários na aplicação
        /// </summary>
        /// <param name="usuarioTest">Dados do usuário</param>
        /// <returns>Dados do usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Create([FromForm] UsuarioTest usuarioTest, IFormFile arquivo)
        {
            try
            {
                #region Upload de Imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas, "Images");

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extenção não permitida");
                }

                usuarioTest.Imagem = uploadResultado;

                #endregion

                // Use o repositório para inserir o usuário
                _usuarioRepository.Insert(0, usuarioTest);
                return Ok(usuarioTest);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na Conexão!",
                    erro = ex.Message,
                });
            }
        }
        /// <summary>
        /// Listar todos usuarios da aplicaçao
        /// </summary>
        /// <param>Dados do usuário</param>
        /// <returns>Dados do usuário cadastrado</returns>     
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
                var usuarios = _usuarioRepository.GetALL().ToList();
                return Ok(usuarios);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na Conexão!",
                    erro = ex.Message,
                });
            }
        }
        /// <summary>
        /// Altera os dados de um Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioTest">Todas informações do Usuário</param>
        /// <returns>Usuário Alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromForm] UsuarioTest usuarioTest, IFormFile arquivo)
        {
            try
            {
                #region Upload de Imagem
                string[] extensoesPermitidas = { "jpeg", "jpg", "png", "svg" };
                string uploadResultado = Upload.UploadFile(arquivo, extensoesPermitidas, "Images");

                if (uploadResultado == "")
                {
                    return BadRequest("Arquivo não encontrado ou extenção não permitida");
                }

                usuarioTest.Imagem = uploadResultado;

                #endregion           
                var updateUsuarioTeste = _usuarioRepository.UpDate(id, usuarioTest);
                return Ok(updateUsuarioTeste);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na Conexão!",
                    erro = ex.Message,
                });
            }
        }
        /// <summary>
        /// Excluir um usuário da aplicaçao.
        /// </summary>
        /// <param name="id">Id do Usuário</param>
        /// <returns>Mensagem de Exclusão</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                bool exclusaoBemSucedida = _usuarioRepository.Delete(id);

                if (exclusaoBemSucedida)
                {
                    return Ok("Usuário deletado com sucesso.");
                }
                else
                {
                    return NotFound("Usuário não encontrado com o ID fornecido.");
                }
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    msg = "Falha na Conexão!",
                    erro = ex.Message,
                });
            }
        }
    }
}
