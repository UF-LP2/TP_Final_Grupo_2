using csvfiles;
using tp_final.Properties;

namespace tp_final;

public partial class Form1 : Form
{
    public Form1()
    {
        
        InitializeComponent();
        


        Class_Almacen Liniers = new Class_Almacen();


        
        Class_Vehiculo vehiculo = new Class_Furgoneta();
        List<Pedido> prueba = new List<Pedido>();
        Pedido pedido1 = new Pedido();
        Pedido pedido2 = new Pedido();
        Pedido pedido3 = new Pedido();
        Pedido pedido4 = new Pedido();
        Pedido pedido5 = new Pedido();
        Pedido pedido6 = new Pedido();
        pedido1.barrio = "Almirante-Brown";
        pedido2.barrio = "Caballito";
        pedido3.barrio = "Boedo";
        pedido4.barrio = "Boedo";
        pedido5.barrio = "Barracas";
        pedido6.barrio = "Constitucion";
        prueba.Add(pedido1);
        prueba.Add(pedido2);
        prueba.Add(pedido3);
        prueba.Add(pedido4);
        prueba.Add(pedido5);
        prueba.Add(pedido6);
        vehiculo.setVol_Max(17000000);
        Liniers.Llenado(vehiculo);
        //vehiculo.setLista(prueba);
        //vehiculo.CargarRecorrido();
        //vehiculo.MostrarAlgo();

    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
