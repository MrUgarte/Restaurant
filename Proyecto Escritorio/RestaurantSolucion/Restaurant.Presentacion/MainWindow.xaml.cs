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
using Restaurant.Negocios;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Restaurant.Presentacion
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            TxtRutUsuario.Text = string.Empty;
            TxtPassword.Password = string.Empty;
            TxtRutUsuario.Focus();
        }

        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            Usuario UnUsuario = new Usuario();
            try
            {
                UnUsuario.Rut = TxtRutUsuario.Text;
            }
            catch
            {
                await this.ShowMessageAsync("mensaje", string.Format("error..ingrese rut"));
                TxtRutUsuario.Text = string.Empty;
                TxtRutUsuario.Focus();
                return;
            }
            try
            {
                UnUsuario.Contraseña = TxtPassword.Password;
            }
            catch
            {
                await this.ShowMessageAsync("mesaje", string.Format("error...ingrese contraseña"));
                TxtPassword.Password = string.Empty;
                TxtPassword.Focus();
                return;
            }

            if (UnUsuario.Readd())
            {
                if (UnUsuario.Tipo.ToString() == "Administrador")
                {
                    await this.ShowMessageAsync("mensaje", string.Format("Bienvenido administrador:  " + UnUsuario.Nombre, "Bienvenido"));
                    this.Hide();
                    Administrador ad = new Administrador(UnUsuario.Nombre);
                    ad.Show();
                }
            }
            else
            {
                await this.ShowMessageAsync("mensaje", string.Format("Usuario o Password Incorrecto - Vuelva a Intentarlo"));
                TxtRutUsuario.Text = string.Empty;
                TxtPassword.Password = string.Empty;
                TxtRutUsuario.Focus();
            }
        }

        private void BtnSalir_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("¿Seguro Desea Salir del Programa?", "Salir", MessageBoxButton.YesNo, MessageBoxImage.Question) == System.Windows.MessageBoxResult.Yes)
            {
                System.Environment.Exit(0);
            }
        }
    }
}
