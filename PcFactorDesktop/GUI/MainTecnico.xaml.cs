using System;
using System.Collections.Generic;
using System.Data;
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
using GUI.WSFases;
using GUI.WSHistorialTec;
using PcFucktor;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainTecnico.xaml
    /// </summary>
    public partial class MainTecnico : Window
    {
        int IdReparacion = 0;
        public MainTecnico()
        {
            InitializeComponent();
            LlenarFases();

        }
        private void LlenarFases()
        {
            WSFaseSoapClient wSFase = new WSFaseSoapClient();
            DataSet ds = wSFase.Listar();
            cboFases.ItemsSource = ds.Tables[0].DefaultView;
            cboFases.DisplayMemberPath = "DESCRIPCION";
            cboFases.SelectedValuePath = "ID_FASE";
        }
        public void Reparacion(string email)
        {
            WSHistorialSoapClient wHistorial = new WSHistorialSoapClient();
            DataSet data = wHistorial.Buscar(email);
            try
            {
                grdReparacion.Visibility = Visibility.Visible;
                IdReparacion = int.Parse(data.Tables[0].Rows[0]["ID_REPARACION"].ToString());
                IDRep.Content += IdReparacion.ToString();
                Id.Content += data.Tables[0].Rows[0]["ID_DISPOSITIVO"].ToString();
                RutCli.Content += data.Tables[0].Rows[0]["RUT_CLIENTE"].ToString();
                NomCli.Content += data.Tables[0].Rows[0]["CLINOM"].ToString();
                RutAd.Content += data.Tables[0].Rows[0]["RUT_ADMIN"].ToString();
                NomAd.Content += data.Tables[0].Rows[0]["ADMINOM"].ToString();
                txtDesc.Text = data.Tables[0].Rows[0]["DESCRIPCION"].ToString();
                txtEstado.Text = data.Tables[0].Rows[0]["ESTADO"].ToString();
                if (int.Parse(data.Tables[0].Rows[0]["ID_FASE"].ToString()) == 1)
                {
                    lblFase.Visibility = Visibility.Collapsed;
                    cboFases.Visibility = Visibility.Collapsed;
                    lblPrecio.Visibility = Visibility.Visible;
                    txtPrecio.Visibility = Visibility.Visible;
                    btnActualizar.Content = "Generar diagnóstico";
                }
                else if (int.Parse(data.Tables[0].Rows[0]["ID_FASE"].ToString()) == 1)
                {

                }
                else
                {
                    cboFases.SelectedIndex = int.Parse(data.Tables[0].Rows[0]["ID_FASE"].ToString()) - 1;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("No hay reparaciones asignadas");
            }
       }

        private void btnActualizar_Click(object sender, RoutedEventArgs e)
        {
            int updates = 0;
            WSHistorialSoapClient wSHistorial = new WSHistorialSoapClient();
            int id = IdReparacion;
            if (id > 0)
            {
                if (btnActualizar.Content.Equals("Generar diagnóstico"))
                {
                    string desc = txtDesc.Text;
                    string estado = txtEstado.Text;
                    int fase = 2;
                    int precio = int.Parse(txtPrecio.Text);
                    try
                    {
                        updates = wSHistorial.Actualizar(id, desc, estado, fase, precio) + 1;
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (updates > 0)
                    {
                        MessageBox.Show("Actualizado con exito");
                        Login login = new Login();
                        login.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No actaulizado");
                    }
                }
                else
                {
                    string desc = txtDesc.Text;
                    string estado = txtEstado.Text;
                    int fase = cboFases.SelectedIndex;
                    try
                    {
                        updates = wSHistorial.Actualizar(id, desc, estado, fase, 0) + 1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    if (updates > 0)
                    {
                        MessageBox.Show("Actualizado con exito");
                        Login login = new Login();
                        login.Show();
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("No actaulizado");
                    }
                }
            }
            else
            {
                MessageBox.Show("Algo salió mal");
            }
        }
    }
}
