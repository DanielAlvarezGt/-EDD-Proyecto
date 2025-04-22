using EDD_Proyecto2.Src.Estructuras;
using EDD_Proyecto2.Src.Modelos;
public class Nodo_Avl{


    public Nodo_Repuestos item;
    public Nodo_Avl? right;
    public Nodo_Avl? left;
    public int height;

    // Constructor
    public Nodo_Avl(Nodo_Repuestos Item)
    {
        item = Item;
        right = null;
        left = null;
        height = 0;
    }
}