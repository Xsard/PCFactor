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
using GUI;
using GUI.WSUsuarios;

namespace PcFucktor
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void BtnValidar_Click(object sender, RoutedEventArgs e)
        {
            ValidarUsuariosSoapClient validarUsuarios = new ValidarUsuariosSoapClient();
            string email = txtCorreo.Text;
            string pass = txtPassword.Password;
            int validado;

            if (email.Length>0 && pass.Length>0)
            {
                validado = validarUsuarios.ValidarUsuario(email, pass);
                Console.WriteLine(validado);
                if (validado == 1)
                {
                    MainMenu main = new MainMenu();
                    main.Show();
                    Close();
                }
                else if(validado == 2)
                {
                    MainTecnico main = new MainTecnico();
                    main.Show();
                    main.Reparacion(txtCorreo.Text);
                    Close();

                }
                else if(validado == 3)
                {
                    MainCliente main = new MainCliente();
                    main.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("No");
                }
            }
            else
            {
                MessageBox.Show("El correo y la contraseña no coinciden");
            }

        }
    }
}
