using System;
using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Estructuras;
using System.Text;


namespace EDD_Proyecto2.Src.Estructuras;
public class Arbol_Avl
{
    private Nodo_Avl root;
    string connections = "";
    string nodes = "";

//Insercion
    public void insert(Nodo_Repuestos item)
    {
        root = insertRecursive(item, root);
    }

    public Nodo_Avl insertRecursive(Nodo_Repuestos item, Nodo_Avl node)
    {

        if(node == null)
        {
            node = new Nodo_Avl(item);

        } else if(item.ID < node.item.ID)
        {

            //lado izquierdo
            node.left = insertRecursive(item, node.left);
            if(GetHeight(node.left) - GetHeight(node.right) == 2) //Si se cumple hay desequilibrio
            {
                //Rotacion derecha
                if(item.ID < node.left.item.ID)
                {
                    node = rotateRight(node);

                } else {
                    node = doubleRight(node);

                }

            }


        } else if(item.ID > node.item.ID)
        {
            //lado derecho
            node.right = insertRecursive(item, node.right);
            if(GetHeight(node.right) - GetHeight(node.left) == 2)
            {
                //Rotacion izquirda
                if(item.ID > node.right.item.ID)
                {
                    node = rotateleft(node);
                } else {
                    node = doubleLeft(node);
                }

            }


        } else {
            throw new Exception($"El elemento con ID {item.ID} ya está insertado en el árbol.");
        }

            node.height = getMaxheight(GetHeight(node.left), GetHeight(node.right)) + 1;
        return node;


    }
    public Nodo_Avl rotateRight(Nodo_Avl node2)
    {
        Nodo_Avl node1 = node2.left;
        node2.left = node1.right;
        node1.right = node2;
        node2.height = getMaxheight(GetHeight(node2.left), GetHeight(node2.right)) + 1;
        node1.height = getMaxheight(GetHeight(node1.left), node2.height) + 1;
        return node1;
    }

    public Nodo_Avl doubleRight(Nodo_Avl node)
    {
        node.right = rotateleft(node.right);
        return rotateRight(node);
    }

    public Nodo_Avl rotateleft(Nodo_Avl node1)
    {
        Nodo_Avl node2 = node1.right;
        node1.right = node2.left;
        node2.left = node1;
        node1.height = getMaxheight(GetHeight(node1.left), GetHeight(node1.right)) + 1;
        node2.height = getMaxheight(GetHeight(node2.right), node1.height) + 1;
        return node2;
    }

    public Nodo_Avl doubleLeft(Nodo_Avl node)
    {
        node.left = rotateRight(node.left);
        return rotateleft(node);
    }

    public int GetHeight(Nodo_Avl node)
    {
        return node == null ? -1 : node.height;
    }

    public int getMaxheight(int leftNode, int rightNode)
    {
        return leftNode > rightNode ? leftNode : rightNode;
    }


    //Graficacion
    public void treeGraph()
    {
        nodes = "";
        connections = "";
        treeGraphRecursive(root);
        Console.WriteLine(nodes);
        Console.WriteLine(connections);

    }

    public void treeGraphRecursive(Nodo_Avl current)
    {
        if(current.left != null)
        {
            treeGraphRecursive(current.left);
            connections += "S"+ Convert.ToString(current.item.ID) + "->" + "S" + Convert.ToString(current.left.item.ID) + "\n";

        }
    
        //agregando ID al dibujo
        nodes += "S"+Convert.ToString(current.item.ID) + "[label=" + '"' +Convert.ToString(current.item.ID)+"|"+ current.item.Repuesto +"|"+current.item.Detalle + "|"+ Convert.ToString(current.item.Costo) + '"' + "shape ="+ '"'+"record" +'"'+"];";
           
        //nodes += 'S'+Convert.ToString(current.item.ID)+ "[label=" + Convert.ToString(current.item.ID)+"];";
        if(current.right != null)
        {
            treeGraphRecursive(current.right);
            connections += "S"+ Convert.ToString(current.item.ID) + "->" + "S" + Convert.ToString(current.right.item.ID) + "\n";
        }

    }

//inorden
 public string inOrden()
    {
        var resultado = new StringBuilder();

        // Agregar encabezados de la tabla una sola vez
        resultado.AppendLine($"{"ID",-5}{"Repuesto",-32}{"Detalle",-72}{"Costo",-10}|");
        resultado.AppendLine(new string('-', 100)); // Línea separadora
        connections = "";
        nodes = "";
        inOrdenRecursivo(root,resultado);
        Console.WriteLine("---- IN ORDEN ----");
        Console.WriteLine(nodes);
        Console.WriteLine(connections);
         return resultado.ToString();

    }

