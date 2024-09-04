using System.Data.SqlClient;
using System.Text;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Labo03B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }
        string filterText = string.Empty;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string cadena = "Server=LAB1507-04\\SQLEXPRESS03; Database=Tecsup2023DB;Integrated Security=True";
            string filterText = TextBox1.Text.Trim().ToLower(); // Obtener el texto del TextBox y convertirlo a minúsculas

            using (SqlConnection connection = new SqlConnection(cadena))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Productos", connection);
                SqlDataReader reader = command.ExecuteReader();

                List<Producto> listarProductos = new List<Producto>();

                while (reader.Read())
                {
                    Producto producto = new Producto
                    {
                        ProductID = reader.GetInt32(0),
                        Nombre = reader.GetString(1),
                        Precio = reader.GetInt32(2)
                    };

                    listarProductos.Add(producto);
                }

                // Filtrar los productos en memoria
                if (!string.IsNullOrEmpty(filterText))
                {
                    listarProductos = listarProductos
                        .Where(p => p.Nombre.ToLower().Contains(filterText))
                        .ToList();
                }

                // Asignar la lista filtrada al DataGridView (en WPF, debería ser DataGrid)
                DGV1.ItemsSource = listarProductos;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Button_Click(sender, e);
        }
    }
}