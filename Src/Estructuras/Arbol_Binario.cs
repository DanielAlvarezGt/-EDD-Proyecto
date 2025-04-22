using System;
using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Estructuras;
using System.Collections.Concurrent;
using System.Text;



namespace EDD_Proyecto2.Src.Estructuras;

public class Arbol_Binario
{
    private Nodo_T root;
    string connections = "";
    string nodes = "";


    public void Agregar(Nodo_T id)
    {
        
      Nodo_T nodo = new Nodo_T(id.ID, id.IdRepuesto, id.IdVehiculo, id.Detalles, id.Costo);

        if(root == null)
        {
            root = nodo;
        } else {
            recursividad(root, nodo);
        }       
    }
    

    public void recursividad(Nodo_T curr, Nodo_T newNode)
    {


        if(newNode.ID < curr.ID)
        {
            if(curr.left != null)
            {
                recursividad(curr.left, newNode);

            } else {
                curr.left = newNode;
            }
        }
        else if(newNode.ID > curr.ID)
        {
            if(curr.right != null)
            {
                recursividad(curr.right, newNode);
                
            } else {
                curr.right = newNode;
            }

        }
        else
        {
            Console.WriteLine("El nodo ya fue insertado");
        }
    }
    

    public void treeGraph()
    {
        connections = "";
        nodes = "";
        graphRecursivo(root);
        Console.WriteLine(nodes);
        Console.WriteLine(connections);
        
    }

    public void graphRecursivo(Nodo_T current)
    {

        if(current.left != null)
        {
            graphRecursivo(current.left);
            connections += "S"+Convert.ToString(current.ID) + " -> " + "S" + Convert.ToString(current.left.ID) + "\n";
        }

        //nodes += "S"+Convert.ToString(current.item.ID)+"[label="+Convert.ToString(current.item.ID)+"];";
        nodes += "S"+Convert.ToString(current.ID) + "[label=" + '"' +Convert.ToString(current.ID) +"|"+ Convert.ToString(current.IdRepuesto) +"|"+ Convert.ToString(current.IdVehiculo) + "|"+ current.Detalles+ "|"+ Convert.ToString(current.Costo) + '"' + "shape ="+ '"'+"record" +'"'+"];";
           
        if(current.right != null)
        {
            graphRecursivo(current.right);
            connections += "S"+Convert.ToString(current.ID) + " -> " + "S" + Convert.ToString(current.right.ID) + "\n";
        }
    }

    public string inOrden()
    {
        var resultado = new StringBuilder();

        resultado.AppendLine($"{"ID",-5}{"IdRepuesto",-32}{"IdVehiculo",-32}{"Detalles",-72}{"Costo",-10}|");
        resultado.AppendLine(new string('-', 100)); // Línea separadora
        connections = "";
        nodes = "";
        inOrdenRecursivo(root,resultado);
        Console.WriteLine("---- INORDEN ----");
        Console.WriteLine(nodes);
        Console.WriteLine(connections);

        return resultado.ToString();

    }

    private void inOrdenRecursivo(Nodo_T current, StringBuilder resultado)
    {
        if(current.left != null)
        {
            inOrdenRecursivo(current.left, resultado);
            connections += " -> ";
        }
        //Obtenemos el valor de cada nodo
       nodes += "S"+Convert.ToString(current.ID) + "[label=" + '"' +Convert.ToString(current.ID) +"|"+ Convert.ToString(current.IdRepuesto) +"|"+ Convert.ToString(current.IdVehiculo) + "|"+ current.Detalles+"|"+ Convert.ToString(current.Costo) + '"' + "shape ="+ '"'+"record" +'"'+"];";
        
        connections += "S"+Convert.ToString(current.ID);
        Console.WriteLine(Convert.ToString(current.ID));
        resultado.AppendLine($"|{current.ID,-3}|{current.IdRepuesto,-30}|{current.IdVehiculo,-30}|{current.Detalles,-70}|{current.Costo,-8:F2}");


        if(current.right != null)
        {
            connections += " -> ";
            inOrdenRecursivo(current.right, resultado);
        }
    }


