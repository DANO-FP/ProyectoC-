using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
    internal class ServicioPersistencia
    {

        //hacer un buscar un servicio si lo encuentra sigo al siguiente si no lo encuentra lo elimino o agrego
        internal static List<Servicio> CargaServicios(string dep, string acron)
        {
            List<Servicio> lista = new List<Servicio>();
            string nombreSer;
            Servicio s = null;

            SqlConnection con = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ListarServ_X_zona", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DEPARTAMENTO", dep);
            cmd.Parameters.AddWithValue("@ACRONIMO", acron);

            SqlDataReader lector;
            try
            {
                con.Open();
                lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        nombreSer = Convert.ToString(lector["nombreServicio"]);
                        s = new Servicio(nombreSer);
                        lista.Add(s);
                    }
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return (lista);
        }

        internal static void AltaServicio(Zona z, Servicio s, SqlTransaction Transaccion)
        {
            SqlCommand cmd = new SqlCommand("AltaServicio", Transaccion.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("@RETORNO", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.AddWithValue("@DEPARTAMENTO", z.IDDepartamento);
            cmd.Parameters.AddWithValue("@ACRONIMO", z.Acronimo);
            cmd.Parameters.AddWithValue("@NOMBRESERVICIO", s.Nombre);
            cmd.Parameters.Add(retorno);

            try
            {
                cmd.Transaction = Transaccion;
                cmd.ExecuteNonQuery();

                int Retorno = Convert.ToInt32(retorno.Value);
                if (Retorno == -1)
                {
                    throw new Exception("La zona a la cual quiere asignar el servicio no existe, verifique. ");
                }
                else if (Retorno == -2)
                {
                    throw new Exception("El servicio ya existe para la zona que se quiere asignar. ");
                }

            }
            catch (Exception er)
            {
                
                throw er;
            }
        }

        internal static void BajaServicio(Zona z, SqlTransaction Transaccion)
        {
            SqlCommand cmd = new SqlCommand("BajaServicio", Transaccion.Connection);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("@RETORNO", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.AddWithValue("@DEPARTAMENTO", z.IDDepartamento);
            cmd.Parameters.AddWithValue("@ACRONIMO", z.Acronimo);
            cmd.Parameters.Add(retorno);

            try
            {
                cmd.Transaction = Transaccion;
                cmd.ExecuteNonQuery();

                int Retorno = Convert.ToInt32(retorno.Value);
                if (Retorno == -1)
                {
                    throw new Exception("La Zona proporcionada no existe en el sistema. ");
                }
            }
            catch (Exception er)
            {
                throw er;
            }
        
        }

       


    }
}
