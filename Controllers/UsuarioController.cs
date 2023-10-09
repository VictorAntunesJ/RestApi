using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Context;
using MaisEventosVsCode.Models;
using MaisEventosVsCode.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MaisEventosVsCode.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {



        private readonly MaisEventosVsCodeContextApi _context;
        public UsuarioController(MaisEventosVsCodeContextApi context)
        {
            _context = context;
        }

        private UsuarioRepository repositorio = new();
        /// <summary>
        /// Cadastrar usuários na aplicação
        /// </summary>
        /// <param name="usuarioTest">Dados do usuário</param>
        /// <returns>Dados do usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Create(UsuarioTest usuarioTest)
        {
            try
            {
                repositorio.Insert(usuarioTest);
                return Ok(usuarioTest);
                //return Ok(usuarioTest);
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
        /// Lista Todos Usuários da aplicação
        /// </summary>
        /// <returns>Lista de usuário</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            try
            {
               var usuarioTest = repositorio.GetAll();
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
        /// Altera os dados de um Usuário
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioTests">Todas informações do Usuário</param>
        /// <returns>Usuário Alterado</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, UsuarioTest usuarioTests)
        {


            try
            {
                var usuarioTestBanco = _context.usuarioTests.Find(id);

                if (usuarioTestBanco == null)
                    return NotFound("Item não encontrado com o ID fornecido.");

                usuarioTestBanco.nome = usuarioTests.nome;
                usuarioTestBanco.email = usuarioTests.email;
                usuarioTestBanco.senha = usuarioTests.senha;

                _context.usuarioTests.Update(usuarioTestBanco);
                _context.SaveChanges();

                return Ok(usuarioTestBanco);



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
                var usuarioTestsBanco = _context.usuarioTests.Find(id);

                if (usuarioTestsBanco == null)
                    return NotFound("Item não encontrado com o ID fornecido.");

                _context.usuarioTests.Remove(usuarioTestsBanco);
                _context.SaveChanges();

                return Ok(new
                {
                    msg = "Usuário excluído com sucesso!!!"
                });
                /*var mensagem = new { Mensagem = "Usuário deletado com sucesso" };
                return Ok(mensagem);*/
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
