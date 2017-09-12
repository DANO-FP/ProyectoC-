using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidades
{
    public class Zona
    {
        private string idDepartamento;
        private string acronimo;
        private string nombreOficial;
        private int habitantes;
        private List<Servicio> servicios;


        public List<Servicio> Servicios
        {
            get { return servicios; }
            set { servicios = value; }
        }

        public int Habitantes
        {
            get { return habitantes; }
            set
            {
                if ((value > 0) || (value < Int32.MaxValue))
                    habitantes = value;
                else
                {
                    throw new Exception("Error con los datos de la cantidad de habitantes, verifique. ");
                }
            }
        }

        public string NombreOficial
        {
            get { return nombreOficial; }
            set
            {
                if (value.Length>0 && value.Length <=200)
                    nombreOficial = value;
                else
                    throw new Exception("Error con los datos ingresados para el nombre de la Zona, verifique. ");
            }
        }

        public string Acronimo
        {
            get { return acronimo; }
            set
            {
                if (value.Length == 3)
                { 
                    for(int i = 0; i<3; i++)
                    {
                        if(!(Convert.ToInt32(Convert.ToChar(value[i].ToString())) <=90 && Convert.ToInt32(Convert.ToChar(value[i].ToString())) >= 65))
                            throw new Exception("El acronimo deben ser solo letras");
                    }
                    acronimo = value; 
                }
                else
                {
                    throw new Exception("Deben ser tres las letras que identifiquen la Zona");
                }

            }
        }

        public string IDDepartamento
        {
            get { return idDepartamento; }
            set
            {
                if ((value.Length == 1) && Convert.ToInt32(Convert.ToChar(value.ToString())) <=90 && Convert.ToInt32(Convert.ToChar(value.ToString())) >= 65)
                {
                    idDepartamento = value;
                }
                else
                {
                    throw new Exception(" Ocurrió un error con el Departamento este se identifica con una letra, verifique. ");
                }
            }
        }

        public Zona(string pdepartamento, string pacronimo, string pnombre, int phabitantes, List<Servicio> plistaServ)
        {
            IDDepartamento = pdepartamento;
            Acronimo = pacronimo;
            NombreOficial = pnombre;
            Habitantes = phabitantes;
            Servicios = plistaServ;
        }
    }
}