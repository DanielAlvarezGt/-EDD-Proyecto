using EDD_Proyecto2.Src.Estructuras;
using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;


using Gtk;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Generar_Servicio : My_Window
    {
         public event Action<Factura>? FacturaGenerada;
        private readonly Data_Service _DataService;
        private Entry _txtId;
        private Entry _txtIdRepuesto;
        private Entry _txtIdVehiculo;
        private Entry _txtDetalles;
        private Entry _txtCosto;
        private Factura? _ultimaFacturaCreada;

        public Generar_Servicio(Window contextParent, Data_Service dataService) : base("Generar Servicio | AutoGest Pro", contextParent)
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

            _txtId = new Entry() { PlaceholderText = "ID" };
            _txtIdRepuesto = new Entry() { PlaceholderText = "ID Repuesto" };
            _txtIdVehiculo = new Entry() { PlaceholderText = "ID Vehiculo" };
            _txtDetalles = new Entry() { PlaceholderText = "Detalles" };
            _txtCosto = new Entry() { PlaceholderText = "Costo" };

            var btnGenerar = new Button("Guardar");
            btnGenerar.Clicked += OnGenerarClicked;

            var btnBuscar = new Button("Buscar");
            btnBuscar.Clicked += OnBuscarClicked;

             var btnBuscarFactura = new Button("Ver factura");
            btnBuscarFactura.Clicked += OnBuscarFacturaClicked;

             var btnCancelarFactura = new Button("Cancelar factura");
            btnCancelarFactura.Clicked += OnCancelarFacturaClicked;

         

            vbox.PackStart(_txtId, false, false, 5);
            vbox.PackStart(_txtIdRepuesto, false, false, 5);
            vbox.PackStart(_txtIdVehiculo, false, false, 5);
            vbox.PackStart(_txtDetalles, false, false, 5);
            vbox.PackStart(_txtCosto, false, false, 5);
            vbox.PackStart(btnGenerar, false, false, 20);
            vbox.PackStart(btnBuscar, false, false, 20);
            vbox.PackStart(btnCancelarFactura, false, false, 20);
            vbox.PackStart(btnBuscarFactura, false, false, 20);

            Add(vbox);
            ShowAll();
        }

        private void OnGenerarClicked(object? sender, System.EventArgs e)
        {
            var id = _txtId.Text;
            var idRepuesto = _txtIdRepuesto.Text;
            var idVehiculo = _txtIdVehiculo.Text;
            var detalles = _txtDetalles.Text;
            var costo = _txtCosto.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(idRepuesto) || string.IsNullOrEmpty(idVehiculo) || string.IsNullOrEmpty(detalles) || string.IsNullOrEmpty(costo))
            {
                PopError("Por favor, llene todos los campos");
                return;
            }
            try
            {
                
                _DataService.IngresarServicio(new Servicio
                {
                    ID = int.Parse(id),
                    IdRepuesto = int.Parse(idRepuesto),
                    IdVehiculo = int.Parse(idVehiculo),
                    Detalles = detalles,
                    Costo = float.Parse(costo)
                });

                var respuesto = _DataService.BuscarRepuestoPorId(int.Parse(idRepuesto));
                var factura = new Factura
                {
                    ID = int.Parse(id),
                    IdOrden = int.Parse(id),
                    Total = (float)respuesto.Costo + float.Parse(costo)
                    
                };

                _DataService.CrearFactura(factura);

                // Almacenar la última factura creada
                _ultimaFacturaCreada = factura;

                PopSucess("Servicio generado correctamente");
                PopSucess($"Factura \nID: {factura.ID}\nId_Orden: {factura.IdOrden}\nTotal: {factura.Total}");
               
   
                
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            finally
            {
                _txtId.Text = "";
                _txtIdRepuesto.Text = "";
                _txtIdVehiculo.Text = "";
                _txtDetalles.Text = "";
                _txtCosto.Text = "";
            }
        }

          private void OnBuscarClicked(object? sender, EventArgs e)
        {
            var id = _txtId.Text;
            if (string.IsNullOrEmpty(id))
            {
                PopError("El campo ID no puede estar vacío.");
                return;
            }
            if (!int.TryParse(id, out var idInt))
            {
                PopError("El campo ID debe ser un número entero.");
                return;
            }
 // Data_Service _DataService = new Data_Service();
            try
            {
                var servicio = _DataService.BuscarServicioPorId(idInt);
                if (servicio != null)
                {
                    _txtIdRepuesto.Text = servicio.IdRepuesto.ToString();
                    _txtIdVehiculo.Text = servicio.IdVehiculo.ToString();
                    _txtDetalles.Text = servicio.Detalles;
                    _txtCosto.Text = servicio.Costo.ToString();
                }
                else
                {
                    PopError($"No se encontró el servicio con ID {idInt}.");
                }
                
                

            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
        }

            private void OnCancelarFacturaClicked(object? sender, EventArgs e)
        {
              if (_ultimaFacturaCreada == null)
    {
        PopError("No hay ninguna factura creada para cancelar.");
        return;
    }
            try
            {
                var facturaCancelada = _DataService.CancelarFactura(_ultimaFacturaCreada);
                if (facturaCancelada != null)
                {
                PopSucess($"Factura Cancelada/Pagada\nID: {facturaCancelada.ID}\nId_Orden: {facturaCancelada.IdOrden}\nTotal: {facturaCancelada.Total}");
                }
                else
                {
                PopError("No se pudo cancelar la factura.");
                }
            }
                catch (Exception ex)
                {
                    PopError(ex.Message);
                }
        }

         //onBuscarFacturaClicked
        private void OnBuscarFacturaClicked(object? sender, EventArgs e)
        {
            var id = _txtId.Text;
            if (string.IsNullOrEmpty(id))
            {
                PopError("El campo ID no puede estar vacío.");
                return;
            }
            if (!int.TryParse(id, out var idInt))
            {
                PopError("El campo ID debe ser un número entero.");
                return;
            }
 try
{
     if (_ultimaFacturaCreada == null)
    {
        PopError("No hay ninguna factura creada para buscar.");
        return;
    }
    var factura = _DataService.BuscarFacturaPorId(_ultimaFacturaCreada); // Buscar factura por ID
  
    if (factura != null)
    {
        PopSucess($"Factura encontrada \nID: {factura.ID}\nId_Orden: {factura.IdOrden}\nTotal: {factura.Total}");
    }
    else
    {
        PopError($"No se encontró la factura con ID {idInt}.");
    }
}
catch (Exception ex)
{
    PopError(ex.Message);
}


    }
       private void OnORdenarServiciosClicked(object? sender, EventArgs e)
        {
            var OrdenarServicios = new Ordenar_Servicios(this, _DataService);
            OrdenarServicios.ShowAll();
            Hide();
        }
    }
}
