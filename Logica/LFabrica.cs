using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class LFabrica
    {
        public static ILogicaZona GetInstZona()
        {
            return ZonaLogica.GetInstanciaZona;
        }


        public static ILFuncionario GetLogicaFun()
        {
            return LFuncionarios.GetInstancia();
        }

        public static ILPropiedad getLogicaPropiedad()
        {
            return LPropiedad.GetInstancia();
        }

        public static ILVisita getLogicaVisita()
        {
            return LVisita.GetInstancia();
        }
    }
}
