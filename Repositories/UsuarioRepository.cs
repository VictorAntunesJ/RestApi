using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Context;
using MaisEventosVsCode.Interfaces;
using MaisEventosVsCode.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaisEventosVsCode.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly MaisEventosVsCodeContextApi _context;
        private object usuarioTests;

        public UsuarioRepository()
        {
        }

        public UsuarioRepository(MaisEventosVsCodeContextApi context)
        {
            _context = context;
        }


        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<UsuarioTest> GetAll()
        {
            var usuarioTest = _context.usuarioTests.ToList();

            if (usuarioTest == null || usuarioTest.Count == 0)
            {
                return NotFound("Nenhum usuário encontrado.");
            }

            return usuarioTest;
        }

        private ICollection<UsuarioTest> NotFound(string v)
        {
            throw new NotImplementedException();
        }

        public UsuarioTest GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UsuarioTest Insert(UsuarioTest usuarioTest)
        {
            _context.Add(usuarioTest);
            _context.SaveChanges();

            return usuarioTest;
        }

        public UsuarioTest Update(int id, UsuarioTest usuarioTest)
        {
            var usuarioTestBanco = _context.usuarioTests.Find(id);

            if (usuarioTestBanco == null)
                return (UsuarioTest)NotFound("Item não encontrado com o ID fornecido.");

            if (usuarioTests is UsuarioTest)
            {
                var usuarioTestAtualizado = (UsuarioTest)usuarioTests;
                usuarioTestBanco.nome = usuarioTestAtualizado.nome;
                usuarioTestBanco.email = usuarioTestAtualizado.email;
                usuarioTestBanco.senha = usuarioTestAtualizado.senha;
                _context.usuarioTests.Update(usuarioTestBanco);
                _context.SaveChanges();
                return usuarioTestBanco;
            }

            else
            {
                return (UsuarioTest)NotFound("O objeto fornecido não é do tipo UsuarioTest.");
            }
        }


    }
}
