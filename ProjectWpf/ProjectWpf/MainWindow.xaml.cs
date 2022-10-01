using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectWpf
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection ConexionSql;
        public MainWindow()
        {
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["ProjectWpf.Properties.Settings.BaseDatosConnectionString"].ConnectionString;

            ConexionSql = new SqlConnection(conexion);
            MuestraEspecialista();
            MuestraTurnos();
        }


        #region Mostrar
        public void MuestraEspecialista()
        {
            string consulta = "SELECT *, CONCAT(especialidad,' - ',apellido,' ',nombre ) AS DATOCOMPLETO FROM ESPECIALISTA";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConexionSql);

            using (adapter)
            {
                DataTable especialistaTabla = new DataTable();
                adapter.Fill(especialistaTabla);

                cmbEspecialista.DisplayMemberPath = "DATOCOMPLETO";
                cmbEspecialista.SelectedValuePath = "Id";
                cmbEspecialista.ItemsSource = especialistaTabla.DefaultView;
            }
        }
        public void MuestraTurnos()
        {

            string consulta = "SELECT p.Id, p.NOMBRE, p.APELLIDO, p.FECHA, p.HORA, e.ESPECIALIDAD " +
                "FROM PACIENTE p INNER JOIN ESPECIALISTA e ON p.idEspecialista = e.Id";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConexionSql);

            using (adapter)
            {
                DataTable pacienteTabla = new DataTable();

                adapter.Fill(pacienteTabla);

                listTurnos.SelectedValuePath = "Id";
                listTurnos.ItemsSource = pacienteTabla.DefaultView;

            }

        }
        #endregion

        #region Crear Turno
        private void Button_AddTurno(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && cmbEspecialista.SelectedItem != null
                && cmbOSocial.SelectedItem != null && fecha.SelectedDate != null && cmbHora.SelectedItem != null)
            {
                try
                {
                    string consulta = "INSERT INTO PACIENTE (idEspecialista,nombre,apellido,obraSocial,fecha,hora) VALUES (@idEspecialista,@nombre,@apellido,@obraSocial,@fecha,@hora)";
                    SqlCommand cmd = new SqlCommand(consulta, ConexionSql);
                    ConexionSql.Open();
                    cmd.Parameters.AddWithValue("@idEspecialista", cmbEspecialista.SelectedValue);
                    cmd.Parameters.AddWithValue("@nombre", txtName.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@obraSocial", cmbOSocial.SelectionBoxItem.ToString());
                    cmd.Parameters.AddWithValue("@fecha", fecha.SelectedDate);
                    cmd.Parameters.AddWithValue("@hora", cmbHora.SelectionBoxItem.ToString());
                    cmd.ExecuteNonQuery();
                    ConexionSql.Close();
                    panelTurno.IsEnabled = false;
                    panelTurno.Opacity = 0.3;
                    MessageBox.Show("Turno Agendado Dia: " + fecha.SelectedDate.Value.Date.ToShortDateString() + " " + cmbHora.SelectionBoxItem.ToString());
                    Clear();
                    MuestraTurnos();
                }
                catch (Exception mensaje)
                {
                    MessageBox.Show(mensaje.Message);
                }
            }
        }
        private void Button_EnabledTurno(object sender, RoutedEventArgs e)
        {
            if (panelTurno.IsEnabled == false)
            {
                panelTurno.IsEnabled = true;
                panelTurno.Opacity = 1;
                fecha.DisplayDateStart = DateTime.Now;
            }
            else
            {
                panelTurno.IsEnabled = false;
                panelTurno.Opacity = 0.3;
            }
        }
        private void Clear()
        {
            txtName.Clear();
            txtSurname.Clear();
            cmbOSocial.SelectedIndex = -1;
            cmbEspecialista.SelectedIndex = -1;
            cmbHora.SelectedIndex = -1;
            fecha.SelectedDate = DateTime.Now;
        }
        #endregion

        #region Modificar Turno
        private void Button_UpdateTurno(object sender, RoutedEventArgs e)
        {
            if (listTurnos.SelectedItem != null)
            {
                int id = int.Parse(listTurnos.SelectedValue.ToString());
                Update update = new Update(id);
                update.ShowDialog();
                MuestraTurnos();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Turno");
            }
        }
        #endregion

        #region Borrar Turno
        private void Button_Delete(object sender, RoutedEventArgs e)
        {
            if (listTurnos.SelectedItem != null)
            {
                string consulta = "DELETE FROM PACIENTE WHERE ID=@ID";

                if (MessageBox.Show("Seguro quiere eliminar", "Eliminar Turno", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    try
                    {
                        SqlCommand miSqlCommand = new SqlCommand(consulta, ConexionSql);
                        ConexionSql.Open();
                        miSqlCommand.Parameters.AddWithValue("@ID", listTurnos.SelectedValue);
                        miSqlCommand.ExecuteNonQuery();
                        ConexionSql.Close();
                        MuestraTurnos();
                        MessageBox.Show("Se elimino el turno");
                    }
                    catch (Exception mensaje)
                    {
                        MessageBox.Show(mensaje.Message);
                        ConexionSql.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Debe seleccionar un Turno");
            }
        }
        #endregion

        #region Buscador & Close-Minimize
        private void Button_MinimizeWindow(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Button_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

            string consulta = $"SELECT p.Id, p.NOMBRE, p.APELLIDO, p.FECHA, p.HORA, e.ESPECIALIDAD " +
                $"FROM PACIENTE p INNER JOIN ESPECIALISTA e ON p.idEspecialista = e.Id WHERE p.APELLIDO LIKE '{txtSearch.Text}%'";

            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ConexionSql);

            using (adapter)
            {
                DataTable pacienteTabla = new DataTable();

                adapter.Fill(pacienteTabla);

                listTurnos.SelectedValuePath = "Id";
                listTurnos.ItemsSource = pacienteTabla.DefaultView;

            }
        }
        #endregion
    }
}
