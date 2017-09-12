using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace Persistencia
{
    internal class PCasa: ICasa
    {
        private static PCasa instancia = null;

        private PCasa() { }

        public static PCasa getInstancia()
        {
            if (instancia == null)
                instancia = new PCasa();
            return instancia;
        }

        public void AltaCasa(Casa cas)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("AltaCasa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", cas.Padron);
            cmd.Parameters.AddWithValue("@direccion", cas.Direccion);
            cmd.Parameters.AddWithValue("@precio", cas.Precio);
            cmd.Parameters.AddWithValue("@accion", cas.Accion);
            cmd.Parameters.AddWithValue("@cantBaños", cas.CantBaños);
            cmd.Parameters.AddWithValue("@cantHab", cas.CantHabit);
            cmd.Parameters.AddWithValue("@mt2Ed", cas.Mt2Ed);
            cmd.Parameters.AddWithValue("@departamento", cas.Departamento.IDDepartamento);
            cmd.Parameters.AddWithValue("@acronimo", cas.Departamento.Acronimo);
            cmd.Parameters.AddWithValue("@usuario", cas.Usuario.Nombre);
            cmd.Parameters.AddWithValue("@mt2Ter", cas.Mt2Terr);
            cmd.Parameters.AddWithValue("@jardin", cas.Patio);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;
                if (afectados == 0)
                    throw new Exception("La Casa ya se dio de alta");
                else if (afectados == -1)
                    throw new Exception("Errores en la transaccion");
                else if (afectados == -2)
                    throw new Exception("La propiedad ya existe");
                else if (afectados == -3)
                    throw new Exception("La zona no existe");
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

        public void ModificarCasa(Casa cas)
        {
            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ModificarCasa", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlParameter RETORNO = new SqlParameter("@RETORNO", SqlDbType.Int);
            RETORNO.Direction = ParameterDirection.ReturnValue;

            int afectados = -1;

            cmd.Parameters.AddWithValue("@padron", cas.Padron);
            cmd.Parameters.AddWithValue("@direccion", cas.Direccion);
            cmd.Parameters.AddWithValue("@precio", cas.Precio);
            cmd.Parameters.AddWithValue("@accion", cas.Accion);
            cmd.Parameters.AddWithValue("@cantBaños", cas.CantBaños);
            cmd.Parameters.AddWithValue("@cantHab", cas.CantHabit);
            cmd.Parameters.AddWithValue("@mt2Ed", cas.Mt2Ed);
            cmd.Parameters.AddWithValue("@departamento", cas.Departamento.IDDepartamento);
            cmd.Parameters.AddWithValue("@acronimo", cas.Departamento.Acronimo);
            cmd.Parameters.AddWithValue("@usuario", cas.Usuario.Nombre);
            cmd.Parameters.AddWithValue("@mt2Ter", cas.Mt2Terr);
            cmd.Parameters.AddWithValue("@jardin", cas.Patio);
            cmd.Parameters.Add(RETORNO);

            try
            {
                cnn.Open();
                cmd.ExecuteNonQuery();
                afectados = (int)cmd.Parameters["@RETORNO"].Value;

                if (afectados == 0)
                    throw new Exception("La Casa ya se dio de alta");
                else if (afectados == -1)
                    throw new Exception("Errores en la transaccion");
                else if (afectados == -2)
                    throw new Exception("La propiedad ya existe");
                else if (afectados == -3)
                    throw new Exception("La zona no existe");
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

        public Casa BuscarCasa(int padron)
        {
            //atributos de propiedades
            int precio, baños, habitaciones, mt2;
            string direccion, accion, dep, acronimo;
            Zona depa = null;
            Funcionario usu = null;

            //atributos de casa
            int mt2Terr;
            bool jardin;

            Casa casita = null;

            IFuncionario perF = PFabrica.GetInstanciaFuncionario();
            IPersistenciaZona perZ = PFabrica.GetInstanciaZona();

            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("BuscarCasa ", cnn);
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
                    precio = (int)lector["proPrecio"];
                    baños = (int)lector["proCantBaños"];
                    habitaciones = (int)lector["proCantHabitaciones"];
                    mt2 = (int)lector["proMt2Ed"];
                    direccion = (string)lector["proDireccion"];
                    accion = (string)lector["proAccion"];
                    mt2Terr = (int)lector["casMt2Ter"];
                    jardin = (bool)lector["casJardin"];

                    dep = (string)lector["zonDepartamento"];
                    acronimo = (string)lector["zonAcronimo"];
                    depa = perZ.BuscarZona(dep, acronimo);

                    string nombre = (string)lector["proUsuario"];
                    usu = perF.BuscarFuncionario(nombre);

                    casita = new Casa(padron, precio, baños, habitaciones, mt2, direccion, accion, depa, usu, mt2Terr, jardin);
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
            return casita;
        }

        public List<Casa> ListarCasas()
        {
            List<Casa> lista = new List<Casa>();
            int padron, precio, cantBaños, cantHabit, mt2Ed, mt2terr;
            string direccion, acronimo, accion, dep, nombre;
            bool patio;
            Zona departamento;
            Funcionario usuario;
            Casa casa;

            SqlConnection cnn = new SqlConnection(Conexion.Con);
            SqlCommand cmd = new SqlCommand("ListaCasas", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader lector;

            IFuncionario perF = PFabrica.GetInstanciaFuncionario();
            IPersistenciaZona perZ = PFabrica.GetInstanciaZona();
            ICasa pCas = PFabrica.getPersistenciaCasa();

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

                        mt2terr = (int)lector["casMt2Ter"];
                        patio = (bool)lector["casJardin"];

                        departamento = perZ.BuscarZona(dep, acronimo);
                        usuario = perF.BuscarFuncionario(nombre);

                        casa = new Casa(padron, precio, cantBaños, cantHabit, mt2Ed, direccion, accion, departamento, usuario, mt2terr, patio);
                        lista.Add(casa);
                    }
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                cnn.Close();
            }

            return lista;
        }
    }
}
