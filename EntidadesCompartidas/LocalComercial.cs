using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class LocalComercial:Propiedad
    {
        private bool habilitacion;

        public bool Habilitacion
        {
            get { return habilitacion; }
            set { habilitacion = value; }
        }

        public LocalComercial(int padron, int precio, int cantBaño, int cantHabit, int mt2Ed, string direccion, string accion, Zona dep, Funcionario usu, bool hab) :
            base(padron, precio, cantBaño, cantHabit, mt2Ed, direccion, accion, dep, usu)
        {
            Habilitacion = hab;
        }
    }
}
