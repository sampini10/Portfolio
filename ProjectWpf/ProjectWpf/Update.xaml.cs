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
using System.Configuration;
using System.Data;
using System.Data.SqlClient;


namespace ProjectWpf
{
    /// <summary>
    /// Lógica de interacción para Update.xaml
    /// </summary>
    public partial class Update : Window
    {
        SqlConnection ConexionSql;
        int id;
        public Update(int id)
        {
            this.id = id;
            InitializeComponent();
            string conexion = ConfigurationManager.ConnectionStrings["ProjectWpf.Properties.Settings.BaseDatosConnectionString"].ConnectionString;
            ConexionSql = new SqlConnection(conexion);
            UpdateCarga();
            MuestraEspecialista();
        }

        #region Mostrar
        private void UpdateCarga()
        {
            string consulta = "SELECT * FROM PACIENTE WHERE ID = @ID";

            SqlCommand cmd = new SqlCommand(consulta, ConexionSql);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            using (adapter)
            {
                cmd.Parameters.AddWithValue("@ID", id);
                DataTable dataTable = new DataTable();

                adapter.Fill(dataTable);

                txtName.Text = dataTable.Rows[0]["nombre"].ToString();
                txtSurname.Text = dataTable.Rows[0]["apellido"].ToString();
                fecha.DisplayDateStart = DateTime.Now;
            }
        }
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
        #endregion

        #region Modificar Turno
        private void Button_UpdateTurno(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text) && !string.IsNullOrEmpty(txtSurname.Text) && cmbEspecialista.SelectedItem != null
                && cmbOSocial.SelectedItem != null && fecha.SelectedDate != null && cmbHora.SelectedItem != null)
            {
                try
                {
                    string consulta = "UPDATE PACIENTE SET idEspecialista=@idEspecialista,nombre=@nombre,apellido=@apellido,obraSocial=@obraSocial,fecha=@fecha,hora=@hora WHERE ID = @ID";
                    SqlCommand cmd = new SqlCommand(consulta, ConexionSql);
                    ConexionSql.Open();
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@idEspecialista", cmbEspecialista.SelectedValue);
                    cmd.Parameters.AddWithValue("@nombre", txtName.Text);
                    cmd.Parameters.AddWithValue("@apellido", txtSurname.Text);
                    cmd.Parameters.AddWithValue("@obraSocial", cmbOSocial.SelectionBoxItem.ToString());
                    cmd.Parameters.AddWithValue("@fecha", fecha.SelectedDate);
                    cmd.Parameters.AddWithValue("@hora", cmbHora.SelectionBoxItem.ToString());
                    cmd.ExecuteNonQuery();
                    ConexionSql.Close();
                    MessageBox.Show("Turno modificado Dia: " + fecha.SelectedDate.Value.Date.ToShortDateString() + " " + cmbHora.SelectionBoxItem.ToString());
                    Close();
                }
                catch (Exception mensaje)
                {
                    MessageBox.Show(mensaje.Message);
                    ConexionSql.Close();
                }
            }

        }

        #endregion
        private void Button_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
