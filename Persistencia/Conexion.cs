using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistencia
{
    internal class Conexion
    {
        private const string con = "Data Source = .; initial catalog = Inmobiliaria; integrated security = true";

        public static string Con
        {
            get { return con;}
        }
    }
}
