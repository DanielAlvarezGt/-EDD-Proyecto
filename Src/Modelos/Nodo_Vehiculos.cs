using System;

namespace EDD_Proyecto.Src.Modelos
{
    public class Nodo_Vehiculos
        {
        public int ID;
        public int IdUsuario;
        public string Marca;
        public int Modelo;
        public string Placa;
        public Nodo_Vehiculos? Siguiente;
        public Nodo_Vehiculos? Anterior;

        //constructor
public Nodo_Vehiculos(int id, int idUsuario, string marca, int modelo, string placa)
{
    ID = id;
    IdUsuario = idUsuario;
    Marca = marca;
    Modelo = modelo;
    Placa = placa;
    Siguiente = null;
    Anterior = null;

}

}
}

