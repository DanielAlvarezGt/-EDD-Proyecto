using System;
using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Estructuras;


namespace EDD_Proyecto2.Src.Estructuras;
public class Nodo_T {
  
      //public Nodo_Servicios item;
      public int ID;
      public int IdRepuesto;
        public int IdVehiculo; 
        public string Detalles;
        public double Costo;
      public Nodo_T? right;
    public Nodo_T? left;


    public Nodo_T(int id, int idrepuesto, int idvehiculo, string detalles, double costo)
    {
        ID = id;
        IdRepuesto = idrepuesto;
        IdVehiculo = idvehiculo;
        Detalles = detalles;
        Costo = costo;
        //item = Item;
        right = null;
        left = null;

    } 
}