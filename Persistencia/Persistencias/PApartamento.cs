
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PApartamento: IApartamento
    {
        private static PApartamento instancia = null;

        private PApartamento() { }

        public static PApartamento getInstancia()
        {
            if (instancia == null)
                instancia = new PApartamento();
            return instancia;
        }

        public void AltaApartamento(Apartamento ap)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("AltaApartamentos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", ap.Padron);
            cmd.Parameters.AddWithValue("@direccion", ap.Direccion);
            cmd.Parameters.AddWithValue("@precio", ap.Precio);
            cmd.Parameters.AddWithValue("@accion", ap.Accion);
            cmd.Parameters.AddWithValue("@cantBaños", ap.CantBaños);
            cmd.Parameters.AddWithValue("@cantHab", ap.CantHabit);
            cmd.Parameters.AddWithValue("@mt2Ed", ap.Mt2Ed);
            cmd.Parameters.AddWithValue("@departamento", ap.Departamento.IDDepartamento);
            cmd.Parameters.AddWithValue("@acronimo", ap.Departamento.Acronimo);
            cmd.Parameters.AddWithValue("@usuario", ap.Usuario.Nombre);
            cmd.Parameters.AddWithValue("@piso", ap.Piso);
            cmd.Parameters.AddWithValue("@ascensor", ap.Ascensor);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;
                if (afectados == 0)
                    throw new Exception("El apartamento ya se dio de alta");
                else if (afectados == -1)
                    throw new Exception("Errores en la transaccion");
                else if (afectados == -2)
                    throw new Exception("No existe la zona");
                else if (afectados == -3)
                    throw new Exception("No existe el usuario");
                else if (afectados == -4)
                    throw new Exception("El empleado no existe");
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

        public void ModificarApartamento(Apartamento ap)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ModificarApartamento", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", ap.Padron);
            cmd.Parameters.AddWithValue("@direccion", ap.Direccion);
            cmd.Parameters.AddWithValue("@precio", ap.Precio);
            cmd.Parameters.AddWithValue("@accion", ap.Accion);
            cmd.Parameters.AddWithValue("@cantBaños", ap.CantBaños);
            cmd.Parameters.AddWithValue("@cantHab", ap.CantHabit);
            cmd.Parameters.AddWithValue("@mt2Ed", ap.Mt2Ed);
            cmd.Parameters.AddWithValue("@departamento", ap.Departamento.IDDepartamento);
            cmd.Parameters.AddWithValue("@acronimo", ap.Departamento.Acronimo);
            cmd.Parameters.AddWithValue("@usuario", ap.Usuario.Nombre);
            cmd.Parameters.AddWithValue("@piso", ap.Piso);
            cmd.Parameters.AddWithValue("@ascensor", ap.Ascensor);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;
                if (afectados == 0)
                    throw new Exception("El apartamento no existe");
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

        public Apartamento BuscarApartamento(int padron)
        {
            int piso, precio, baños, habitaciones, mt2;
            bool ascensor;
            string direccion, accion, dep, acronimo;
            Zona depa = null;
            Funcionario usu = null;
            Apartamento apto = null;

            IFuncionario perF = PFabrica.GetInstanciaFuncionario();
            IPersistenciaZona perZ = PFabrica.GetInstanciaZona();

            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("BuscarApto", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@padron", padron);

            SqlDataReader lector;

            try
            {
                cnn.Open();
                lector = cmd.ExecuteReader();

                if (lector.HasRows)
                {
                    lector.Read();
                    piso = (int)lector["apaPiso"];
                    precio = (int)lector["proPrecio"];
                    baños = (int)lector["proCantBaños"];
                    habitaciones = (int)lector["proCantHabitaciones"];
                    mt2 = (int)lector["proMt2Ed"];
                    ascensor = (bool)lector["apaAsc"];
                    direccion = (string)lector["proDireccion"];
                    accion = (string)lector["proAccion"];

                    dep = (string)lector["zonDepartamento"];
                    acronimo = (string)lector["zonAcronimo"];
                    depa = perZ.BuscarZona(dep, acronimo);

                    string nombre = (string)lector["proUsuario"];
                    usu = perF.BuscarFuncionario(nombre);

                    apto = new Apartamento(padron, precio, baños, habitaciones, mt2, direccion, accion, depa, usu, piso, ascensor);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
            return apto;
        }

        public List<Apartamento> ListarApartamentos()
        {
            List<Apartamento> lista = new List<Apartamento>();
            int padron, precio, cantBaños, cantHabit, mt2Ed, piso;
            string direccion, acronimo, accion, dep, nombre;
            bool ascensor;
            Zona departamento;
            Funcionario usuario;
            Apartamento apto;

            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ListaApartamentos", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader lector;

            IFuncionario perF = PFabrica.GetInstanciaFuncionario();
            IPersistenciaZona perZ = PFabrica.GetInstanciaZona();
            IApartamento perA = PFabrica.getPersistenciaApartamento();

            try
            {
                cnn.Open();
                lector = cmd.ExecuteReader();
                if (lector.HasRows)
                {
                    while (lector.Read())
                    {
                        padron = (int)lector["proPadron"];
                        precio = (int)lector["proPrecio"];
                        cantBaños = (int)lector["proCantBaños"];
                        cantHabit = (int)lector["proCantHabitaciones"];
                        mt2Ed = (int)lector["proMt2Ed"];
                        direccion = (string)lector["proDireccion"];
                        accion = (string)lector["proAccion"];

                        dep = (string)lector["zonDepartamento"];
                        acronimo = (string)lector["zonAcronimo"];
                        nombre = (string)lector["proUsuario"];

                        piso = (int)lector["apaPiso"];
                        ascensor = (bool)lector["apaAsc"];

                        departamento = perZ.BuscarZona(dep, acronimo);
                        usuario = perF.BuscarFuncionario(nombre);

                        apto = new Apartamento(padron, precio, cantBaños, cantHabit, mt2Ed, direccion, accion, departamento, usuario, piso, ascensor);
                        lista.Add(apto);
                    }

                    lector.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }

            return lista;
        }
    }
}
