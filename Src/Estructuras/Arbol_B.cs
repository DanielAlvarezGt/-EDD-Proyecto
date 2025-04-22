using System;   
using System.Collections.Generic;
using EDD_Proyecto2.Src.Modelos;
using System.Text;



namespace EDD_Proyecto2.Src.Estructuras;
public class Arbol_B
{
    private Nodo_ArbolB raiz;
    private const int ORDEN = 5;
    private const int MAX_CLAVES = ORDEN - 1;
    private const int MIN_CLAVES = (ORDEN / 2) - 1;

    public Arbol_B()
    {
        raiz = new Nodo_ArbolB();
    }

    public void Insertar(int Id, int id_ornden, double total)
    {
        Nodo_Factura nuevoElemento = new Nodo_Factura(Id, id_ornden, total);

        if (raiz.EstaLleno())
        {
            //Realizamos una division
            Nodo_ArbolB nuevaRaiz = new Nodo_ArbolB();
            nuevaRaiz.EsHoja = false;
            nuevaRaiz.Hijos.Add(raiz);
            DividirHijo(nuevaRaiz, 0);
            raiz = nuevaRaiz;
        }

        InsertarNoLleno(raiz, nuevoElemento);
    }

    public void InsertarNoLleno(Nodo_ArbolB nodo, Nodo_Factura elemento)
    {

        int i = nodo.Claves.Count - 1;

        if (nodo.EsHoja)
        {
            //insertamos la clave
            while (i >= 0 && elemento.Id < nodo.Claves[i].Id)
            {
                i--;
            }
            nodo.Claves.Insert(i + 1, elemento);
        }
        else
        {

            //Encuentra el hijo donde debe estar el elemento
            while (i >= 0 && elemento.Id < nodo.Claves[i].Id)
            {
                i--;
            }
            i++;

            //Si el hijo esta lleno
            if (nodo.Hijos[i].EstaLleno())
            {
                DividirHijo(nodo, i);
                if (elemento.Id > nodo.Claves[i].Id)
                {
                    i++;
                }
            }

            InsertarNoLleno(nodo.Hijos[i], elemento);

        }


    }

    public void DividirHijo(Nodo_ArbolB padre, int indiceHijo)
    {

        Nodo_ArbolB hijoCompleto = padre.Hijos[indiceHijo]; //Temporal
        Nodo_ArbolB nuevoHijo = new Nodo_ArbolB();

        nuevoHijo.EsHoja = hijoCompleto.EsHoja;

        //Elemento del medio que se promovera al padre
        Nodo_Factura elementoMedio = hijoCompleto.Claves[MIN_CLAVES];

        //Mover la mitad de las claves
        for (int i = MIN_CLAVES + 1; i < MAX_CLAVES; i++)
        {
            nuevoHijo.Claves.Add(hijoCompleto.Claves[i]);
        }

        if (!hijoCompleto.EsHoja)
        {
            for (int i = (ORDEN / 2); i < ORDEN; i++)
            {
                nuevoHijo.Hijos.Add(hijoCompleto.Hijos[i]);
            }
            hijoCompleto.Hijos.RemoveRange((ORDEN / 2), hijoCompleto.Hijos.Count - (ORDEN / 2));

        }

        hijoCompleto.Claves.RemoveRange(MIN_CLAVES, hijoCompleto.Claves.Count - MIN_CLAVES);

        padre.Hijos.Insert(indiceHijo + 1, nuevoHijo);

        int j = 0;
        while (j < padre.Claves.Count && padre.Claves[j].Id < elementoMedio.Id)
        {
            j++;
        }

        padre.Claves.Insert(j, elementoMedio);


    }



    public Nodo_Factura Buscar(int id)
    {
        return BuscarRecursivo(raiz, id);
    }

    private Nodo_Factura BuscarRecursivo(Nodo_ArbolB nodo, int id)
    {
        int i = 0;
        while (i < nodo.Claves.Count && id > nodo.Claves[i].Id)
        {
            i++;
        }

        if (i < nodo.Claves.Count && id == nodo.Claves[i].Id)
        {
            return nodo.Claves[i];
        }

        if (nodo.EsHoja)
        {
            return null;
        }

        return BuscarRecursivo(nodo.Hijos[i], id);

    }


