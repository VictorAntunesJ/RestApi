using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Models;

namespace MaisEventosVsCode.Interfaces
{
    public interface IUsuarioRepository
    {

        // CRUD
        //Read
        ICollection<UsuarioTest> GetAll();
        UsuarioTest GetById(int id);
        //Create
        UsuarioTest Insert(UsuarioTest usuarioTest);
        //Update
        UsuarioTest Update(int id, UsuarioTest usuarioTest);
        //Delete
        bool Delete(int id);
    }
}