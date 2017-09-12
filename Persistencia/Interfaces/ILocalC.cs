using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Persistencia
{
    public interface ILocalC
    {
        void AltaLocal(LocalComercial loc);
        void ModificarLocal(LocalComercial loc);
        LocalComercial BuscarLocal(int padron);
        List<LocalComercial> ListarLocal();
    }
}
