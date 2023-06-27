using BibliotecaEntidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.DAO
{
    public abstract class BaseDAO<T> : ICRUD<T>
    {
        protected SqlConnection _sqlConnection;
        protected SqlCommand _sqlCommand;

        public BaseDAO()
        {
            _sqlConnection = new SqlConnection(@"
                Data Source = .;
                Database = db_prueba_labo_2;
                Trusted_Connection = True;
            ");
            _sqlCommand = new SqlCommand();
            _sqlCommand.Connection = _sqlConnection;
            _sqlCommand.CommandType = System.Data.CommandType.Text;
        }

        public abstract List<T> GetAll();
        public abstract T? Get(int id);
        public abstract int Add(T datos);
        public abstract int Update(int id, T datos);
        public abstract int Delete(int id);
    }
}
