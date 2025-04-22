

namespace EDD_Proyecto2.Src.Modelos;


public class Nodo_Factura

{
 //crear el nodo
    public int Id;
    public int Id_Orden;
    public double Total;
  

    public Nodo_Factura(int id, int id_orden, double total)
    {
        Id = id;
       Id_Orden = id_orden;
        Total = total;
    }
   
    
}
