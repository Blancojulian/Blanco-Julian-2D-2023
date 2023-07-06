using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.DAO
{
    internal class CorteDAO : BaseDAO<Corte>, IConsultaSQL<Corte, Filtros>
    {
        public CorteDAO() : base()
        {

        }

        public override List<Corte> GetAll()
        {
            List<Corte> lista = new List<Corte>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Corte";
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Corte)dataReader);
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

        public List<Corte> GetAll(int[] listaId)
        {
            List<Corte> lista = new List<Corte>();
            string[] parameters = new string[listaId.Length];

            try
            {
                _sqlCommand.Parameters.Clear();

                for (int i = 0; i < listaId.Length; i++)
                {
                    parameters[i] = $"@id{i}";
                    _sqlCommand.Parameters.AddWithValue(parameters[i], listaId[i]);
                }

                _sqlCommand.CommandText = $"SELECT * from Corte WHERE id IN ({string.Join(", ", parameters)})";
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Corte)dataReader);
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

        public List<Corte> GetAll(bool disponile)
        {
            List<Corte> lista = new List<Corte>();
            string comando = "SELECT * FROM Corte";
            comando += disponile ? " WHERE stockKilos > 0" : " WHERE stockKilos <= 0";
            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = comando;
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Corte)dataReader);
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

        public override Corte? Get(int id)
        {
            Corte? corte = null;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Corte WHERE id = @id";
                _sqlCommand.Parameters.AddWithValue("@id", id);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        corte = (Corte)dataReader;
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
            return corte;
        }

        public bool ExisteNombre(string nombre)
        {
            string nombreCorte = "";
            bool retorno = false;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT nombre FROM Corte WHERE nombre = @nombre";
                _sqlCommand.Parameters.AddWithValue("@nombre", nombre);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        nombreCorte = Convert.ToString(dataReader["nombre"]);
                        retorno = nombreCorte == string.Empty ? false : true;
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
            return retorno;
        }
        public List<Corte> BuscarCoincidencias(string cadena, Filtros filtro)
        {
            List<Corte> lista = new List<Corte>();
            string comando = "SELECT * FROM Corte LEFT JOIN Categoria ON Corte.idCategoria = Categoria.id WHERE (Corte.nombre LIKE '%@cadena%' OR Corte.detalle LIKE '%@cadena%' OR Categoria.nombreCategoria LIKE '%@cadena%')";

            if (filtro == Filtros.Disponible)
            {
                comando += " AND Corte.stockKilos > 0;";

            }
            else if (filtro == Filtros.No_Disponible)
            {
                comando += " AND Corte.stockKilos <= 0;";

            }

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = comando;
                _sqlCommand.Parameters.AddWithValue("@cadena", cadena);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Corte)dataReader);
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

        public override int Add(Corte datos)
        {
            int filas = 0;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlConnection.Open();
                _sqlCommand.CommandText = "INSERT INTO Corte VALUES(@nombre, @stockKilos, @precioKilo, @idCategoria, @detalle)";

                _sqlCommand.Parameters.AddWithValue("@nombre", datos.Nombre);
                _sqlCommand.Parameters.AddWithValue("@stockKilos", datos.StockKilos);
                _sqlCommand.Parameters.AddWithValue("@precioKilo", datos.PrecioKilo);
                _sqlCommand.Parameters.AddWithValue("@idCategoria", (int)datos.Categoria);
                _sqlCommand.Parameters.AddWithValue("@detalle", datos.Detalle);


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
        public override int Update(int id, Corte datos)
        {
            int filas = 0;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlConnection.Open();
                _sqlCommand.CommandText = "UPDATE Corte SET nombre = @nombre, stockKilos = @stockKilos, precioKilo = @precioKilo, idCategoria = @idCategoria, @detalle = detalle WHERE id = @id";

                _sqlCommand.Parameters.AddWithValue("@nombre", datos.Nombre);
                _sqlCommand.Parameters.AddWithValue("@stockKilos", datos.StockKilos);
                _sqlCommand.Parameters.AddWithValue("@precioKilo", datos.PrecioKilo);
                _sqlCommand.Parameters.AddWithValue("@idCategoria", (int)datos.Categoria);
                _sqlCommand.Parameters.AddWithValue("@detalle", datos.Detalle);
                _sqlCommand.Parameters.AddWithValue("@id", id);

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
                _sqlConnection.Open();
                _sqlCommand.CommandText = "DELETE FROM Corte WHERE dni = @dni";

                _sqlCommand.Parameters.AddWithValue("@dni", dni);

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
    }
}
