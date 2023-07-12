using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using BibliotecaEntidades.Interfaces;

namespace BibliotecaEntidades.DAO
{
    internal class FacturaDAO : BaseDAO<Factura>, IConsultaSQL<Factura, EstadoVenta>
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
                _sqlCommand.CommandText = "SELECT *, CONCAT(Usuario.nombre,' ',Usuario.apellido) AS nombreCompleto FROM Factura LEFT JOIN Usuario ON Factura.dniCliente = Usuario.dni";
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

        public List<Factura> BuscarCoincidencias(string cadena, EstadoVenta filtro)
        {
            List<Factura> lista = new List<Factura>();
            string comando = "SELECT *, CONCAT(Usuario.nombre,' ',Usuario.apellido) AS nombreCompleto FROM Factura " +
                "LEFT JOIN Usuario ON Factura.dniCliente = Usuario.dni (Factura.numeroFactura LIKE @cadena OR " +
                "Factura.dniCliente LIKE @cadena OR Usuario.nombre LIKE @cadena OR Usuario.apellido LIKE " +
                "@cadena OR nombreCompleto LIKE @cadena)";

            if (filtro == EstadoVenta.Pendiente)
            {
                comando += " AND Factura.idEstadoFactura = 0;";

            }
            else if (filtro == EstadoVenta.Realizada)
            {
                comando += " AND Factura.idEstadoFactura = 1;";

            }

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlCommand.CommandText = comando;
                _sqlCommand.Parameters.AddWithValue("@cadena", $"%{cadena}%");
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
                _sqlCommand.CommandText = "SELECT *, CONCAT(Usuario.nombre,' ',Usuario.apellido) AS nombreCompleto FROM Factura LEFT JOIN Usuario ON Factura.dniCliente = Usuario.dni WHERE Factura.numeroFactura = @numeroFactura";
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

            if (factura is not null)
            {
                GetItems(factura);
            }

            return factura;
        }

        public override int Add(Factura datos)
        {
            int filas = 0;
            string comando = "INSERT INTO Factura(numeroFactura, dniCliente, idEstadoFactura, pagoConCredito) VALUES(@numeroFactura, @dniCliente, @idEstadoFactura, @pagoConCredito);";

            try
            {
                _sqlCommand.Parameters.Clear();
                _sqlConnection.Open();

                _sqlCommand.Parameters.AddWithValue("@numeroFactura", datos.NumeroFactura);
                _sqlCommand.Parameters.AddWithValue("@dniCliente", datos.DniCliente);
                _sqlCommand.Parameters.AddWithValue("@idEstadoFactura", (int)datos.Estado);
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
                _sqlCommand.CommandText = "UPDATE Factura SET dniCliente = @dniCliente, idEstadoFactura = @idEstadoFactura, pagoConCredito = @pagoConCredito WHERE numeroFactura = @numeroFactura";


                _sqlCommand.Parameters.AddWithValue("@numeroFactura", numeroFactura);
                _sqlCommand.Parameters.AddWithValue("@dniCliente", datos.DniCliente);
                _sqlCommand.Parameters.AddWithValue("@idEstadoFactura", (int)datos.Estado);
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
                _sqlCommand.CommandText = "DELETE FROM FacturaItem WHERE numeroFactura = @numeroFactura;" + 
                    "DELETE FROM Factura WHERE numeroFactura = @numeroFactura;";

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
                GetItems(factura);
            }
        }

        private void GetItems(Factura factura)
        {
            
            try
            {
                if (factura is not null)
                {
                    _sqlCommand.Parameters.Clear();
                    _sqlCommand.CommandText = "SELECT * FROM FacturaItem LEFT JOIN Corte ON FacturaItem.idCorte = Corte.id WHERE FacturaItem.numeroFactura = @numeroFactura";
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
                _sqlCommand.CommandText = "SELECT MAX(numeroFactura) AS numeroFactura FROM Factura";
                _sqlConnection.Open();

                using (SqlDataReader dataReader = _sqlCommand.ExecuteReader())
                {
                    if (dataReader.Read())
                    {
                        //double monto = r["monto"] is DBNull ? 0d : double.Parse(Convert.ToString(r["monto"]));

                        ultimoNumeroFactura = int.Parse(dataReader["numeroFactura"]?.ToString() ?? "1");
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
            string comando = "SELECT *, CONCAT(Usuario.nombre,' ',Usuario.apellido) AS nombreCompleto FROM Factura LEFT JOIN Usuario ON Factura.dniCliente = Usuario.dni";

            if (estadoVenta == EstadoVenta.Pendiente)
            {
                comando += " WHERE Factura.idEstadoFactura = @idEstadoFactura";
                _sqlCommand.Parameters.AddWithValue("@idEstadoFactura", (int)estadoVenta);
            } else if (estadoVenta == EstadoVenta.Pendiente)
            {
                comando += " WHERE Factura.idEstadoFactura = @idEstadoFactura";
                _sqlCommand.Parameters.AddWithValue("@idEstadoFactura", (int)estadoVenta);
            }

            return comando;
        }
        private string ComandoAddItemsYAgregarParametros(int numeroFactura, Dictionary<int, FacturaItem> listaProductos)
        {
            var sb = new StringBuilder();
            string[] parameters = new string[listaProductos.Count];
            int i = 0;
            //no es necesario agregar parametro para @numeroFactura porque se hace antes en el metodo Add
            foreach (KeyValuePair<int, FacturaItem> producto in listaProductos)
            {
                i++;
                sb.AppendLine($"INSERT INTO FacturaItem VALUES(@numeroFactura, @idCorte{i}, @cantidadKilos{i}, @precioKiloCorte{i});");

                _sqlCommand.Parameters.AddWithValue($"@idCorte{i}", producto.Key);
                _sqlCommand.Parameters.AddWithValue($"@cantidadKilos{i}", producto.Value.CantidadKilos);
                _sqlCommand.Parameters.AddWithValue($"@precioKiloCorte{i}", producto.Value.PrecioKiloCorte);

            }

            return sb.ToString();
        }
    }
}