    public  Factura? Eliminar(int id)
    {
         // Busca y guarda la factura que se va a eliminar
    var facturaEliminada = Buscar(id);
    if (facturaEliminada == null)
    {
        throw new Exception($"La factura con ID {id} no existe.");
    }


        EliminarRecursivo(raiz, id);

        // Si la raíz quedó vacía pero tiene hijos, el primer hijo se convierte en la nueva raíz
        if (raiz.Claves.Count == 0 && !raiz.EsHoja)
        {
            Nodo_ArbolB antiguaRaiz = raiz;
            raiz = raiz.Hijos[0];
        }
// Devuelve la factura eliminada con los valores correctos
return new Factura
{
    ID = facturaEliminada.Id, // Usa la propiedad Id de Nodo_Factura
    IdOrden = facturaEliminada.Id_Orden, // Si IdOrden no existe, usa Id como sustituto
    Total = (float)facturaEliminada.Total // Usa la propiedad Total de Nodo_Factura
};

}

    private void EliminarRecursivo(Nodo_ArbolB nodo, int id)
    {
        int indice = EncontrarIndice(nodo, id);

        // Caso 1: La clave está en este nodo
        if (indice < nodo.Claves.Count && nodo.Claves[indice].Id == id)
        {
            // Si es hoja, simplemente eliminamos
            if (nodo.EsHoja)
            {
                nodo.Claves.RemoveAt(indice);
            }
            else
            {
                // Si no es hoja, usamos estrategias más complejas
                EliminarDeNodoInterno(nodo, indice);
            }
        }
        else
        {
            // Caso 2: La clave no está en este nodo
            if (nodo.EsHoja)
            {
                Console.WriteLine($"El elemento con Id {id} no existe en el árbol");
                return;
            }

            // Determinar si el último hijo fue visitado
            bool ultimoHijo = (indice == nodo.Claves.Count);

            // Si el hijo tiene el mínimo de claves, rellenarlo
            if (!nodo.Hijos[indice].TieneMinimoClaves())
            {
                RellenarHijo(nodo, indice);
            }

            // Si el último hijo se fusionó, recurrimos al hijo anterior
            if (ultimoHijo && indice > nodo.Hijos.Count - 1)
            {
                EliminarRecursivo(nodo.Hijos[indice - 1], id);
            }
            else
            {
                //Exploramos el hijo con el indice encontrado.
                EliminarRecursivo(nodo.Hijos[indice], id);
            }
        }
    }

    private int EncontrarIndice(Nodo_ArbolB nodo, int id)
    {
        int indice = 0;
        while (indice < nodo.Claves.Count && nodo.Claves[indice].Id < id)
        {
            indice++;
        }
        return indice;
    }


    private void EliminarDeNodoInterno(Nodo_ArbolB nodo, int indice)
    {
        Nodo_Factura clave = nodo.Claves[indice];

        // Caso 2a: Si el hijo anterior tiene más del mínimo de claves
        if (nodo.Hijos[indice].Claves.Count > MIN_CLAVES)
        {
            // Reemplazar clave con el predecesor
            Nodo_Factura predecesor = ObtenerPredecesor(nodo, indice);
            nodo.Claves[indice] = predecesor;
            EliminarRecursivo(nodo.Hijos[indice], predecesor.Id);
        }
        // Caso 2b: Si el hijo siguiente tiene más del mínimo de claves
        else if (nodo.Hijos[indice + 1].Claves.Count > MIN_CLAVES)
        {
            // Reemplazar clave con el sucesor
            Nodo_Factura sucesor = ObtenerSucesor(nodo, indice);
            nodo.Claves[indice] = sucesor;
            EliminarRecursivo(nodo.Hijos[indice + 1], sucesor.Id);
        }
        // Caso 2c: Si ambos hijos tienen el mínimo de claves
        else
        {
            // Fusionar el hijo actual con el siguiente
            FusionarNodos(nodo, indice);
            EliminarRecursivo(nodo.Hijos[indice], clave.Id);
        }
    }

    private void FusionarNodos(Nodo_ArbolB nodo, int indice)
    {
        Nodo_ArbolB hijo = nodo.Hijos[indice];
        Nodo_ArbolB hermano = nodo.Hijos[indice + 1];

        // Añadir la clave del padre al hijo
        hijo.Claves.Add(nodo.Claves[indice]);

        // Añadir todas las claves del hermano al hijo
        for (int i = 0; i < hermano.Claves.Count; i++)
        {
            hijo.Claves.Add(hermano.Claves[i]);
        }

        // Si el hijo no es hoja, mover también los hijos
        if (!hijo.EsHoja)
        {
            for (int i = 0; i < hermano.Hijos.Count; i++)
            {
                hijo.Hijos.Add(hermano.Hijos[i]);
            }
        }

        // Remover la clave y el hijo del nodo padre
        nodo.Claves.RemoveAt(indice);
        nodo.Hijos.RemoveAt(indice + 1);
    }




    private Nodo_Factura ObtenerPredecesor(Nodo_ArbolB nodo, int indice)
    {
        Nodo_ArbolB actual = nodo.Hijos[indice];
        while (!actual.EsHoja)
        {
            actual = actual.Hijos[actual.Claves.Count];
        }
        return actual.Claves[actual.Claves.Count - 1];
    }


