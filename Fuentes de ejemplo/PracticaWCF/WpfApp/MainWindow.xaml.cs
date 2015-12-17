using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
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

        void Cargar() {
            ServiceReference1.ServicioProductoClient srv = new ServiceReference1.ServicioProductoClient();
            dataGrid1.ItemsSource = srv.Listado();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Cargar();

        }

        private void btnGuardad_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.ServicioProductoClient srv = new ServiceReference1.ServicioProductoClient();
            ServiceReference1.Producto p = new ServiceReference1.Producto();

            p.Nombre = txtNombre.Text;
            p.Descripcion = txtdescripcion.Text;
            p.Cantidad = txtCantidad.Text;
            srv.Agregar(p);
            Cargar();

        }
    }
}
