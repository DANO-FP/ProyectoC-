using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Persistencia
{
    internal class PFuncionario:IFuncionario
    {

        //singleton 
        private static PFuncionario instancia = null;

        //Constructor privado
        private PFuncionario() { }

        //Operacion
        public static PFuncionario GetInstanciaFun()
        {
            if (instancia == null)
                instancia = new PFuncionario();

            return (instancia);
        }

        //Operaciones 
        public void AgregarFuncionario(Funcionario F)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Con);
            SqlCommand _cmd = new SqlCommand("AltaEmpleado", _cnn);
            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.AddWithValue("@empUsuario", F.Nombre);
            _cmd.Parameters.AddWithValue("@empContraseña", F.Password);

            SqlParameter retorno = new SqlParameter("@retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            _cmd.Parameters.Add(retorno);

            try
            {
                _cnn.Open();
                _cmd.ExecuteNonQuery();
                int Afectados = (int)_cmd.Parameters["@retorno"].Value;
                if (Afectados == -1)
                    throw new Exception("Las contraseñas no son iguales");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public void EliminarFuncionario(Funcionario F)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Con);
            SqlCommand _cmd = new SqlCommand("EliminarEmpleado", _cnn);
            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.AddWithValue("@empUsuario", F.Nombre);
            _cmd.Parameters.AddWithValue("@empContraseña", F.Password);
            _cmd.Parameters.AddWithValue("@empContraseña1", F.Password);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _cmd.Parameters.Add(_Retorno);

            try
            {
                _cnn.Open();
                _cmd.ExecuteNonQuery();
                int Afectados = (int)_cmd.Parameters["@Retorno"].Value;
                if (Afectados == -1)
                    throw new Exception("Las contraseñas no son iguales");
                if (Afectados == -2)
                    throw new Exception("El Funcionario no existe");
                if (Afectados == -3)
                    throw new Exception("El Funcionario ya fue eliminado");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public void ModificarFuncionario(Funcionario F)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Con);
            SqlCommand _cmd = new SqlCommand("ModEmpleado", _cnn);
            _cmd.CommandType = CommandType.StoredProcedure;

            _cmd.Parameters.AddWithValue("@empUsuario", F.Nombre);
            _cmd.Parameters.AddWithValue("@empContraseña", F.Password);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;
            _cmd.Parameters.Add(_Retorno);

            try
            {
                _cnn.Open();
                _cmd.ExecuteNonQuery();
                int Afectados = (int)_cmd.Parameters["@Retorno"].Value;
                if (Afectados == -1)
                    throw new Exception("Las contraseñas no son iguales");
                if (Afectados == -2)
                    throw new Exception("El funcionario no existe");
                if (Afectados == -3)
                    throw new Exception("El funcionario no existe");
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public Funcionario Logueo(string F, string P)
        {
            string Usuario, Password;
            Funcionario Fu = null;
            SqlConnection _cnn = new SqlConnection(Conexion.Con);
            SqlCommand _cmd = new SqlCommand("LogueoEmpleado", _cnn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@empUsuario",F);
            _cmd.Parameters.AddWithValue("@Password", P);
            
            SqlParameter retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            retorno.Direction = ParameterDirection.ReturnValue;
            _cmd.Parameters.Add(retorno);
            
            SqlDataReader _Reader;
           
            try
            {
                _cnn.Open();
                _Reader = _cmd.ExecuteReader();
                int afectados = (int)_cmd.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("Error. Usuario - contraseña no coinciden");

                if (_Reader.HasRows)
                {
                    _Reader.Read();
                    Usuario = (string)_Reader["empUsuario"];
                    Password = (string)_Reader["empContraseña"];
                    Fu = new Funcionario(Usuario, Password);
                    _Reader.Close();
                }
               
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return Fu;
        }

        public Funcionario BuscarFuncionario(string F)
        {
            string Usuario;
            string Password;
            // bool Activo;
            Funcionario Fu = null;
            SqlConnection _cnn = new SqlConnection(Conexion.Con);
            SqlCommand _cmd = new SqlCommand("BuscarEmpleadoActivo ", _cnn);
            _cmd.CommandType = CommandType.StoredProcedure;
            _cmd.Parameters.AddWithValue("@empUsuario", F);
            SqlParameter _retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _retorno.Direction = ParameterDirection.ReturnValue;
            _cmd.Parameters.Add(_retorno);
            SqlDataReader _Reader;

            try
            {
                _cnn.Open();
                _Reader = _cmd.ExecuteReader();

               /* int afectados = (int)_cmd.Parameters["@Retorno"].Value;
                if (afectados == -1)
                    throw new Exception("No se encontro el empleado");*/

                if (_Reader.HasRows)
                {
                    _Reader.Read();
                    Usuario = (string)_Reader["empUsuario"];
                    Password = (string)_Reader["empContraseña"];
                    Fu = new Funcionario(Usuario, Password);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return Fu;
        }

        public List<Funcionario> ListarFuncionario()
        {
            string Usuario;
            string Password;
            //bool Active;
            List<Funcionario> ListF = new List<Funcionario>();
            SqlConnection _cnn = new SqlConnection(Conexion.Con);
            SqlCommand _cmd = new SqlCommand("Exec ListarTodosLosEmpleados", _cnn);
            SqlDataReader _Reader;

            try
            {
                _cnn.Open();
                _Reader = _cmd.ExecuteReader();
                while (_Reader.Read())
                {
                    Usuario = (string)_Reader["empUsuario"];
                    Password = (string)_Reader["empContraseña"];
                    //Active = (bool)_Reader["empEliminado"];
                    Funcionario Fu = new Funcionario(Usuario, Password);
                    ListF.Add(Fu);
                }
                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return ListF;
        }
    }
}