    private void inOrdenRecursivo(Nodo_Avl current,StringBuilder resultado)
    {
        if(current.left != null) 
        {
            inOrdenRecursivo(current.left,resultado);
             
            connections += " -> ";
        }
        //Obtenemos el valor de cada nodo
        //nodes += "S"+Convert.ToString(current.item.ID) + "[label=" + '"' +Convert.ToString(current.item.ID)+"|"+ current.item.Repuesto +"|"+current.item.Detalle + "|"+ Convert.ToString(current.item.Costo) + '"' + "shape ="+ '"'+"record" +'"'+"];";
        
        nodes += "S" + Convert.ToString(current.item.ID) + "[label="+  '"' +Convert.ToString(current.item.ID) +"|"  +current.item.Repuesto +"|"+current.item.Detalle+"|"+Convert.ToString(current.item.Costo)+'"'+ "shape ="+ '"'+"record" +'"'+"];";
        connections += "S"+Convert.ToString(current.item.ID);
        
        Console.WriteLine(Convert.ToString(current.item.ID));
         // Agregar encabezados de la tabla
    

        resultado.AppendLine($"|{current.item.ID,-3}|{current.item.Repuesto,-30}|{current.item.Detalle,-70}|{current.item.Costo,-8:F2}");

        if(current.right != null) 
        {
            connections += " -> ";
            inOrdenRecursivo(current.right,resultado);
        }
    
    }

    //preorden
    public string  preOrden()
    {
        var resultado = new StringBuilder();
         // Agregar encabezados de la tabla una sola vez

        resultado.AppendLine($"{"ID",-5}{"Repuesto",-32}{"Detalle",-72}{"Costo",-10}|");
        resultado.AppendLine(new string('-', 100)); // Línea separadora

        connections = "";
        connections = "";
        nodes = "";

        preOrdenRecursivo(root, resultado);

        Console.WriteLine("---- PRE ORDEN ----");
        Console.WriteLine(nodes);
        Console.WriteLine(connections);

        return resultado.ToString();

    }
    private void preOrdenRecursivo(Nodo_Avl current, StringBuilder resultado)
    {
                      
        //Obtenemos el valor de cada nodo
        nodes += "S" + Convert.ToString(current.item.ID) + "[label="+ Convert.ToString(current.item.ID) + "];";
        connections += "S"+Convert.ToString(current.item.ID);
        //Console.WriteLine(current.item.ID);
        
         Console.WriteLine(Convert.ToString(current.item.ID));
         
         // Agregar encabezados de la tabla una sola vez
         resultado.AppendLine($"|{current.item.ID,-3}|{current.item.Repuesto,-30}|{current.item.Detalle,-70}|{current.item.Costo,-8:F2}");

  

        if(current.left != null)
        {
            connections += " -> ";
            preOrdenRecursivo(current.left, resultado);
        }

        
        if(current.right != null)
        {
            connections += " -> ";
            preOrdenRecursivo(current.right, resultado);
        }

    }

//postorden
      public string postOrden()
    {
        var resultado = new StringBuilder();

            // Agregar encabezados de la tabla una sola vez
        resultado.AppendLine($"{"ID",-5}{"Repuesto",-32}{"Detalle",-72}{"Costo",-10}|");
        resultado.AppendLine(new string('-', 100)); // Línea separadora

        connections = "";
        nodes = "";
        postOrdenRecursivo(root, resultado);
        Console.WriteLine("------ POST ORDEN ------");
        Console.WriteLine(nodes);
        Console.WriteLine(connections);
        return resultado.ToString();

    }

    private void postOrdenRecursivo(Nodo_Avl current, StringBuilder resultado)
    {
        if(current.left != null)
        {
            postOrdenRecursivo(current.left, resultado);
            connections += " -> ";

        }

      

        if(current.right != null)
        {
            postOrdenRecursivo(current.right, resultado);
            connections += " -> ";

        }
        //Obtenemos el valor del nodo
        nodes += "S" + Convert.ToString(current.item.ID) + "[label="+ Convert.ToString(current.item.ID) + "];";
        connections += "S"+Convert.ToString(current.item.ID);
        Console.WriteLine(Convert.ToString(current.item.ID));
        resultado.AppendLine($"|{current.item.ID,-3}|{current.item.Repuesto,-30}|{current.item.Detalle,-70}|{current.item.Costo,-8:F2}");

    }   

    // Método para buscar un nodo en el árbol AVL
    public Nodo_Repuestos buscar(int id)
    {
        return buscarRecursivo(id, root);
    }

    private Nodo_Repuestos buscarRecursivo(int id, Nodo_Avl node)
    {
        if (node == null)
        {
            // No se encontró el nodo
            return null;
        }

        if (id == node.item.ID)
        {
            // Nodo encontrado
            return node.item;
        }
        else if (id < node.item.ID)
        {
            // Buscar en el subárbol izquierdo
            return buscarRecursivo(id, node.left);
        }
        else
        {
            // Buscar en el subárbol derecho
            return buscarRecursivo(id, node.right);
        }
    }

    // Método para actualizar un nodo en el árbol AVL
    public bool actualizar(int id, string nuevoRepuesto, string nuevoDetalle, double nuevoCosto)
    {
        Nodo_Repuestos nodo = buscar(id); // Reutilizamos el método buscar
        if (nodo != null)
        {
            // Actualizamos los valores del nodo encontrado
            nodo.Repuesto = nuevoRepuesto;
            nodo.Detalle = nuevoDetalle;
            nodo.Costo = nuevoCosto;
            return true; // Actualización exitosa
        }
        return false; // Nodo no encontrado
    }

    internal void insert(int iD)
    {
        throw new NotImplementedException();
    }
}