    private Nodo_Factura ObtenerSucesor(Nodo_ArbolB nodo, int indice)
    {
        Nodo_ArbolB actual = nodo.Hijos[indice + 1];
        while (!actual.EsHoja)
        {
            actual = actual.Hijos[0];
        }
        return actual.Claves[0];
    }


    private void RellenarHijo(Nodo_ArbolB nodo, int indice)
    {
        // Si el hermano izquierdo existe y tiene más del mínimo de claves
        if (indice > 0 && nodo.Hijos[indice - 1].Claves.Count > MIN_CLAVES)
        {
            TomaPrestadoDelAnterior(nodo, indice);
        }
        // Si el hermano derecho existe y tiene más del mínimo de claves
        else if (indice < nodo.Claves.Count && nodo.Hijos[indice + 1].Claves.Count > MIN_CLAVES)
        {
            TomaPrestadoDelSiguiente(nodo, indice);
        }
        // Si no se puede tomar prestado, fusionar con un hermano
        else
        {
            if (indice < nodo.Claves.Count)
            {
                FusionarNodos(nodo, indice);
            }
            else
            {
                FusionarNodos(nodo, indice - 1);
            }
        }
    }

    private void TomaPrestadoDelAnterior(Nodo_ArbolB nodo, int indice)
    {
        Nodo_ArbolB hijo = nodo.Hijos[indice];
        Nodo_ArbolB hermano = nodo.Hijos[indice - 1];

        // Desplazar todas las claves e hijos para hacer espacio para la nueva clave
        hijo.Claves.Insert(0, nodo.Claves[indice - 1]);

        // Si no es hoja, mover también el hijo correspondiente
        if (!hijo.EsHoja)
        {
            hijo.Hijos.Insert(0, hermano.Hijos[hermano.Claves.Count]);
            hermano.Hijos.RemoveAt(hermano.Claves.Count);
        }

        // Actualizar la clave del padre
        nodo.Claves[indice - 1] = hermano.Claves[hermano.Claves.Count - 1];
        hermano.Claves.RemoveAt(hermano.Claves.Count - 1);
    }

    private void TomaPrestadoDelSiguiente(Nodo_ArbolB nodo, int indice)
    {
        Nodo_ArbolB hijo = nodo.Hijos[indice];
        Nodo_ArbolB hermano = nodo.Hijos[indice + 1];

        // Añadir la clave del padre al hijo
        hijo.Claves.Add(nodo.Claves[indice]);

        // Si no es hoja, mover también el hijo correspondiente
        if (!hijo.EsHoja)
        {
            hijo.Hijos.Add(hermano.Hijos[0]);
            hermano.Hijos.RemoveAt(0);
        }

        // Actualizar la clave del padre
        nodo.Claves[indice] = hermano.Claves[0];
        hermano.Claves.RemoveAt(0);
    }






    public string GraficarGraphviz()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("digraph BTree {");
        sb.AppendLine("    node [shape=record];");

        int contadorNodos = 0;
        GraficarGraphvizRecursivo(raiz, sb, ref contadorNodos);

        sb.AppendLine("}");
        Console.WriteLine(sb.ToString());
        return sb.ToString();

    }

    private void GraficarGraphvizRecursivo(Nodo_ArbolB nodo, StringBuilder sb, ref int contadorNodos)
    {
        if (nodo == null)
            return;

        int nodoActual = contadorNodos++;

        // Construir la etiqueta del nodo
        StringBuilder etiquetaNodo = new StringBuilder();
        etiquetaNodo.Append($"node{nodoActual} [label=\"");

        for (int i = 0; i < nodo.Claves.Count; i++)
        {
            if (i > 0)
                etiquetaNodo.Append("|");
            etiquetaNodo.Append($"<f{i}> |Id: {nodo.Claves[i].Id}, Total: {nodo.Claves[i].Total}|");
        }

        // Añadir un puerto más para el último hijo
        if (nodo.Claves.Count > 0)
            etiquetaNodo.Append($"<f{nodo.Claves.Count}>");

        etiquetaNodo.Append("\"];");
        sb.AppendLine(etiquetaNodo.ToString());

        // Graficar los hijos y sus conexiones
        if (!nodo.EsHoja)
        {
            for (int i = 0; i <= nodo.Claves.Count; i++)
            {
                int hijoPosicion = contadorNodos;
                GraficarGraphvizRecursivo(nodo.Hijos[i], sb, ref contadorNodos);
                sb.AppendLine($"    node{nodoActual}:f{i} -> node{hijoPosicion};");
            }
        }
    }

     public bool IsEmpty()
        {
            return raiz == null;
        }


}
