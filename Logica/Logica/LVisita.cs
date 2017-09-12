using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Logica;
using Persistencia;

namespace Logica
{
    internal class LVisita:ILVisita
    {
        //singleton 
        private static LVisita instancia = null;

        //Constructor privado
        private LVisita() { }

        //operacion
        public static LVisita GetInstancia()
        {
            if (instancia == null)
                instancia = new LVisita();
            return instancia;
        }

        public void AltaVisita(Visita v)
        {
            if (v.Fecha >= DateTime.Now)
            {
                IVisita perVisita = PFabrica.getPersistenciaVisita();
                perVisita.AltaVisita(v);
            }
            else
                throw new Exception("La fecha no debe ser anterior a hoy.");
        }
    }
}
