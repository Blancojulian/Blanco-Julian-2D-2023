using BibliotecaEntidades.Entidades;
using BibliotecaEntidades.Serializacion;


namespace SegundoParcial
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void GenerarJson()
        {
            try
            {
                var v = new Vendedor("aaa", "sss", 1234, "eee", "ooo");
                v.AgregarCliente(new Cliente("juan", "doe", 123, "aaa@ss", "contrasenia"));
                MessageBox.Show("se genero archivo");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            this.GenerarJson();
        }
    }
}