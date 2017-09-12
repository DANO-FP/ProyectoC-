using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{   
    internal class PPropiedad: IPropiedad
    {
        private static PPropiedad instancia = null;

        private PPropiedad() { }

        public static PPropiedad getInstancia()
        {
            if (instancia == null)
                instancia = new PPropiedad();
            return instancia;
        }

        public void EliminarPropiedad(Propiedad prop)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("EliminarPropiedad", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", prop.Padron);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;
                if (afectados == 0)
                    throw new Exception("La propiedad no existe");
                else if (afectados == -1)
                    throw new Exception("Errores en la transaccion");
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
