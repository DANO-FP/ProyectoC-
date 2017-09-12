using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Visita
    {
        //Atributo
        private int _ID;
        private string _Nombre;
        private int _Telefono;
        private DateTime _Fecha;
        private Propiedad _Propiedad;

        //Propiedades
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string Nombre
        {
            get { return _Nombre; }
            set 
            {
                if (value.Length > 0 && value.Length <= 200)
                    _Nombre = value;
                else
                    throw new Exception("Error con el nombre");
            }
        }
        public int Telefono
        {
            set
            {
                if (value.ToString().Length <= 12 && value.ToString().Length >= 8)
                    _Telefono = value;
                else
                    throw new Exception("El largo del telefono no es valido");
            }
            get { return _Telefono; }
        }
        public DateTime Fecha 
        {
            get
            { return _Fecha;}
            set
            {
                if (value != null)
                    _Fecha = value;
                else
                    throw new Exception("Error en la fecha");
            }
        }
        public Propiedad Propiedad
        {
            get { return _Propiedad; }
            set 
            {
                if (value != null)
                    _Propiedad = value;
                else
                    throw new Exception("La propiedad no existe");
            }
        }

        public Visita(int pId,string pNombre, int pTelefono, DateTime pFecha, Propiedad pPropiedad)
        {
            ID = pId;
            Nombre = pNombre;
            Telefono = pTelefono;
            Fecha = pFecha;
            Propiedad = pPropiedad;
        }
    }
}
