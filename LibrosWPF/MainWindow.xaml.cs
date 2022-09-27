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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibrosWPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIsbn.Text) && !string.IsNullOrWhiteSpace(txtTitulo.Text) &&
                !string.IsNullOrWhiteSpace(txtAutor.Text) && !string.IsNullOrWhiteSpace(txtPages.Text))
            {
                    Libros libro = new Libros();
                    libro.ISBN = int.Parse(txtIsbn.Text);
                    libro.Titulo = txtTitulo.Text;
                    libro.Autor = txtAutor.Text;
                    libro.NumeroDePaginas = int.Parse(txtPages.Text);

                    lstRegistro.Items.Add(libro.MostrarLibro(libro));
                    txtIsbn.Clear();
                    txtTitulo.Clear();
                    txtAutor.Clear();
                    txtPages.Clear();
                    MessageBox.Show("Ingreso correctamente.");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            if (lstRegistro.Items.Count != 0)
            {
                lstRegistro.Items.Clear();
                MessageBox.Show("Se limpio el registro.");
            }
        }
    }
}
