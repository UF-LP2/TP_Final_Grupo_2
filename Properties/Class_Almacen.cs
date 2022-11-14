using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*enum eBarrios
{
    Agronomia, Almagro, Almirante_Brown, Balbastro, Balvanera, Barracas, Barrio_Norte,
    Belgrano, Boca, Boedo, Bonorino, Buenos_Aires, Caballito, Cafferata, Calaza, Centro, Chacarita,
    Ciudad_Autonoma_de_Buenos_Aires, Coghlan, Colegiales, Colelache, Colhue_Huapi, Comandante_L_Piedrabuena,
    Congreso, Constitucion, Dolavon, Dos_Pozos, El_Maiten, El_Sombrero, Emilio_Mitre, Epuyen, Escalante,
    Facundo, Flores, Floresta, Gan_Gan, General_Jose_de_San_Martin, Isla_Demarchi, Lacarra, Liniers,
    Los_Perales, Luis_J_Garcia, Marcelo_Torcuato_de_Alvear, Mataderos, Monte_Castro, Montserrat, Nazca,
    Nueva_Chicago, Nueva_Pompeya, Nunez, Once, Palermo, Parque_Chacabuco, Parque_Chas, Parque_Patricios,
    Paternal, Presidente_Rivadavia, Presidente_Roque_Saenz_Pena, Primera_Junta, Puerto_Madero, Puerto_Nuevo,
    Pueyrredon, Ramon_L_Falcon, Recoleta, Retiro, Saavedra, San_Cristobal, San_Telmo, Simon_Bolivar, Tellier,
    Varela, Velez_Sarsfield, Versailles, Villa_Crespo, Villa_del_Parque, Villa_Devoto, Villa_General_Mitre,
    Villa_La_madrid, Villa_Lugano, Villa_Luro, Villa_Ortuzar, Villa_Real, Villa_Riachuelo, Villa_Santa_Rita,
    Villa_Soldati, Villa_Urquiza
}*/
namespace tp_final.Properties
{
    public class Class_Almacen
    {
        public Dictionary<string, (string, string)> Coordenadas { get; }
        List<string> CoordenadasList { get; }
        public Class_Almacen()
        {
            Coordenadas = CargarCoordenadas();
        }
        
        public Dictionary<string, (string,string)> CargarCoordenadas()
        {
            Dictionary<string, (string, string)> Coordenadas = new Dictionary<string, (string, string)>();
            string ubicacionArchivo = "D:\\Repos\\TP_Final_Grupo_2\\Coordenadas.csv";
            System.IO.StreamReader archivo = new System.IO.StreamReader(ubicacionArchivo);
            string separador = ",";
            string linea;
            
            // Si el archivo no tiene encabezado, elimina la siguiente línea
            archivo.ReadLine(); // Leer la primera línea pero descartarla porque es el encabezado
            while ((linea = archivo.ReadLine()) != null)
            {
                string[] fila = linea.Split(separador);
                Coordenadas.Add(fila[0], (fila[1], fila[2]));
            }
            return Coordenadas;
        }
        public void Mostrar_Algo()
        {
            Console.WriteLine(Coordenadas.Count);
        }


        //hola

    }
}
