using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;


namespace Persistencia
{
    internal class PLocalC: ILocalC
    {
        private static PLocalC instancia = null;

        private PLocalC() { }

        public static PLocalC getInstancia()
        {
            if (instancia == null)
                instancia = new PLocalC();
            return instancia;
        }

        public void AltaLocal(LocalComercial loc)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("AltaLocales", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", loc.Padron);
            cmd.Parameters.AddWithValue("@direccion", loc.Direccion);
            cmd.Parameters.AddWithValue("@precio", loc.Precio);
            cmd.Parameters.AddWithValue("@accion", loc.Accion);
            cmd.Parameters.AddWithValue("@cantBaños", loc.CantBaños);
            cmd.Parameters.AddWithValue("@cantHab", loc.CantHabit);
            cmd.Parameters.AddWithValue("@mt2Ed", loc.Mt2Ed);
            cmd.Parameters.AddWithValue("@departamento", loc.Departamento.IDDepartamento);
            cmd.Parameters.AddWithValue("@acronimo", loc.Departamento.Acronimo);
            cmd.Parameters.AddWithValue("@usuario", loc.Usuario.Nombre);
            cmd.Parameters.AddWithValue("@habilitacion", loc.Habilitacion);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;
                if (afectados == 0)
                    throw new Exception("El local comercial ya se dio de alta");
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

        public void ModificarLocal(LocalComercial loc)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ModificarLocales", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", loc.Padron);
            cmd.Parameters.AddWithValue("@direccion", loc.Direccion);
            cmd.Parameters.AddWithValue("@precio", loc.Precio);
            cmd.Parameters.AddWithValue("@accion", loc.Accion);
            cmd.Parameters.AddWithValue("@cantBaños", loc.CantBaños);
            cmd.Parameters.AddWithValue("@cantHab", loc.CantHabit);
            cmd.Parameters.AddWithValue("@mt2Ed", loc.Mt2Ed);
            cmd.Parameters.AddWithValue("@departamento", loc.Departamento.IDDepartamento);
            cmd.Parameters.AddWithValue("@acronimo", loc.Departamento.Acronimo);
            cmd.Parameters.AddWithValue("@usuario", loc.Usuario.Nombre);
            cmd.Parameters.AddWithValue("@habilitacion", loc.Habilitacion);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;
                if (afectados == 0)
                    throw new Exception("El Local Comercial ya se dio de alta");
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

        public LocalComercial BuscarLocal(int padron)
        {
            //atributos de propiedades
            int precio, baños, habitaciones, mt2;
            string direccion, accion, dep, acronimo;
            Zona depa = null;
            Funcionario usu = null;

            IFuncionario perF = PFabrica.GetInstanciaFuncionario();
            IPersistenciaZona perZ = PFabrica.GetInstanciaZona();

            //atributos de locales
            bool habilitacion;
            LocalComercial loc = null;

            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("BuscarLocal ", cnn);
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

                    habilitacion = (bool)lector["locHabilitacion"];
                    precio = (int)lector["proPrecio"];
                    baños = (int)lector["proCantBaños"];
                    habitaciones = (int)lector["proCantHabitaciones"];
                    mt2 = (int)lector["proMt2Ed"];
                    direccion = (string)lector["proDireccion"];
                    accion = (string)lector["proAccion"];

                    dep = (string)lector["zonDepartamento"];
                    acronimo = (string)lector["zonAcronimo"];
                    depa = perZ.BuscarZona(dep, acronimo);

                    string nombre = (string)lector["proUsuario"];
                    usu = perF.BuscarFuncionario(nombre);

                    loc = new LocalComercial(padron, precio, baños, habitaciones, mt2, direccion, accion, depa, usu, habilitacion);
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
            return loc;
        }

        public List<LocalComercial> ListarLocal()
        {
            List<LocalComercial> lista = new List<LocalComercial>();
            int padron, precio, cantBaños, cantHabit, mt2Ed;
            string direccion, acronimo, accion, dep, nombre;
            bool habilitacion;
            Zona departamento;
            Funcionario usuario;
            LocalComercial loc;

            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ListaLocales", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader lector;

            IFuncionario perF = PFabrica.GetInstanciaFuncionario();
            IPersistenciaZona perZ = PFabrica.GetInstanciaZona();
            ILocalC pLoc = PFabrica.getPersistenciaLocal();

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

                        habilitacion = (bool)lector["locHabilitacion"];

                        departamento = perZ.BuscarZona(dep, acronimo);
                        usuario = perF.BuscarFuncionario(nombre);

                        loc = new LocalComercial(padron, precio, cantBaños, cantHabit, mt2Ed, direccion, accion, departamento, usuario, habilitacion);
                        lista.Add(loc);
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
