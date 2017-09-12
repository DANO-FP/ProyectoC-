using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Servicio
    {
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Length>0 && value.Length <=200)
                    nombre = value;
                else
                    throw new Exception("Debe ingresar el nombre del servicio para poder ingresarlo. ");
            }
        }

        public Servicio(string pnombre)
        {
            Nombre = pnombre;
        }
    }
}
