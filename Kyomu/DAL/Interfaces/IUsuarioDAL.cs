﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IUsuarioDAL : IDALGenerico<Usuario>
    {
        List<Usuario> GetAllUsuarios();
        Usuario Get(int id);
        IEnumerable<Usuario> GetAll();
    }
}
