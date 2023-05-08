using BibliotecaEntidades.Entidades;
using ParcialCarniceria.Forms;

namespace ParcialCarniceria
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new FrmCorte("algo",new BibliotecaEntidades.Entidades.DetalleCorte(10, 30, Categorias.Tercera)));
            var compra = new Compra();
            compra.AgregarProducto("Aguja",50.14);
            compra.AgregarProducto("Bola de Lomo", 10.5);
            compra.AgregarProducto("Falda", 20.22);
            compra.Credito = false;

            Application.Run( new FrmLogin() );
        }
    }
}