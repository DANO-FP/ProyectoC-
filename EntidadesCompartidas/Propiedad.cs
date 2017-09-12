using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public abstract class Propiedad
    {
        private int padron;
        private int precio;
        private int cantBaños;
        private int cantHabit;
        private int mt2Ed;
        private string direccion;
        private string accion;
        private Zona departamento;
        private Funcionario usuario;

        public int Padron
        {
            get { return padron; }
            set
            {
                if (value > 0)
                    padron = value;
                else
                    throw new Exception("El padrón debe ser mayor a 0");
            }
        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value > 0)
                    precio = value;
                else
                    throw new Exception("El precio debe ser mayor a 0");
            }
        }

        public int CantBaños
        {
            get { return cantBaños; }
            set
            {
                if (value > 0)
                    cantBaños = value;
                else
                    throw new Exception("La cantidad de baños debe ser mayor a 0");
            }
        }

        public int CantHabit
        {
            get { return cantHabit; }
            set
            {
                if (value> 0)
                    cantHabit = value;
                else
                    throw new Exception("La cantidad de habitaciones debe ser mayor a 0");
            }
        }

        public int Mt2Ed
        {
            get { return mt2Ed; }
            set
            {
                if (value > 0)
                    mt2Ed = value;
                else
                    throw new Exception("La cantidad de metros cuadrados edificados debe ser mayor a 0");
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Length > 0 && value.Length <= 60)
                    direccion = value;
                else
                    throw new Exception("La direccion no puede ser vacia");
            }
        }

        public string Accion
        {
            get { return accion; }
            set 
            {
                if (value.Length > 0 && value.Length <= 20)
                    accion = value;
                else
                    throw new Exception("La accion no puede ser vacia");
            }
        }

        public Zona Departamento
        {
            get { return departamento; }
            set 
            {
                if (value != null)
                    departamento = value;
                else
                    throw new Exception("Error en departamento");
            }
        }

        public Funcionario Usuario
        {
            get { return usuario; }
            set 
            {
                if (value != null)
                    usuario = value;
                else
                    throw new Exception("Error en el usuario");
            }
        }

        public Propiedad(int padron, int precio, int cantBaños, int cantHabit, int mt2Ed, string direccion, string accion, Zona dep, Funcionario usu)
        {
            Padron = padron;
            Precio = precio;
            CantBaños = cantBaños;
            CantHabit = cantHabit;
            Mt2Ed = mt2Ed;
            Direccion = direccion;
            Accion = accion;
            departamento = dep;
            usuario = usu;
        }
    }
}
