using csvfiles;
using tp_final.Properties;

namespace tp_final;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        var csv_ = new csvfiles._csv();
        List<Pedido> Pedidos = csv_.read_csv();
        Class_Almacen Liniers = new Class_Almacen();
        Liniers.Mostrar_Algo();
        
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
