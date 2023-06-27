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
    internal class FacturaDAO : BaseDAO<Factura>
    {
        public FacturaDAO() : base()
        {

        }

        public override List<Factura> GetAll()
        {
            List<Factura> lista = new List<Factura>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Factura";
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Factura)dataReader);
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

            GetItemsParaFacturas(lista);

            return lista;
        }

        public List<Factura> GetAll(EstadoVenta estadoVenta)
        {
            List<Factura> lista = new List<Factura>();

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = ComandoGetAllPorEstadoVenta(estadoVenta);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    while (dataReader.Read())
                    {
                        lista.Add((Factura)dataReader);
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

            GetItemsParaFacturas(lista);

            return lista;
        }

        public override Factura? Get(int numeroFactura)
        {
            Factura? factura = null;


            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT * FROM Factura WHERE numeroFactura = @numeroFactura";
                _sqlCommand.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        factura = (Factura)dataReader;
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

            GetItems(factura);

            return factura;
        }

        public override int Add(Factura datos)
        {
            int filas = 0;
            string comando = "INSERT INTO Factura VALUES(@numeroFactura, @dniCliente, @vendido, @pagoConCredito);";

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlConnection.Open();

                _sqlCommand.Parameters.AddWithValue("@numeroFactura", datos.NumeroFactura);
                _sqlCommand.Parameters.AddWithValue("@dniCliente", datos.DniCliente);
                _sqlCommand.Parameters.AddWithValue("@vendido", datos.Vendido);
                _sqlCommand.Parameters.AddWithValue("@pagoConCredito", datos.Credito);

                if (datos.Productos.Count > 0)
                {
                    comando += ComandoAddItemsYAgregarParametros(datos.NumeroFactura, datos.Productos);
                }

                _sqlCommand.CommandText = comando;


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
        public override int Update(int numeroFactura, Factura datos)
        {
            int filas = 0;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlConnection.Open();
                _sqlCommand.CommandText = "UPDATE Factura SET dniCliente = @dniCliente, vendido = @vendido, pagoConCredito = @pagoConCredito WHERE numeroFactura = @numeroFactura";


                _sqlCommand.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                _sqlCommand.Parameters.AddWithValue("@dniCliente", datos.DniCliente);
                _sqlCommand.Parameters.AddWithValue("@vendido", datos.Vendido);
                _sqlCommand.Parameters.AddWithValue("@pagoConCredito", datos.Credito);

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
        //ver si hacer baja logica
        public override int Delete(int numeroFactura)
        {
            int filas = 0;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlConnection.Open();
                _sqlCommand.CommandText = "DELETE FROM Factura WHERE numeroFactura = @numeroFactura;" +
                    "DELETE FROM FacturaItem WHERE numeroFactura = @numeroFactura;";

                _sqlCommand.Parameters.AddWithValue("@numeroFactura", numeroFactura);

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

        private void GetItemsParaFacturas(List<Factura> lista)
        {
            foreach (Factura factura in lista)
            {
                Task.Run(() =>
                {
                    GetItems(factura);
                });
            }
        }

        private void GetItems(Factura factura)
        {

            try
            {
                if (factura is not null)
                {
                    _sqlCommand.Parameters.Clear();
                    _sqlCommand.CommandText = "SELECT * FROM FacturaItem WHERE numeroFactura = @numeroFactura";
                    _sqlCommand.Parameters.AddWithValue("@numeroFactura", factura.NumeroFactura);
                    _sqlConnection.Open();

                    using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            factura.AgregarProducto(dataReader);
                        }
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

        }
        public int GetUltimoNumeroFactura()
        {
            int ultimoNumeroFactura = 0;

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = "SELECT MAX(numeroFactura) FROM Factura";
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        ultimoNumeroFactura = int.Parse(dataReader["numeroFactura"]?.ToString());
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
            return ultimoNumeroFactura;
        }

        private string ComandoGetAllPorEstadoVenta(EstadoVenta estadoVenta)
        {
            string comando = "SELECT * FROM Factura";

            if (estadoVenta == EstadoVenta.En_Proceso)
            {
                comando += " WHERE vendido = @vendido";
                _sqlCommand.Parameters.AddWithValue("@vendido", false);
            } else if (estadoVenta == EstadoVenta.En_Proceso)
            {
                comando += " WHERE vendido = @vendido";
                _sqlCommand.Parameters.AddWithValue("@vendido", true);
            }

            return comando;
        }
        private string ComandoAddItemsYAgregarParametros(int numeroFactura, Dictionary<int, double> listaProductos)
        {
            var sb = new StringBuilder();
            string[] parameters = new string[listaProductos.Count];
            int i = 0;
            //no es necesario agregar parametro para @numeroFactura porque se hace antes en el metodo Add
            foreach (KeyValuePair<int, double> producto in listaProductos)
            {
                i++;
                sb.AppendLine($"INSERT INTO Corte VALUES(@numeroFactura, @idCorte{i}, @cantidadKilos{i});");

                _sqlCommand.Parameters.AddWithValue($"@idCorte{i}", producto.Key);
                _sqlCommand.Parameters.AddWithValue($"@cantidadKilos{i}", producto.Key);

            }

            return sb.ToString();
        }
    }
}
