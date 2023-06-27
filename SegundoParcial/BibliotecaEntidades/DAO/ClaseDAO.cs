using BibliotecaEntidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaEntidades.DAO
{
    internal static class ClaseDAO
    {
        private static UsuarioDAO _usuarioDAO;
        private static CorteDAO _corteDAO;
        private static FacturaDAO _facturaDAO;

        static ClaseDAO()
        {
            _usuarioDAO = new UsuarioDAO();
            _corteDAO = new CorteDAO();
            _facturaDAO = new FacturaDAO();
        }

        public static UsuarioDAO UsuarioDAO => _usuarioDAO;
        public static CorteDAO CorteDAO => _corteDAO;
        public static FacturaDAO FacturaDAO => _facturaDAO;

        
    }
}
