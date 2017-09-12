using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Funcionario
    {
        //Atributo
        private string _Nombre;
        private string _Password;

        //Propiedades
        public string Nombre
        {
            get { return _Nombre; }
            set 
            {
                if(value.Length>0 && value.Length <=50)
                    _Nombre = value;
                else
                    throw new Exception("Debe ingresar un nombre de usuario");
            }
        }
        public string Password
        {
            set 
            {
                if (value.Length == 10)
                    _Password = value;
                else
                    throw new Exception("La contraseña debe ser de 10 Digitos");
            }
            get
            { return _Password; }
        }
        //Constructor
        public Funcionario(string pNombre, string pPassword)
        {
            Nombre = pNombre;
            Password = pPassword;
        }
    }
}
