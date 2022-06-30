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
using GUI.WSTecnico;
using GUI.WSAdmin;
using GUI.WSHistorialTec;
using GUI.WDispositivo;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Window
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private static Random random = new Random();
        private void btnMenuClientes_Click(object sender, RoutedEventArgs e)
        {
            gridClientes.Visibility = Visibility.Visible;
            gridTec.Visibility = Visibility.Collapsed;
            gridAdmin.Visibility = Visibility.Collapsed;
            gridDispo.Visibility = Visibility.Collapsed;
            try
            {
                WClienteSoapClient client = new WClienteSoapClient();
                var Clientes = client.Listar();
                dtgCli.ItemsSource = Clientes.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnTec_Click(object sender, RoutedEventArgs e)
        {
            gridClientes.Visibility = Visibility.Collapsed;
            gridTec.Visibility = Visibility.Visible;
            gridAdmin.Visibility = Visibility.Collapsed;
            gridDispo.Visibility = Visibility.Collapsed;
            try
            {
                WTecnicoSoapClient wTecnico = new WTecnicoSoapClient();
                var Tecnicos = wTecnico.Listar();
                dtgTec.ItemsSource = Tecnicos.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdmin_Click(object sender, RoutedEventArgs e)
        {
            gridClientes.Visibility = Visibility.Collapsed;
            gridTec.Visibility = Visibility.Collapsed;
            gridAdmin.Visibility = Visibility.Visible;
            gridDispo.Visibility = Visibility.Collapsed;
            try
            {
                WAdminSoapClient wAdmin = new WAdminSoapClient();
                var Admins = wAdmin.Listar();
                dtgAdmin.ItemsSource = Admins.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddCli_Click(object sender, RoutedEventArgs e)
        {
            string Rut = txtRutCliente.Text;
            string Nombre = txtNombreCliente.Text;
            string Apellido = txtApellidoCliente.Text;
            string Direccion = txtDireccionCli.Text;
            string Email = txtEmailCli.Text;
            if (Rut.Trim().Length > 8)
            {
                Rut = Rut.Replace(".", "").ToUpper();
                if (Nombre.Trim().Length > 0)
                {
                    if (Apellido.Trim().Length > 0)
                    {
                        if (Direccion.Trim().Length > 0)
                        {
                            if (Email.Trim().Length > 5)
                            {
                                if (int.TryParse(txtTelefonoCli.Text, out int Fono) && txtTelefonoCli.Text.Trim().Length == 9)
                                {
                                    try
                                    {
                                        var wCliente = new WClienteSoapClient();
                                        string insertado = wCliente.Insertar(Email, txtPass.Password, Rut, Nombre, Apellido, Direccion, Fono);
                                        MessageBox.Show(insertado);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El número no es válido");
                                }
                            }
                        }
                    }
                }
            }
 
        }

        private void btnAddAdmin_Click(object sender, RoutedEventArgs e)
        {
            string Rut = txtRutAdmin.Text;
            string Nombre = txtNombreAdmin.Text;
            string Apellido = txtApellidoAdmin.Text;
            string Email = txtEmailAdmin.Text;
            if (Rut.Trim().Length > 8)
            {
                Rut = Rut.Replace(".", "").ToUpper();
                if (Nombre.Trim().Length > 0)
                {
                    if (Apellido.Trim().Length > 0)
                    {
                        if (Email.Trim().Length > 5)
                        {
                            if (int.TryParse(txtFonoAdmin.Text, out int Fono) && txtFonoAdmin.Text.Trim().Length == 9)
                            {
                                string pass = txtPassAdmin.Password;
                                try
                                {
                                    WAdminSoapClient wAdmin = new WAdminSoapClient();
                                    string insertado = wAdmin.Insertar(Email, pass, Rut, Nombre, Apellido, Fono);
                                    MessageBox.Show(insertado);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El número no es válido");
                            }
                        }
                    }                    
                }
            }
        }
        private void btnAddTec_Click(object sender, RoutedEventArgs e)
        {
            string Rut = txtRutTec.Text;
            string Nombre = txtNombreTec.Text;
            string Apellido = txtApellidoTec.Text;
            string Email = txtEmailTec.Text;
            if (Rut.Trim().Length > 8)
            {
                Rut = Rut.Replace(".", "").ToUpper();
                if (Nombre.Trim().Length > 0)
                {
                    if (Apellido.Trim().Length > 0)
                    {
                        if (Email.Trim().Length > 5)
                        {
                            if (int.TryParse(txtFonoTec.Text, out int Fono) && txtFonoTec.Text.Trim().Length == 9)
                            {
                                string pass = txtPassTec.Password;
                                try
                                {
                                    WTecnicoSoapClient wTecnico = new WTecnicoSoapClient();
                                    string insertado = wTecnico.Insertar(Email, pass, Rut, Nombre, Apellido, Fono);
                                    MessageBox.Show(insertado);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El número no es válido");
                            }
                        }
                    }
                }
            }
        }
        private void btnDispositivos_Click(object sender, RoutedEventArgs e)
        {
            gridClientes.Visibility = Visibility.Collapsed;
            gridTec.Visibility = Visibility.Collapsed;
            gridAdmin.Visibility = Visibility.Visible;
            gridDispo.Visibility = Visibility.Visible;
            try
            {
                WDispositivoSoapClient wDispositivo = new WDispositivoSoapClient();
                var Dispositivo = wDispositivo.Listar();
                dtgDispo.ItemsSource = Dispositivo.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void btnHistorial_Click(object sender, RoutedEventArgs e)
        {
            string RutCli = txtRutDis.Text;
            string RutTec = txtRutTecDis.Text;
            string RutAdmin = txtRutAdminDis.Text;
            string Estado = txtEstadoDis.Text;
            string Desc = txtDescDis.Text;
            try
            {
                WSHistorialSoapClient wHistorial = new WSHistorialSoapClient();
                int insertado = wHistorial.Insertar(RutCli, RutAdmin, RutTec, Estado, Desc);
                if (insertado > 0)
                {
                    MessageBox.Show("Se ha generado con éxtio el hisotial");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
