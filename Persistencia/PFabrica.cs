using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;

namespace Persistencia
{
    public class PFabrica
    {
        public static IPersistenciaZona GetInstanciaZona()
        {
                return (ZonaPersistencia.GetPersZona);
        }
        
        public static IFuncionario GetInstanciaFuncionario()
        {
            return (PFuncionario.GetInstanciaFun());
        }
        
        public static IApartamento getPersistenciaApartamento()
        {
             return (PApartamento.getInstancia()); 

        }

        public static ICasa getPersistenciaCasa()
        {
           return (PCasa.getInstancia()); 

        }

        public static ILocalC getPersistenciaLocal()
        {
            return (PLocalC.getInstancia());

        }

        public static IPropiedad getPersistenciaPropiedad()
        {
            return (PPropiedad.getInstancia());

        }
        public static IVisita getPersistenciaVisita()
        {
            return (PVisita.getInstancia());
        }


    }
}
