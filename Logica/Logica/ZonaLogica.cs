using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace Logica
{
    internal class ZonaLogica:ILogicaZona
    {
        private static ZonaLogica instancia = null;

        private ZonaLogica() { }

        public static ZonaLogica GetInstanciaZona
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ZonaLogica();
                }

                return (instancia);
            }
        }

        public Zona BuscarZona(string dep, string acronimo)
        {
            Zona z = null;
            try
            {
                IPersistenciaZona pz = PFabrica.GetInstanciaZona();
                z = pz.BuscarZona(dep, acronimo);

            }
            catch (Exception er)
            {
                throw er;
            }
            return (z);
        
        }

        public void AltaZona(Zona z)
        {
            try
            {
                IPersistenciaZona pz = PFabrica.GetInstanciaZona();
                pz.AltaZona(z);

            }
            catch (Exception er)
            {
                
                throw er;
            }
        
        }

        public void BajaZona(Zona z)
        {
            try
            {
                IPersistenciaZona pz = PFabrica.GetInstanciaZona();
                pz.BajaZona(z);
            }
            catch (Exception er)
            {
                throw er;
            }

        }

        public void ModificaZona(Zona z)
        {
            try
            {
                IPersistenciaZona pz = PFabrica.GetInstanciaZona();
                pz.ModificaZona(z);

            }
            catch (Exception er)
            {
                
                throw er;
            }
        
        }

        public void ModificarServicios(Zona z)
        {
            try
            {
                IPersistenciaZona pz = PFabrica.GetInstanciaZona();
                pz.ModificarServicios(z);
            }
            catch (Exception er)
            {
                throw er;
            }
        
        }
    }
}
