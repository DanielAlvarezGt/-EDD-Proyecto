namespace EDD_Proyecto2.Src.Modelos
{
    public class Factura
    {
        public    required int ID { get; set; }
        public     required int IdOrden { get; set; }
        public     required float Total { get; set; }
        
        
    }
}