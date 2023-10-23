using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Context;
using MaisEventosVsCode.Interfaces;
using MaisEventosVsCode.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MaisEventosVsCode.Repository
{
    public class UsuarioTestRepository : IUsuarioRepository
    {
        private readonly MaisEventosVsCodeContextApi _context;
        public UsuarioTestRepository(MaisEventosVsCodeContextApi context)
        {
            _context = context;
        }
        public ICollection<UsuarioTest> GetALL()
        {
            var usuarios = _context.usuarioTests.ToList();
            if (usuarios == null || usuarios.Count == 0)
            {
                // Se nenhum usuário foi encontrado, você pode retornar uma lista vazia
                return new List<UsuarioTest> { new UsuarioTest { nome = "Nenhum usuário encontrado." } };
            }
            return usuarios;
        }
        public bool Delete(int id)
        {
            var usuarioTestsBanco = _context.usuarioTests.Find(id);
            if (usuarioTestsBanco == null)
            {
                throw new Exception("Item não encontrado com o ID fornecido.");
            }
            _context.usuarioTests.Remove(usuarioTestsBanco);
            _context.SaveChanges();
           
            return true;
        }
        public UsuarioTest GetById(int id)
        {
            return _context.usuarioTests.Find(id);
        }
        public UsuarioTest Insert(int id, UsuarioTest usuarioTest)
        {
            _context.Add(usuarioTest);
            _context.SaveChanges();
            return usuarioTest;
        }
        public UsuarioTest UpDate(int id, UsuarioTest usuarioTest)
        {
            var usuarioTestBanco = _context.usuarioTests.Find(id);
            if (usuarioTestBanco == null)
                throw new Exception("Item não encontrado com o ID fornecido.");
            usuarioTestBanco.nome = usuarioTest.nome;
            usuarioTestBanco.email = usuarioTest.email;
            usuarioTestBanco.senha = usuarioTest.senha;

            _context.usuarioTests.Update(usuarioTestBanco);
            _context.SaveChanges();
            return usuarioTestBanco;
        }
    }
    internal class UsuarioTestContext
    {
    }
}