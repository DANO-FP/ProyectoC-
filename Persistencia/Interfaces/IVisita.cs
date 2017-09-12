using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface IVisita
    {
        void AltaVisita(Visita V);
        /*void EliminarVisita(Visita V);
        void ModificarVisita(Visita V);
        Visita BuscarVisita(int ID);
        List<Visita> ListarVisitas();*/
    }
}
