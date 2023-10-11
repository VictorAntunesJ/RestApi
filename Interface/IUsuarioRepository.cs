using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Models;

namespace MaisEventosVsCode.Interface
{
    public interface IUsuarioRepository
    {
        //Crud

        //Read
        ICollection<UsuarioTest> GetALL();
        UsuarioTest GetById(int id);

        //Create
        UsuarioTest Insert(UsuarioTest usuarioTest);

        //UpDate
        UsuarioTest UpDate(int id, UsuarioTest usuarioTest);

        //Delete
        bool Delete(int id);
    }
}