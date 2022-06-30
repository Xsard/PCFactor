using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using GUI.WSCliente;
using PcFucktor;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();
        }

        private void BtnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            string rut = txtRut.Text.Replace(".", string.Empty);
            if (txtCorreo.Text.Trim().Length > 5)
            {
                if (txtRut.Text.Trim().Length > 0)
                {
                    if (txtNombre.Text.Trim().Length > 0)
                    {
                        if (txtApellido.Text.Trim().Length > 0)
                        {
                            if (txtDireccion.Text.Trim().Length > 0)
                            {
                                if (int.TryParse(txtTelefono.Text, out int fono) && txtTelefono.Text.Trim().Length == 9)
                                {
                                    if (txtPassword.Password.Trim().Length > 0)
                                    {
                                        WClienteSoapClient client = new WClienteSoapClient();
                                        string insertado = client.Insertar(txtCorreo.Text, txtPassword.Password, rut.Trim(), txtNombre.Text, txtApellido.Text, txtDireccion.Text, fono);
                                        MessageBox.Show(insertado, "Registrado");
                                        Login mainMenu = new Login();
                                        mainMenu.Show();
                                        this.Close();
                                    }
                                }
                            }
                        }
                    }
                }

            }

        }
    }
}
