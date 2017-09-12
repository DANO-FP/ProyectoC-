using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Apartamento:Propiedad
    {
        private int piso;
        private bool ascensor;

        public int Piso
        {
            get { return piso; }
            set
            {
                if (value >= 0)
                    piso = value;
                else
                    throw new Exception("El piso no puede ser negativo");
            }
        }

        public bool Ascensor
        {
            get { return ascensor; }
            set { ascensor = value; }
        }

        public Apartamento(int padron, int precio, int cantBaño, int cantHabit, int mt2Ed, string direccion, string accion, Zona dep, Funcionario usu, int piso, bool ascensor):
            base(padron, precio, cantBaño, cantHabit, mt2Ed, direccion, accion, dep, usu)
        {
            Piso = piso;
            Ascensor = ascensor;
        }
    }
}
