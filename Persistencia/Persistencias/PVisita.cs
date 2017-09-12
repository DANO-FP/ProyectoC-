using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PVisita : IVisita
    {
        //singleton 
        private static PVisita instancia = null;

        //Constructor privado
        private PVisita() { }

        //Operacion
        public static PVisita getInstancia()
        {
            if (instancia == null)
                instancia = new PVisita();

            return (instancia);
        }

        public void AltaVisita(Visita V)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("AltaVisita", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.AddWithValue("@visNombre", V.Nombre);
            cmd.Parameters.AddWithValue("@visTel", V.Telefono);
            cmd.Parameters.AddWithValue("@visFecha", V.Fecha);
            cmd.Parameters.AddWithValue("@proPardon", V.Propiedad.Padron);
            cmd.Parameters.Add(retorno);

            int afectados = 0;
            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@retorno"].Value;
                if (afectados == -1)
                    throw new Exception("No existe la propiedad");
                else if (afectados == -2)
                    throw new Exception("La propiedad ya esta agendada");
                else if (afectados == -3)
                    throw new Exception("Usted ya tiene visitas agendadas");
                else if (afectados == -4)
                    throw new Exception("La fecha debe ser de hoy hacia adelante");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
    }
}
