using System;
using List;

class Program
    {
        static void Main()
        {
            ListaSimple<int> lista = new ListaSimple<int>();
            lista.Insertar(1, "Daniel","Alvarez","daniel.alvarez#","dalvarez@gmail.com");
            lista.Insertar(2, "Waldemar","Garcia","waldemar1987","waldemar.garcia@gmail.com");
          
            Console.WriteLine("\nLista antes de modificar:");
            lista.Imprimir();

            lista.Modificar(1,"Oscar","Juarez","oscar.juarez@gmail.com");
            Console.WriteLine("\nLista después de modificar:");
            lista.Imprimir();

            
            lista.Eliminar(1);
            Console.WriteLine("\nLista después de eliminar:");
            lista.Imprimir();
        
        
        }
    }