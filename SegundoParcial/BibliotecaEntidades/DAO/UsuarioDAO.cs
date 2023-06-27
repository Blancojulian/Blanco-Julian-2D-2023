using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace BibliotecaEntidades.DAO
{
    internal class UsuarioDAO : BaseDAO<Usuario>
    {
        public UsuarioDAO() : base()
        {

        }

        public override List<Usuario> GetAll()
        {
            List<Usuario> lista = new List<Usuario>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Usuario LEFT JOIN Dinero ON Usuario.dni = Dinero.dniCliente";
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Usuario)dataReader);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return lista;
        }

        public List<T> GetAll<T>() where T : Usuario
        {
            List<T> lista = new List<T>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = ComandoGetAllPorTipoDeUsuario(typeof(T));
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((T)dataReader);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return lista;
        }

        public override Usuario? Get(int dni)
        {
            Usuario? usuario = null;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Usuario LEFT JOIN Dinero ON Usuario.dni = Dinero.dniCliente WHERE Usuario.dni = @dni ";
                _sqlCommand.Parameters.AddWithValue("@dni", dni);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        usuario = (Usuario)dataReader;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }


            return usuario;
        }

        public Usuario? Get(string mail)
        {
            Usuario? usuario = null;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Usuario LEFT JOIN Dinero ON Usuario.dni = Dinero.dniCliente WHERE Usuario.mail = @mail";
                _sqlCommand.Parameters.AddWithValue("@mail", mail);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        usuario = (Usuario)dataReader;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return usuario;
        }

        public Usuario? Get(Usuarios tipoDeUsuario)
        {
            Usuario? usuario = null;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT TOP 1 * FROM Usuario LEFT JOIN Dinero ON Usuario.dni = Dinero.dniCliente WHERE Usuario.idTipoUsuario = @idTipoUsuario";
                _sqlCommand.Parameters.AddWithValue("@idTipoUsuario", (int)tipoDeUsuario);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        usuario = (Usuario)dataReader;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return usuario;
        }
        /// <summary>
        /// Consulta en la base de datos el dinero ingresado del cliente o cero
        /// </summary>
        /// <param name="cliente">Cliente al que se va realizar la consulta</param>
        /// <returns>Retorna el dinero del cliente</returns>
        public double Get(Cliente cliente)
        {
            double dinero = 0;


            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Dinero WHERE dniCliente = @dni ";
                _sqlCommand.Parameters.AddWithValue("@dni", cliente.Dni);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        dinero = Convert.ToDouble(dataReader?.ToString());
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return dinero;
        }

        public override int Add(Usuario datos)
        {
            int filas = 0;
            
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = ComandoAddPorTipoDeUsuarioYAgregarParametros(datos.GetType(), datos);
                _sqlConnection.Open();

                _sqlCommand.Parameters.AddWithValue("@dni", datos.Dni);
                _sqlCommand.Parameters.AddWithValue("@nombre", datos.Nombre);
                _sqlCommand.Parameters.AddWithValue("@apellido", datos.Apellido);
                _sqlCommand.Parameters.AddWithValue("@email", datos.Mail);
                _sqlCommand.Parameters.AddWithValue("@contrasenia", Usuario.DatosLogin(datos));

                filas = _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return filas;
        }
        public override int Update(int dni, Usuario datos)
        {
            int filas = 0;
            string comando = "UPDATE Usuario SET nombre = @nombre, apellido = @apellido, email = @email, contrasenia = @contrasenia WHERE dni = @dni;";

            try
            {
                _sqlCommand.Parameters.Clear();
                
                _sqlCommand.Parameters.AddWithValue("@dni", dni);
                _sqlCommand.Parameters.AddWithValue("@nombre", datos.Nombre);
                _sqlCommand.Parameters.AddWithValue("@apellido", datos.Apellido);
                _sqlCommand.Parameters.AddWithValue("@email", datos.Mail);
                _sqlCommand.Parameters.AddWithValue("@contrasenia", Usuario.DatosLogin(datos));

                if (datos.GetType() == typeof(Cliente))
                {
                    _sqlCommand.Parameters.AddWithValue("@monto", (float)((Cliente)datos).Dinero);
                    comando += " UPDATE Dinero SET monto = @monto WHERE dniCliente = @dni;";
                }

                _sqlCommand.CommandText = comando;
                _sqlConnection.Open();

                filas = _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return filas;
        }
        public override int Delete(int dni)
        {
            int filas = 0;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "DELETE FROM Usuario WHERE dni = @dni;" +
                    "DELETE FROM Dinero WHERE dniCliente = @dni;";
                _sqlCommand.Parameters.AddWithValue("@dni", dni);
                _sqlConnection.Open();

                filas = _sqlCommand.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (_sqlConnection.State == ConnectionState.Open)
                {
                    _sqlConnection.Close();
                }
            }

            return filas;
        }


        private string ComandoGetAllPorTipoDeUsuario(Type tipo)
        {
            string command = "SELECT * FROM Usuario LEFT JOIN Dinero ON Usuario.dni = Dinero.dniCliente";

            if (typeof(Vendedor) == tipo)
            {
                command += $" WHERE idTipoUsuario = @idTipoUsuario";
                _sqlCommand.Parameters.AddWithValue("@idTipoUsuario", (int)Usuarios.Vendedor);

            }
            else if (typeof(Cliente) == tipo)
            {
                command += $" WHERE idTipoUsuario = @idTipoUsuario";
                _sqlCommand.Parameters.AddWithValue("@idTipoUsuario", (int)Usuarios.Cliente);

            }

            return command;
        }

        private string ComandoAddPorTipoDeUsuarioYAgregarParametros(Type tipo, Usuario datos)
        {
            string comando = "INSERT INTO Usuario(dni, nombre, apellido, email, contrasenia, idTipoUsuario) VALUES(@dni, @nombre, @apellido, @email, @contrasenia, @idTipoUsuario);";

            string command = "SELECT * FROM Usuario LEFT JOIN Dinero ON Usuario.dni = Dinero.dniCliente";

            if (typeof(Vendedor) == tipo)
            {
                _sqlCommand.Parameters.AddWithValue("@idTipoUsuario", (int)Usuarios.Vendedor);

            }
            else if (typeof(Cliente) == tipo)
            {
                command += $"INSERT INTO Dinero(dniCliente, monto) VALUES(@dniCliente, @monto)";

                _sqlCommand.Parameters.AddWithValue("@idTipoUsuario", (int)Usuarios.Cliente);
                _sqlCommand.Parameters.AddWithValue("@monto", (float)((Cliente)datos).Dinero);


            }

            return command;
        }
    }
}
