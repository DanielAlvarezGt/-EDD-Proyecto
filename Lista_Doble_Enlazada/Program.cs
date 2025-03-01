using System;

namespace Lista_Doble_Enlazada
{
    class Program
    {
        static unsafe void Main()
        {
            ListaDoblementeEnlazada lista = new ListaDoblementeEnlazada();

            lista.Insertar(1, "Tienda A", "Jefferson Ortiz", "Calle 18");
            lista.Insertar(2, "TIenda B", "Wlson Ruiz", "Villa NUeva");
            lista.Insertar(3, "TIenda C", "Carlos Valle", "Zona 10");

            Console.WriteLine("Lista de locales:");
            lista.Mostrar();

            Console.WriteLine("\nEliminando el nodo con ID 2...");
            lista.Eliminar(2);

            Console.WriteLine("Lista después de eliminar:");
            lista.Mostrar();


            Console.WriteLine("Lista Mostrada de reversa:");
            lista.MostrarReversa();
        }
    }
}