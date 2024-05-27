﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cod3rsGrowth.Infra.RepositoriosTest;
using Cod3rsGrowth.Dominio.Modelos;

namespace Cod3rsGrowth.Servicos.Servicos
{
    public interface IServicoClube
    {
        List<Clube> ObterTodos();

        int? CriarClube(Clube clube);
        Clube ObterPorId(int id);
        void EditarClube(int id, Clube clube);
        void RemoverClube(int id);
    }
}
