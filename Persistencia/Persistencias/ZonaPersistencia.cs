using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Persistencia
{
    internal class ZonaPersistencia:IPersistenciaZona
    {
        private static ZonaPersistencia instancia = null;

        private ZonaPersistencia() { }

        public static ZonaPersistencia GetPersZona
        {
            get
            {
                if (instancia == null)
                {
                    instancia = new ZonaPersistencia();
                }
                return instancia;
            }
        }


        public Zona BuscarZona(string dep, string acronimo)
        {

            string depart, acron, nombreOf;
            int habitantes;
            Zona z = null;
            List<Servicio> listaServ = new List<Servicio>();

            SqlConnection con = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("BuscarZona", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@DEPARTAMENTO", dep);
            cmd.Parameters.AddWithValue("@ACRONIMO", acronimo);

            SqlDataReader lector;

            try
            {
                con.Open();
                lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        depart = Convert.ToString(lector["departamento"]);
                        acron = Convert.ToString(lector["acronZona"]);
                        nombreOf = Convert.ToString(lector["nombreOficial"]);
                        habitantes = Convert.ToInt32(lector["habitantes"]);
                        listaServ = ServicioPersistencia.CargaServicios(depart, acron);
                        z = new Zona(depart, acron, nombreOf, habitantes, listaServ);
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
            return (z);
        }


        public void AltaZona(Zona z)
        {
            SqlConnection con = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("AltaZona", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("@RETORNO", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.AddWithValue("@DEPARTAMENTO", z.IDDepartamento);
            cmd.Parameters.AddWithValue("@ACRONIMO", z.Acronimo);
            cmd.Parameters.AddWithValue("@NOMBREOFICIAL", z.NombreOficial);
            cmd.Parameters.AddWithValue("@HABITANTES", z.Habitantes);
            cmd.Parameters.Add(retorno);

            SqlTransaction Transaccion = null;
            try
            {
                con.Open();
                Transaccion = con.BeginTransaction();
                cmd.Transaction = Transaccion;
                cmd.ExecuteNonQuery();

                int Retorno = Convert.ToInt32(retorno.Value);
                if (Retorno == -1)
                {
                    throw new Exception("La Zona para el departamento ingresado ya existe en le sistema, no se da de alta. ");
                }
                else if (Retorno == -2)
                {
                    throw new Exception("ERROR!! Uno de los datos ingresados no es correcto, verifique todos los campos. ");
                }

                foreach (Servicio s in z.Servicios)
                {
                    ServicioPersistencia.AltaServicio(z, s, Transaccion);
                }

                Transaccion.Commit();
            }
            catch (Exception er)
            {
                Transaccion.Rollback();
                throw er;
            }
            finally
            {
                con.Close();
            }
        }

        
        public void BajaZona(Zona z)
        {
            SqlConnection con = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("BajaZona", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("@RETORNO", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.AddWithValue("@DEPARTAMENTO", z.IDDepartamento);
            cmd.Parameters.AddWithValue("@ACRONIMO", z.Acronimo);
            cmd.Parameters.Add(retorno);

           
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
             
                int Retorno = Convert.ToInt32(retorno.Value);
                if (Retorno == -1)
                {
                    throw new Exception("La Zona no se puede eliminar o deshabilitar porque no existe. ");
                }
                else if (Retorno == -2)
                {
                    throw new Exception("La Zona no se puede eliminar tiene registros asociados. ");
                }
                else if (Retorno == -3)
                {
                    throw new Exception("La Zona no se puede eliminar ocurrión un error. ");
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
        }


        public void ModificaZona(Zona z)
        {
            SqlConnection con = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ModZona", con);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter retorno = new SqlParameter("@RETORNO", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;

            cmd.Parameters.AddWithValue("@DEPARTAMENTO",z.IDDepartamento);
            cmd.Parameters.AddWithValue("@ACRONIMO",z.Acronimo);
            cmd.Parameters.AddWithValue("@NOMBREOFICIAL",z.NombreOficial);
            cmd.Parameters.AddWithValue("@HABITANTES", z.Habitantes);
            cmd.Parameters.Add(retorno);

            SqlTransaction transaccion = null;

            try
            {

                con.Open();
                transaccion = con.BeginTransaction();
                cmd.Transaction = transaccion;
                cmd.ExecuteNonQuery();

                int Retorno = Convert.ToInt32(retorno.Value);
                if (Retorno == -1)
                {
                    throw new Exception("La Zona que desea modificar no existe en el sistema, verifique. ");
                }
                if (Retorno == -2)
                {
                    throw new Exception("La Zona que desea modificar está deshabilitada, verifique. ");
                }
                if (Retorno == -3)
                {
                    throw new Exception("Ocurrió un error en el procedimiento, verifique. ");
                }
               
                transaccion.Commit();
            }
            catch (Exception er)
            {
                transaccion.Rollback();
                throw er;
            }
            finally
            {
                con.Close();
            }
        }


       public void ModificarServicios(Zona z)
        {
            SqlConnection con = new SqlConnection(Conexion.Con);
            SqlTransaction Transaccion = null;

            try
            {
                con.Open();
                Transaccion = con.BeginTransaction();

                ServicioPersistencia.BajaServicio(z, Transaccion);

                foreach (Servicio s in z.Servicios)
                {
                    ServicioPersistencia.AltaServicio(z, s, Transaccion);
                }

                Transaccion.Commit();
            }
            catch (Exception er)
            {
                Transaccion.Rollback();
                throw er;
            }
            finally
            {
                con.Close();
            }

        }

    }
}
