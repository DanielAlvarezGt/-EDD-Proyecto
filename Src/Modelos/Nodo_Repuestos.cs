using System;

namespace EDD_Proyecto2.Src.Modelos;


public class Nodo_Repuestos

{
 //crear el nodo
    public int ID;
    public string Repuesto;
    public string Detalle;
    public double Costo;

    public Nodo_Repuestos(int id, string repuesto, string detalle, double costo)
    {
        ID = id;
        Repuesto = repuesto;
        Detalle = detalle;
        Costo = costo;
    }
}
