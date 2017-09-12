using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Casa:Propiedad
    {
        private int mt2Terr;
        private bool patio;

        public bool Patio
        {
            get { return patio; }
            set { patio = value; }
        }
        
        public int Mt2Terr
        {
            get { return mt2Terr; }
            set 
            {
                if (value > 0)
                    mt2Terr = value;
                else
                    throw new Exception("Los metros cuadrados de terreno deben ser mayor a 0");
            }
        }

        public Casa(int padron, int precio, int cantBaño, int cantHabit, int mt2Ed, string direccion, string accion, Zona dep, Funcionario usu, int mt2terr, bool patio) :
            base(padron, precio, cantBaño, cantHabit, mt2Ed, direccion, accion, dep, usu)
        {
            Mt2Terr = mt2terr;
            Patio = patio;
        }
    }
}