    public string preOrden()
    
    {
        var resultado = new StringBuilder();

         resultado.AppendLine($"{"ID",-5}{"IdRepuesto",-32}{"IdVehiculo",-32}{"Detalles",-72}{"Costo",-10}|");
        resultado.AppendLine(new string('-', 100)); // Línea separadora

        connections = "";
        nodes = "";
        preOrdenRecursivo(root,resultado);
        Console.WriteLine("------ PREORDEN ------");
        Console.WriteLine(nodes);
        Console.WriteLine(connections);

          return resultado.ToString();
    }

    private void preOrdenRecursivo(Nodo_T current,StringBuilder resultado)
    {
        //Obtenemos el valor de cada nodo
        nodes += "S"+Convert.ToString(current.ID) + "[label=" + '"' +Convert.ToString(current.ID) +"|"+ Convert.ToString(current.IdRepuesto) +"|"+ Convert.ToString(current.IdVehiculo) + "|"+ current.Detalles+ "|"+ Convert.ToString(current.Costo) + '"' + "shape ="+ '"'+"record" +'"'+"];";
        connections += "S"+Convert.ToString(current.ID);
        Console.WriteLine(current.ID);
 resultado.AppendLine($"|{current.ID,-3}|{current.IdRepuesto,-30}|{current.IdVehiculo,-30}|{current.Detalles,-70}|{current.Costo,-8:F2}");

  
        if(current.left != null)
        {
            connections += " -> ";
            preOrdenRecursivo(current.left,resultado);
        }
        if(current.right != null)
        {
            connections += " -> ";
            preOrdenRecursivo(current.right,resultado);
        }
    }

    public string postOrden()
    {
         var resultado = new StringBuilder();

        resultado.AppendLine($"{"ID",-5}{"IdRepuesto",-32}{"IdVehiculo",-32}{"Detalles",-72}{"Costo",-10}|");
        resultado.AppendLine(new string('-', 100)); // Línea separadora

        connections = "";
        nodes = "";
        postOrdenRecursivo(root,resultado);
        Console.WriteLine("------ POSTORDEN ------");
        Console.WriteLine(nodes);
        Console.WriteLine(connections);

         return resultado.ToString();

    }

    private void postOrdenRecursivo(Nodo_T current, StringBuilder resultado)
    {
        if(current.left != null)
        {
            postOrdenRecursivo(current.left,resultado);
            connections += " -> ";

        }

        if(current.right != null)
        {
            postOrdenRecursivo(current.right,resultado);
            connections += " -> ";

        }
        //Obtenemos el valor del nodo
        nodes += "S"+Convert.ToString(current.ID) + "[label=" + '"' +Convert.ToString(current.ID) +"|"+ Convert.ToString(current.IdRepuesto) +"|"+ Convert.ToString(current.IdVehiculo) + "|"+ current.Detalles+ "|"+ Convert.ToString(current.Costo) + '"' + "shape ="+ '"'+"record" +'"'+"];";
        connections += "S"+Convert.ToString(current.ID);
        Console.WriteLine(current.ID);
        resultado.AppendLine($"|{current.ID,-3}|{current.IdRepuesto,-30}|{current.IdVehiculo,-30}|{current.Detalles,-70}|{current.Costo,-8:F2}");

    }

    public Nodo_T Buscar(int id)
    {
        return BuscarRecursivo(root, id);
    }

    private Nodo_T BuscarRecursivo(Nodo_T current, int id)
    {
        if (current == null)
        {
            // Si el nodo actual es null, el nodo no existe en el árbol
            return null;
        }

        if (current.ID == id)
        {
            // Si encontramos el nodo con el ID buscado, lo retornamos
            return current;
        }
        else if (id < current.ID)
        {
            // Si el ID buscado es menor, buscamos en el subárbol izquierdo
            return BuscarRecursivo(current.left, id);
        }
        else
        {
            // Si el ID buscado es mayor, buscamos en el subárbol derecho
            return BuscarRecursivo(current.right, id);
        }
    }

     public bool IsEmpty()
        {
            return root == null;
        }

   
}
