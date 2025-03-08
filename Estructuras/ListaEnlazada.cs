using System;

public class Nodo<T>
{
    public T Valor { get; set; }
    public Nodo<T> Siguiente { get; set; }

    public Nodo(T valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada<T>
{
    public Nodo<T> cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }

    public void Agregar(T valor)
    {
        Nodo<T> nuevoNodo = new Nodo<T>(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo<T> actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
    }

    public void Imprimir()
    {
        Nodo<T> actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor is Usuario usuario)
            {
                Console.WriteLine($"ID: {usuario.Id}, Nombres: {usuario.Nombres}, Apellidos: {usuario.Apellidos}, Correo: {usuario.Correo}, Contraseña: {usuario.Contraseña}");
            }
            else
            {
                Console.WriteLine(actual.Valor);
            }
            actual = actual.Siguiente;
        }
    }
}