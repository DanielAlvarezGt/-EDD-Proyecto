using System;

public class NodoCircular<T>
{
    public T Valor { get; set; }
    public NodoCircular<T> Siguiente { get; set; }

    public NodoCircular(T valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaCircular<T>
{
    private NodoCircular<T> cabeza;
    private NodoCircular<T> cola;

    public ListaCircular()
    {
        cabeza = null;
        cola = null;
    }

    public void Agregar(T valor)
    {
        NodoCircular<T> nuevoNodo = new NodoCircular<T>(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
            cola.Siguiente = cabeza;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            cola = nuevoNodo;
            cola.Siguiente = cabeza;
        }
    }

    public void Imprimir()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        NodoCircular<T> actual = cabeza;
        do
        {
            if (actual.Valor is Repuestos repuestos)
            {
                Console.WriteLine($"ID: {repuestos.Id}, Repuesto: {repuestos.Repuesto}, Detalles: {repuestos.Detalles}, Costo: {repuestos.Costo}");  
            }
            else
            {
                Console.WriteLine(actual.Valor);
            }
            actual = actual.Siguiente;
        } while (actual != cabeza);
    }
}