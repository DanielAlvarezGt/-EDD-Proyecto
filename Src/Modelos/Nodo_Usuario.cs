using System;

namespace EDD_Proyecto2.Src.Modelos

{
 //crear el nodo

 public class Nodo_Usuario
 {

public int ID;
public string Nombres;
public string Apellidos;
public string Correo;
public int Edad;
public string Contrasenia;

public Nodo_Usuario? Siguiente;

//constructor
public Nodo_Usuario(int id, string nombres, string apellidos, string correo, int edad, string contrasenia)
{
    ID = id;
    Nombres = nombres;
    Apellidos = apellidos;
    Correo = correo;
    Edad = edad;
    Contrasenia = contrasenia;
    Siguiente = null;

}
 }
}
