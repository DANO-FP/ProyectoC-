﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface ICasa
    {
        void AltaCasa(Casa cas);
        void ModificarCasa(Casa cas);
        Casa BuscarCasa(int padron);
        List<Casa> ListarCasas();
    }
}
