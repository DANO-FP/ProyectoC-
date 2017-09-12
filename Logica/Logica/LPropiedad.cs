using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using Persistencia;

namespace Logica
{
    internal class LPropiedad: ILPropiedad
    {
        private static LPropiedad instancia = null;

        private LPropiedad() { }

        public static LPropiedad GetInstancia()
        {
            if (instancia == null)
                instancia = new LPropiedad();
            return instancia;
        }

        public void AltaPropiedad(Propiedad prop)
        {
            if (prop is Apartamento)
            {
                IApartamento perApto = PFabrica.getPersistenciaApartamento();
                perApto.AltaApartamento((Apartamento)prop);
            }
            else if (prop is LocalComercial)
            {
                ILocalC perLoc = PFabrica.getPersistenciaLocal();
                perLoc.AltaLocal((LocalComercial)prop);
            }
            else
            {
                ICasa perCas = PFabrica.getPersistenciaCasa();
                perCas.AltaCasa((Casa)prop);
            }
        }

        public Propiedad BuscarPropiedad(int padron)
        {
            Propiedad prop = null;

            IApartamento perApto = PFabrica.getPersistenciaApartamento();
            prop = (Apartamento)perApto.BuscarApartamento(padron);

            if (prop == null)
            {
                ICasa perCas = PFabrica.getPersistenciaCasa();
                prop = (Casa)perCas.BuscarCasa(padron);

                if (prop == null)
                {
                    ILocalC perLoc = PFabrica.getPersistenciaLocal();
                    prop = (LocalComercial)perLoc.BuscarLocal(padron);
                }
            }
            return prop;
        }

        public void ModificarPropiedad(Propiedad prop)
        {
            if (prop is Apartamento)
            {
                IApartamento perApto = PFabrica.getPersistenciaApartamento();
                perApto.ModificarApartamento((Apartamento)prop);
            }
            else if (prop is Casa)
            {
                ICasa perCas = PFabrica.getPersistenciaCasa();
                perCas.ModificarCasa((Casa)prop);
            }
            else
            {
                ILocalC perLoc = PFabrica.getPersistenciaLocal();
                perLoc.ModificarLocal((LocalComercial)prop);
            }
        }

        public void EliminarPropiedad(Propiedad prop)
        {
            IPropiedad perProp = PFabrica.getPersistenciaPropiedad();
            perProp.EliminarPropiedad(prop);
        }

        public List<Propiedad> ListarPropiedades()
        {
            List<Propiedad> lista = new List<Propiedad>();

            IApartamento perApto = PFabrica.getPersistenciaApartamento();
            ICasa perCas = PFabrica.getPersistenciaCasa();
            ILocalC perLoc = PFabrica.getPersistenciaLocal();

            lista.AddRange(perApto.ListarApartamentos());
            lista.AddRange(perCas.ListarCasas());
            lista.AddRange(perLoc.ListarLocal());

            return lista;
        }

        public List<Casa> ListarCasas()
        {
            List<Casa> lista = null;
            ICasa perCas = PFabrica.getPersistenciaCasa();
            lista = perCas.ListarCasas();
            return lista;
        }

        public List<Apartamento> ListarApartamentos()
        {
            List<Apartamento> lista = null;
            IApartamento perApto = PFabrica.getPersistenciaApartamento();
            lista = perApto.ListarApartamentos();
            return lista;
        }

        public List<LocalComercial> ListarLocales()
        {
            List<LocalComercial> lista = null;
            ILocalC perLoc = PFabrica.getPersistenciaLocal();
            lista = perLoc.ListarLocal();
            return lista;
        }
    }
}
