using csvfiles;
using tp_final.Properties;

namespace tp_final;

public partial class Form1 : Form
{
    public Form1()
    {
        
        InitializeComponent();
        
        Class_Almacen Liniers = new Class_Almacen();


        Class_Vehiculo vehiculo1 = new Class_Furgoneta();
        Class_Vehiculo vehiculo2 = new Class_Furgon();
        Class_Vehiculo vehiculo3 = new Class_Camioneta();


        Liniers.Actualizacionfechas();

        Liniers.Llenado(vehiculo1);
        vehiculo1.CargarRecorrido();
        vehiculo1.MostrarLista();

        Console.ReadKey();
        Console.Clear();

        Liniers.MostrarListaTotal();

        Console.ReadKey();
        Console.Clear();

        Liniers.Llenado(vehiculo2);
        vehiculo2.CargarRecorrido();
        vehiculo2.MostrarLista();

        Console.ReadKey();
        Console.Clear();

        Liniers.MostrarListaTotal();

        Console.ReadKey();
        Console.Clear();

        Liniers.Llenado(vehiculo3);
        vehiculo3.CargarRecorrido();
        vehiculo3.MostrarLista();

        Console.ReadKey();
        Console.Clear();

        Liniers.MostrarListaTotal();

        Console.ReadKey();
        Console.Clear();

        int cont = 0;
        while(cont < 3 && Liniers.lista_pedidos.Count != 0)
        {
            Liniers.Llenado(vehiculo3);
            vehiculo3.CargarRecorrido();
            vehiculo3.MostrarLista();

            Console.ReadKey();
            Console.Clear();

            Liniers.MostrarListaTotal();

            Console.ReadKey();
            Console.Clear();
            cont++;
        }

        Liniers.MostrarListaTotal();

        Console.ReadKey();
        Console.Clear();




    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }
}
