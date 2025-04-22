using EDD_Proyecto2.Src.Modelos;
using System;
using System.Runtime.InteropServices;
//Importar paquetes para graphviz
using DotNetGraph.Compilation;
using DotNetGraph.Core;
using DotNetGraph.Extensions;
//Importar paquete para ejecutar el comando (este ya viene instalado)
using System.Diagnostics;
using EDD_Proyecto.Src.Modelos;


namespace EDD_Proyecto2.Src.Estructuras
{
    public class Lista_Doble
    {
        private Nodo_Vehiculos head = null;
        private Nodo_Vehiculos tail = null;

        public void Insertar(int id, int idUsuario, string marca, int modelo, string placa)
        {

            //se crea el nodo

            Nodo_Vehiculos nodo = new Nodo_Vehiculos(id, idUsuario, marca, modelo, placa);
         

            if (head == null)
            {
                head = nodo;
                tail = nodo;
            }
            else
            {
                tail.Siguiente = nodo;
                nodo.Anterior= tail;
                tail = nodo;
            }
        }

        public int Search(int id)
        {
            if (head == null) return 0;
            Nodo_Vehiculos actual = head;
            while (actual != null)
            {
                if (actual.ID == id)
                {
                    return 1;
                }
                actual = actual.Siguiente;
            }
            return 0;

        }   
        public List<Vehiculo>? SearchVehiclesByUserId(int idUsuario)
        {
            if (head == null) return null;
            var vehicles = new List<Vehiculo>();

            Nodo_Vehiculos actual = head;
            while (actual != null)
            {
                if (actual.IdUsuario == idUsuario)
                {
                    var ID = actual.ID;
                    var IDUsuario = actual.IdUsuario;
                    var marca = actual.Marca;
                    var modelo = actual.Modelo;
                    var placa = actual.Placa;
                    var vehiculo = new Vehiculo { ID = ID, ID_Usuario = IDUsuario, Marca = marca, Modelo = modelo, Placa = placa };
                    vehicles.Add(vehiculo);
                }
                actual = actual.Siguiente;
            }
            return vehicles;
        }

        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Lista vacia");
                return;
            }
            Nodo_Vehiculos actual = head;
            while (actual != null)
            {
                Console.WriteLine("ID: " + actual.ID);
                Console.WriteLine("ID Usuario: " + actual.IdUsuario);
                Console.WriteLine("Marca: " + actual.Marca);
                Console.WriteLine("Modelo: " + actual.Modelo);
                Console.WriteLine("Placa: " + actual.Placa);
                Console.WriteLine();
                actual = actual.Siguiente;
                
            }
        }

        public int Delete(int id)
        {
            if (head == null) return 0;

            Nodo_Vehiculos actual = head;
            Nodo_Vehiculos prev = null;
            while (actual != null)
            {
                if (actual.ID == id)
                {
                    if (prev == null)
                    {
                        head = actual.Siguiente;
                        if (head != null)
                        {
                            head.Anterior = null;
                        }
                        else
                        {
                            tail = null;
                        }

                    }
                    else
                    {
                        prev.Siguiente = actual.Siguiente;
                        if (actual.Siguiente != null)
                        {
                            actual.Siguiente.Anterior = prev;
                        }
                        else
                        {
                            tail = prev;
                        }
                    }
                    //Marshal.FreeHGlobal((IntPtr)actual);
                    return 1;
                }
                prev = actual;
                actual = actual.Siguiente;
            }
            return 0;
        }

        public bool GenerarReporte()
        {
            DotGraph graph = new DotGraph()
                                .WithIdentifier("Listado de Vehiculos")
                                .Directed()
                                .WithRankDir(DotRankDir.LR)
                                .WithLabel("Listado de Vehiculos");

            if (head == null) return false;
            Nodo_Vehiculos actual = head;

            while (actual != null)
            {
                if (actual.Siguiente != null)
                {
                    Nodo_Vehiculos Siguiente= actual.Siguiente;
                    DotNode node1 = new DotNode()
                                    .WithIdentifier(actual.ID.ToString())
                                    .WithShape(DotNodeShape.Box)
                                    .WithLabel($"ID: {actual.ID}\nID Usuario: {actual.IdUsuario}\nMarca: {actual.Marca}\nModelo: {actual.Modelo}\nPlaca: {actual.Placa}")
                                    .WithFillColor(DotColor.Azure)
                                    .WithFontColor(DotColor.Black);
                
                    DotNode node2 = new DotNode()
                                    .WithIdentifier(Siguiente.ToString())
                                    .WithShape(DotNodeShape.Box)
                                    .WithLabel($"ID: {Siguiente.ID}\nID Usuario: {Siguiente.IdUsuario}\nMarca: {Siguiente.Marca}\nModelo: {Siguiente.Modelo}\nPlaca: {Siguiente.Placa}")
                                    .WithFillColor(DotColor.Azure)
                                    .WithFontColor(DotColor.Black)
                                    .WithWidth(0.5)
                                    .WithHeight(0.5)
                                    .WithPenWidth(1.5)
                                    .WithWidth(0.5)
                                    .WithHeight(0.5)
                                    .WithPenWidth(1.5);

                    DotEdge edge1 = new DotEdge()
                                    .From(node1)
                                    .To(node2)
                                    .WithArrowHead(DotEdgeArrowType.Normal)
                                    .WithColor(DotColor.Black)
                                    .WithFontColor(DotColor.Black)
                                    .WithPenWidth(1.5);
                    
                    DotEdge edge2 = new DotEdge()
                                    .From(node2)
                                    .To(node1)
                                    .WithArrowHead(DotEdgeArrowType.Normal)
                                    .WithColor(DotColor.Black)
                                    .WithFontColor(DotColor.Black)
                                    .WithPenWidth(1.5);
                    
                    graph.Elements.Add(node1);
                    graph.Elements.Add(node2);
                    graph.Elements.Add(edge1);
                    graph.Elements.Add(edge2);
                }
                actual = actual.Siguiente;
            }

            using var writer = new StringWriter();
            var context = new CompilationContext(writer, new CompilationOptions());
            graph.CompileAsync(context);

            var result = writer.GetStringBuilder().ToString();

            // Save it to a file
            File.WriteAllText("../../AutoGest_Pro/Fase1/reportes/ListadoVehiculos.dot", result);

            ProcessStartInfo startInfo = new ProcessStartInfo("dot");

            startInfo.Arguments = $"-Tpng ../../AutoGest_Pro/Fase1/reportes/ListadoVehiculos.dot -o ../../AutoGest_Pro/Fase1/reportes/ListadoVehiculos.png";

            Process.Start(startInfo);
            return true;
        }
        ~Lista_Doble()
        {
            if (head == null) return;
            Nodo_Vehiculos actual = head;
            while (actual != null)
            {
                Nodo_Vehiculos tmp = actual;
                actual = actual.Siguiente;
                //Marshal.FreeHGlobal((IntPtr)tmp);
            }
        }
    }
}