using System.Data;
using System.Data.SqlClient;

namespace Lab03B
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                string cadena = "Server=LAB1507-04\\SQLEXPRESS03; Database=Tecsup2023DB;Integrated Security=True";
                SqlConnection connection = new SqlConnection(cadena);
                connection.Open();

                SqlCommand command = new SqlCommand("Select * from Productos", connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridView1.DataSource = dataTable;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
        private void button2_Click(object sender, EventArgs e)
        {

                string cadena = "Server=LAB1507-04\\SQLEXPRESS03; Database=Tecsup2023DB;Integrated Security=True";
                SqlConnection connection = new SqlConnection(cadena);

                connection.Open();
                SqlCommand command = new SqlCommand("Select * from Productos", connection);

                List<Producto> listarProductos = new List<Producto>();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    
                    Producto producto = new Producto();
                    producto.ProductID = reader.GetInt32(0);
                    producto.Nombre = reader.GetString(1);
                    producto.Precio = reader.GetInt32(2);

                    listarProductos.Add(producto);

            }
                dataGridView1.DataSource = listarProductos;
        }
    }
}
