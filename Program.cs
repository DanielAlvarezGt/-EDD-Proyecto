// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System;
using EDD_Proyecto2.Src.Estructuras;
using EDD_Proyecto2.Src.Autentificacion;
using EDD_Proyecto2.Src.Interfaz;
using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;
using Gtk;

namespace EDD_Proyecto2;





    class Program
    {
        static void Main(string[] args)
        {
            Application.Init();
            var dataService = Data_Service.Instance;
            _ = new Login(dataService);
            Application.Run();
           
        }
    }


/*
using System;
using EDD_Proyecto2.Src.Estructuras;
class Program
{
    static void Main()
    {
        Lista_Simple lista = new Lista_Simple();

        lista.Agregar(1, "Carlos", "Gómez", "carlos@mail.com", 25, "pass123");
        lista.Agregar(2, "Ana", "Pérez", "ana@mail.com", 20, "pass456");
        lista.Agregar(3, "Luis", "Martínez", "luis@mail.com", 99, "pass789");
        lista.Agregar(4, "María", "García", "maria@gmail.com", 22, "passabc");
        lista.Agregar(5, "Pedrito", "Pernandez", "pedrito@gmail.com", 10, "passdef");

        Console.WriteLine("Lista antes de ordenar:");
        lista.Imprimir();

        //lista.BubbleSort();

        Console.WriteLine("\nLista después de ordenar:");
        lista.Imprimir();
    }
}

*/
// ********** ARBOL AVL REPUESTOS ***********
/*

public class Program
{
    static void Main()
    {
        Nodo_Repuestos repuesto1 = new Nodo_Repuestos(1, "motor2", "nuevo2", 52.2);
        Nodo_Repuestos repuesto2 = new Nodo_Repuestos(2, "motor2", "nuevo2", 52.2);
        Nodo_Repuestos repuesto3 = new Nodo_Repuestos(3, "motor3", "nuevo3", 53.2);
        Nodo_Repuestos repuesto4 = new Nodo_Repuestos(4, "motor4", "nuevo4", 54.2);
        Nodo_Repuestos repuesto5 = new Nodo_Repuestos(5, "motor5", "nuevo5", 55.2);
        Nodo_Repuestos repuesto6 = new Nodo_Repuestos(6, "motor5", "nuevo5", 56.2);

        Arbol_Avl arbol = new Arbol_Avl();

        arbol.insert(repuesto1);
        arbol.insert(repuesto2);
        arbol.insert(repuesto3);
        arbol.insert(repuesto4);
        arbol.insert(repuesto5);
        arbol.insert(repuesto6);

        //arbol.inOrden();
        //arbol.preOrden();
        //arbol.postOrden();

        // Actualizar un nodo en el árbol
        bool actualizado = arbol.actualizar(3, "motor3_actualizado", "nuevo3_actualizado", 40.0);

        if (actualizado)
        {
            Console.WriteLine("Nodo actualizado correctamente.");
        }
        else
        {
            Console.WriteLine("Nodo no encontrado.");
        }

        // Verificar el nodo actualizado
        Nodo_Repuestos resultado = arbol.buscar(3);
        if (resultado != null)
        {
            Console.WriteLine("Nodo encontrado:");
            Console.WriteLine($"ID: {resultado.ID}, Repuesto: {resultado.Repuesto}, Detalle: {resultado.Detalle}, Costo: {resultado.Costo}");
        }
        else
        {
            Console.WriteLine("Nodo no encontrado.");
        }
    }
}*/

