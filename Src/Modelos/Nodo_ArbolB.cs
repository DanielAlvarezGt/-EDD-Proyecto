using System;
using EDD_Proyecto2.Src.Estructuras;

namespace EDD_Proyecto2.Src.Modelos;


public class Nodo_ArbolB
{
    private const int ORDEN = 5;
    private const int MAX_CLAVES = ORDEN - 1;
    private const int MIN_CLAVES = (ORDEN / 2) - 1;

    public List<Nodo_Factura> Claves;
    public List<Nodo_ArbolB> Hijos;
    public bool EsHoja;

    public Nodo_ArbolB()
    {
        Claves = new List<Nodo_Factura>(MAX_CLAVES);
        Hijos = new List<Nodo_ArbolB>(ORDEN);
        EsHoja = true;
    }

    public bool EstaLleno()
    {
        return Claves.Count >= MAX_CLAVES;
    }

    public bool TieneMinimoClaves()
    {
        return Claves.Count >= MIN_CLAVES;
    }


}
