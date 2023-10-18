using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Models;

namespace MaisEventosVsCode.Interfaces
{
    public interface IUsuarioRepository
    {
        
        ICollection<UsuarioTest> GetALL();
        UsuarioTest GetById(int id);
        UsuarioTest Insert(int id, UsuarioTest usuarioTest);
        UsuarioTest UpDate(int id, UsuarioTest usuarioTest);
        bool Delete(int id);
    }
}