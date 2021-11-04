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
using Restaurant.Negocios;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Restaurant.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Administrador.xaml
    /// </summary>
    public partial class Administrador : MetroWindow
    {
        public Administrador(string nombre)
        {
            InitializeComponent();
            LblUsuario.Content = "usuario :" + nombre;
        }

        private  void BtnProductos_Click(object sender, RoutedEventArgs e)
        {
            
            this.Hide();
            Bodega bod = new Bodega();
            bod.Show();

            
        }
    }
}
