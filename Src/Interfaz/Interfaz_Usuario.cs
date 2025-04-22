using EDD_Proyecto2.Src.Interfaz;
using EDD_Proyecto2.Src.Servicios;
using EDD_Proyecto2.Src.Modelos;
using Gtk;
using System;
using EDD_Proyecto2Src.Interfaz;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Interfaz_Usuario : My_Window
    {
        
 private readonly Data_Service _DataService;
   private Factura? _ultimaFacturaCreada;

        public Interfaz_Usuario(Window contextParent, Data_Service dataService) : base("Interfaz de Usuario | AutoGest Pro", contextParent)
        {
            
             _DataService = dataService;    

            SetDefaultSize(450, 400);
            SetPosition(WindowPosition.Center);
              DeleteEvent += (_, _) => OnDeleteEvent();

       
            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };


            // Creando botones
            
                var btnIngresoVehiculos = new Button("Ingreso Vehiculos");
           btnIngresoVehiculos.Clicked += OnIngresoVehiculosClicked;

            var btnVerServivios = new Button("Visualizacion de Servicios");
            btnVerServivios.Clicked += OnVisualizarClicked;

               var btnVerFactura = new Button("Ver Factura");
            btnVerFactura.Clicked += OnVerFacturaClicked;

            var btnCancelarFactura = new Button("Cancelar Factura");
            btnCancelarFactura.Clicked += OnCancelarFacturaClicked;
  

            // Agregando botones al vbox
            vbox.PackStart(btnIngresoVehiculos, false, false, 6);
            vbox.PackStart(btnVerServivios, false, false, 6);
            vbox.PackStart(btnVerFactura, false, false, 6);
            vbox.PackStart(btnCancelarFactura, false, false, 6);
          

            //vbox.PackStart(btnCancelarFactura, false, false, 6);
            // Aplicando estilos a los botones
         

            Add(vbox);
            ShowAll();
        }


        private void OnIngresoVehiculosClicked(object? sender, EventArgs e)
        {
            var IngresoVehiculos = new IngresoVehiculo(this, _DataService);
            IngresoVehiculos.ShowAll();
            Hide();
        }

 private void OnVisualizarClicked(object? sender, EventArgs e)
        {
            var VisualizarServicios = new Ordenar_Servicios(this, _DataService);
            VisualizarServicios.ShowAll();
            Hide();
        }


  

           private void OnCancelarFacturaClicked(object? sender, EventArgs e)
        {
            // Verificar si hay una factura asignada
            if (_ultimaFacturaCreada == null)
            {
                PopError("No hay ninguna factura creada para cancelar. Por favor, busque una factura primero.");
                //                OnBuscarFacturaClicked(sender, e); // Llama al método para buscar una factura
                return;
            }

            try
            {
                // Intentar cancelar la factura
                var facturaCancelada = _DataService.CancelarFactura(_ultimaFacturaCreada);
                if (facturaCancelada != null)
                {
                    PopSucess($"Factura Cancelada/Pagada\nID: {facturaCancelada.ID}\nId_Orden: {facturaCancelada.IdOrden}\nTotal: {facturaCancelada.Total}");
                    _ultimaFacturaCreada = null; // Limpiar la referencia después de cancelar
                }
                else
                {
                    PopError("No se pudo cancelar la factura.");
                }
            }
            catch (Exception ex)
            {
                PopError($"Error al cancelar la factura: {ex.Message}");
            }
        }


        private void OnVerFacturaClicked(object? sender, EventArgs e)
        {
            var generarServicios = new Generar_Servicio(this, _DataService);

            // Suscribirse al evento FacturaGenerada
            generarServicios.FacturaGenerada += factura =>
            {
                _ultimaFacturaCreada = factura;
                PopSucess($"Factura generada:\nID: {factura.ID}\nId_Orden: {factura.IdOrden}\nTotal: {factura.Total}");
            };

            generarServicios.ShowAll();
            Hide();
        }
        
        
    }
}
