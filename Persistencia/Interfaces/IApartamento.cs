using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface IApartamento
    {
        void AltaApartamento(Apartamento ap);
        void ModificarApartamento(Apartamento ap);
        Apartamento BuscarApartamento(int padron);
        List<Apartamento> ListarApartamentos();
    }
}