// ********** ARBOL BINARIO SERVICIOS ***********
 /*
class Prgram
{
    static void Main()
    {

        Arbol_Binario arbol = new Arbol_Binario();
       
        //arbol.Agregar(40);
        //arbol.Agregar(30);
        //arbol.Agregar(25);
        //arbol.Agregar(35);
        //arbol.Agregar(20);
        //arbol.Agregar(23);
        //arbol.Agregar(30);

        
        Nodo_T repuesto1 = new Nodo_T(40, 1,2, "motor1", 51.0);
        Nodo_T repuesto2 = new Nodo_T(30, 2,3, "motor2", 52.1);
        Nodo_T repuesto3 = new Nodo_T(25, 3,4, "motor3", 53.2);
        Nodo_T repuesto4 = new Nodo_T(35, 4,5, "motor4", 54.3);
        Nodo_T repuesto5 = new Nodo_T(20, 5,7, "motor5", 55.4);
        Nodo_T repuesto6 = new Nodo_T(23, 5,7, "motor7", 57.5);
        Nodo_T repuesto7 = new Nodo_T(30, 5,7, "motor8", 58.7);

        arbol.Agregar(repuesto1);
        arbol.Agregar(repuesto2);
        arbol.Agregar(repuesto3);
        arbol.Agregar(repuesto4);
        arbol.Agregar(repuesto5);
        arbol.Agregar(repuesto6);
        arbol.Agregar(repuesto7);
            
  


         arbol.treeGraph();
        //arbol.inOrden();
        //arbol.preOrden();
        //arbol.postOrden();

        // Buscar un nodo en el árbol usando el objeto repuesto1
        Nodo_T nodoEncontrado = arbol.Buscar(repuesto1.ID);

        if (nodoEncontrado != null)
        {
            Console.WriteLine("Nodo encontrado:");
            Console.WriteLine($"ID: {nodoEncontrado.ID}, IDRepuesto: {nodoEncontrado.IdRepuesto}, IDRepuesto: {nodoEncontrado.IdVehiculo}, IDRepuesto: {nodoEncontrado.Detalles},  Costo: {nodoEncontrado.Costo}");
        }
        else
        {
            Console.WriteLine($"Nodo con ID {repuesto1.ID} no encontrado.");
        }
        
    }

}*/
// ********** ARBOL B FACTURAS orden 5***********
/*
class Program
{
    static void Main(string[] args)
    {
        Arbol_B arbol = new Arbol_B();

        Nodo_Factura factura1 = new Nodo_Factura(10, 100.50);
        Nodo_Factura factura2 = new Nodo_Factura(5, 200.75);
        Nodo_Factura factura3 = new Nodo_Factura(15, 300.25);
        Nodo_Factura factura4 = new Nodo_Factura(7, 400.00);
        Nodo_Factura factura5 = new Nodo_Factura(12, 500.30);
        Nodo_Factura factura6 = new Nodo_Factura(2, 300.50); 

        Nodo_Factura factura7 = new Nodo_Factura(17, 400.75);
        Nodo_Factura factura8 = new Nodo_Factura(22, 500.25);
        Nodo_Factura factura9 = new Nodo_Factura(30, 600.00);
        Nodo_Factura factura10 = new Nodo_Factura(25, 700.30);
        Nodo_Factura factura11 = new Nodo_Factura(3, 800.50);
        Nodo_Factura factura12 = new Nodo_Factura(18, 900.75);

        Nodo_Factura factura13 = new Nodo_Factura(33, 800.50);
        Nodo_Factura factura14 = new Nodo_Factura(48, 900.75);
        Nodo_Factura factura15 = new Nodo_Factura(49, 900.75);
        Nodo_Factura factura16 = new Nodo_Factura(58, 900.75);
        Nodo_Factura factura17 = new Nodo_Factura(68, 900.75);




        // Insertamos elementos
    

        arbol.Insertar(factura1.Id, factura1.Total);
        arbol.Insertar(factura2.Id, factura2.Total);
        arbol.Insertar(factura3.Id, factura3.Total);
        arbol.Insertar(factura4.Id, factura4.Total);
        arbol.Insertar(factura5.Id, factura5.Total);
        arbol.Insertar(factura6.Id, factura6.Total);
        arbol.Insertar(factura7.Id, factura7.Total);
        arbol.Insertar(factura8.Id, factura8.Total);
        arbol.Insertar(factura9.Id, factura9.Total);
        arbol.Insertar(factura10.Id, factura10.Total);
        arbol.Insertar(factura11.Id, factura11.Total);
        arbol.Insertar(factura12.Id, factura12.Total);
        arbol.Insertar(factura13.Id, factura13.Total);
        arbol.Insertar(factura14.Id, factura14.Total);
        arbol.Insertar(factura15.Id, factura15.Total);
        arbol.Insertar(factura16.Id, factura16.Total);
        arbol.Insertar(factura17.Id, factura17.Total);
     
        Console.WriteLine("Árbol B de orden 5 creado");

        // Generar representación gráfica
        //arbol.GraficarGraphviz();


        arbol.Eliminar(factura8.Id);
        Console.WriteLine("Árbol B despues de borrar");

        //arbol.GraficarGraphviz();



        Nodo_Factura encontrado = arbol.Buscar(factura8.Id);
        Console.WriteLine(encontrado);
    }
}*/