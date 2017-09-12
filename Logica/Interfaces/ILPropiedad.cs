using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;

namespace Logica
{
    public interface ILPropiedad
    {
        void AltaPropiedad(Propiedad prop);
        void ModificarPropiedad(Propiedad prop);
        Propiedad BuscarPropiedad(int padron);
        void EliminarPropiedad(Propiedad prop);
        List<Propiedad> ListarPropiedades();
        List<Casa> ListarCasas();
        List<Apartamento> ListarApartamentos();
        List<LocalComercial> ListarLocales();
    }
}
