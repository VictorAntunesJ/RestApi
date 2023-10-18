using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaisEventosVsCode.Models;
using Microsoft.EntityFrameworkCore;

namespace MaisEventosVsCode.Context
{
    public class MaisEventosVsCodeContextApi : DbContext
    {
        public DbSet<UsuarioTest> usuarioTests { get; set; }
        public MaisEventosVsCodeContextApi(DbContextOptions<MaisEventosVsCodeContextApi> options) 
            : base(options)
        {
        }

        internal void Insert(UsuarioTest usuarioTest)
        {
            throw new NotImplementedException();
        }
    }
}