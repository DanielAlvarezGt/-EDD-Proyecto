using System;

public class NodoDoble<T>
{
    public T Valor { get; set; }
    public NodoDoble<T> Siguiente { get; set; }
    public NodoDoble<T> Anterior { get; set; }

    public NodoDoble(T valor)
    {
        Valor = valor;
        Siguiente = null;
        Anterior = null;
    }
}

public class ListaDoblementeEnlazada<T>
{
    private NodoDoble<T> cabeza;
    private NodoDoble<T> cola;

    public ListaDoblementeEnlazada()
    {
        cabeza = null;
        cola = null;
    }

    public void AgregarAlFinal(T valor)
    {
        NodoDoble<T> nuevoNodo = new NodoDoble<T>(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            cola.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = cola;
            cola = nuevoNodo;
        }
    }

    public void AgregarAlInicio(T valor)
    {
        NodoDoble<T> nuevoNodo = new NodoDoble<T>(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
            cola = nuevoNodo;
        }
        else
        {
            nuevoNodo.Siguiente = cabeza;
            cabeza.Anterior = nuevoNodo;
            cabeza = nuevoNodo;
        }
    }

    public void ImprimirDesdeCabeza()
    {
        NodoDoble<T> actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor is Vehiculo vehiculo)
            {
                Console.WriteLine($"ID: {vehiculo.Id}, ID Usuario: {vehiculo.Id_Usuario}, Marca: {vehiculo.Marca}, Modelo: {vehiculo.Modelo}, Placa: {vehiculo.Placa}, Año: {vehiculo.Año}");  
            }
            else
            {
                Console.WriteLine(actual.Valor);
            }
            actual = actual.Siguiente;
        }
    }

    public void ImprimirDesdeCola()
    {
        NodoDoble<T> actual = cola;
        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Anterior;
        }
    }
}