

using System;
using EDD_Proyecto2.Src.Modelos;




namespace EDD_Proyecto2.Src.Estructuras
{

   
public class Lista_Simple
    {
        private Nodo_Usuario cabeza = null; //cabeza de la lista
    
    //metodo para insertar un nuevo nodo

        public void Agregar(int id, string nombres, string apellidos, string correo, int edad, string contrasenia)
        {
            //se crea el nodo
            Nodo_Usuario nuevo = new Nodo_Usuario(id, nombres, apellidos, correo, edad, contrasenia);
            
            //se verifica si es null
            if (cabeza == null)
            {
                cabeza = nuevo;
            }
            else
            {
                //se crea temporal
                Nodo_Usuario actual = cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                    }
                    actual.Siguiente = nuevo;
                                 
                }
                
        }
        
           public int Actualizar(int id, string nombres, string apellidos, string correo)
        {
            if (cabeza == null) return 0;
            if (cabeza.ID == id)
            {
                cabeza.Nombres = nombres;
                cabeza.Apellidos = apellidos;
                cabeza.Correo = correo;
                return 1;
            }
            Nodo_Usuario actual = cabeza;
            while (actual != null)
            {
                if (actual.ID == id)
                {
                    actual.Nombres = nombres;
                    actual.Apellidos = apellidos;
                    actual.Correo = correo;
                    return 1;
                }
                actual = actual.Siguiente;
            }
            return 0;
        }
        
    public void Imprimir()
    {
        Nodo_Usuario actual = cabeza;
        while (actual != null)
        {
            Console.WriteLine($"ID: {actual.ID}, Nombre: {actual.Nombres} {actual.Apellidos}, Edad: {actual.Edad}");
            actual = actual.Siguiente;
        }
    }




        //metodo para buscar un nodo
        /*
        public Nodo_Usuario Buscar(int id)
        {
            Nodo_Usuario actual = cabeza;
            while (actual != null) 
            {
                if (actual.ID == id)
                {
                    return actual;
                }
                actual = actual.Siguiente;
            }
            return null;
            
        }*/


 public int Search(int id)
        {
            if (cabeza == null) return 0;
            Nodo_Usuario actual = cabeza;
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

        


public Usuario? Find(int id)
        {
            if (cabeza == null) return null; 
            
            Nodo_Usuario actual = cabeza; 
            while (actual != null)
            {
                {
                if (actual.ID == id)    
                    return new Usuario
                    {
                        ID = actual.ID,
                        Nombres = actual.Nombres,
                        Apellidos = actual.Apellidos,
                        Correo = actual.Correo,
                        Edad= actual.Edad,
                        Contrasenia = actual.Contrasenia
                       
                    };
                }
                actual = actual.Siguiente;
            }
            return null;
        }
        //metodo para eliminar un nodo

        
        public int Eliminar(int id) 
        {
            if (cabeza == null) return 0;
            if (cabeza.ID == id)
            {
                cabeza = cabeza.Siguiente;
                return 1;
            }
            Nodo_Usuario actual = cabeza;
            while (actual.Siguiente != null)
            {   
                if (actual.Siguiente.ID == id)
                {
                    actual.Siguiente = actual.Siguiente.Siguiente;
                    return 1;
                }
                actual = actual.Siguiente;
            }
            return 1;
        }

        //metodo para imprimir un nodo

/*        public void Imprimir()
        {
            Nodo_Usuario actual = cabeza;
            while (actual != null)
            {
                Console.WriteLine("ID: " + actual.Id + " Nombres: " + actual.Nombres + " Apellidos: " + actual.Apellidos + " Correo: " + actual.Correo + " Contrasenia: " + actual.Contrasenia);
                actual = actual.Siguiente;
            }
        }*/


/*
        //liberar la memoria de los nodos de la lista
       ~Lista_Simple()
        {
            Nodo_Usuario actual = cabeza;
            while (actual != null)
            {
                Nodo_Usuario Siguiente = actual.Siguiente;
                //Marshal.FreeHGlobal((IntPtr)actual);
                actual = Siguiente;
            }
        }*/

    }
    }
