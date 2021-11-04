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
using Restaurant.Negocios;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace Restaurant.Presentacion
{
    /// <summary>
    /// Lógica de interacción para Bodega.xaml
    /// </summary>
    public partial class Bodega : MetroWindow
    {
        Manejadora mane = new Manejadora();
        public Bodega()
        {
            InitializeComponent();
            CboNombre.ItemsSource = Enum.GetValues(typeof(Produ));
        }

        public void Limpiar()
        {
            TxtID.Text = "";
            CboNombre.SelectedValue = "";
            TxtStock.Text = "";
        }

        private async void BtnIngresar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto pro = new Producto(int.Parse(TxtID.Text), CboNombre.SelectedValue.ToString(), int.Parse(TxtStock.Text));
                if (pro.Create())
                {
                    await this.ShowMessageAsync("mensaje", string.Format(" producto agregado correctamente"));
                }
                else
                {
                    await this.ShowMessageAsync("mensaje", string.Format("no se pudo agregar producto "));
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto pro = new Producto()
                {
                    IdProducto = int.Parse(TxtID.Text)
                };
                if (pro.Read())
                {
                    TxtID.Text = pro.IdProducto.ToString();
                    CboNombre.SelectedValue = pro.NombreProducto;
                    TxtStock.Text = pro.Stock.ToString();
                }
                else
                {
                    TxtID.Text = "";
                    TxtStock.Text = "";
                    await this.ShowMessageAsync("mensaje", string.Format("no se encontro producto"));

                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtID.Text = "";
                TxtStock.Text = "";
            }
        }

        private async void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto pro = new Producto()
                {
                    IdProducto = int.Parse(TxtID.Text),
                    NombreProducto = (Produ)(CboNombre.SelectedValue),
                    Stock = int.Parse(TxtStock.Text)

                };
                if (pro.Update())
                {
                    Limpiar();
                    await this.ShowMessageAsync("mensaje", string.Format("Producto Actualizado"));
                }
                else
                {
                    await this.ShowMessageAsync("mensaje", string.Format("No se pudo Actualizar producto"));
                }

            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtID.Text = "";
                TxtStock.Text = "";
            }

        }

        private async void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Producto del = new Producto()
                {
                    IdProducto = int.Parse(TxtID.Text)
                };
                if (del.Delete())
                {
                    Limpiar();
                    await this.ShowMessageAsync("mensaje", string.Format("producto elimindado"));
                }
                else
                {
                    TxtID.Text = "";
                    TxtStock.Text = "";
                    await this.ShowMessageAsync("mensaje", string.Format("No se pudo eliminar producto"));
                }
            }
            catch (Exception zz)
            {
                MessageBox.Show(zz.Message, "error", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtID.Text = "";
                CboNombre.SelectedValue = "";
                TxtStock.Text = "";
            }
        }

        private void BtnMostarTodo_Click(object sender, RoutedEventArgs e)
        {
            DgridMostrar.ItemsSource = (
                from aa in mane.ListarProducto()
                select new
                {
                    Idproducto = aa.IdProducto,
                    Nombre=aa.NombreProducto,
                    Stock=aa.Stock
                }).ToList();
        }

        private void BtnAtras_Click(object sender, RoutedEventArgs e)
        {
            Usuario UnProducto = new Usuario();
            this.Hide();
            Administrador admi = new Administrador(UnProducto.Nombre);
            admi.Show();
        }
    }
}
