using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;
using EDD_Proyecto2.Src.Interfaz;
using System.Text.Json;
using Gtk;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Actualizar_Repuestos : My_Window
    {
        private readonly Data_Service _DataService;
        private Entry _txtId;
        private Entry _txtRepuesto ;
        private Entry _txtDetalles;
        private Entry _txtCosto;
        
        public Actualizar_Repuestos(Window contextParent, Data_Service dataService) : base("Actualizacion de Repuestos | AutoGest Pro", contextParent)
        {
            // Inyección de dependencias
            _DataService = dataService;

            SetSizeRequest(900, 500);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => OnDeleteEvent();

           
            var hbox = new Box(Orientation.Horizontal, 20)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            var grid = new Grid() { ColumnSpacing = 8, RowSpacing = 8 };

            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Start,
                Valign = Align.Center
            };

            var lblId = new Label("Id") { Halign = Align.Start };
            var lblRepuesto = new Label("Repuesto") { Halign = Align.Start };
            var lblDetalles = new Label("Detalles") { Halign = Align.Start };
            var lblCosto = new Label("Costo") { Halign = Align.Start };

            _txtId = new Entry() { PlaceholderText = "Id" };
            _txtRepuesto = new Entry() { PlaceholderText = "Repuesto", Sensitive = false };
            _txtDetalles = new Entry() { PlaceholderText = "Detalles", Sensitive = false };
            _txtCosto = new Entry() { PlaceholderText = "Costo", Sensitive = false };

            var btnBuscar = new Button("Buscar");
            btnBuscar.Clicked += OnBuscarClicked;

            var btnModificar = new Button("Modificar");
            btnModificar.Clicked += OnModificarClicked;

            var btnActualizar = new Button("Actualizar");
           btnActualizar.Clicked += OnActualizarClicked;

         

            grid.Attach(lblId, 0, 0, 1, 1);
            grid.Attach(_txtId, 1, 0, 1, 1);
            grid.Attach(btnBuscar, 2, 0, 1, 1);
            grid.Attach(lblRepuesto, 0, 1, 1, 1);
            grid.Attach(_txtRepuesto, 1, 1, 2, 1);
            grid.Attach(lblDetalles, 0, 2, 1, 1);
            grid.Attach(_txtDetalles, 1, 2, 2, 1);
            grid.Attach(lblCosto, 0, 3, 1, 1);
            grid.Attach(_txtCosto, 1, 3, 2, 1);
            grid.Attach(btnModificar, 0, 4, 1, 1);
            grid.Attach(btnActualizar, 1, 4, 1, 1);
        
            vbox.Add(grid);

            hbox.PackStart(vbox, true, true, 0);
           // hbox.PackStart(_txtvVehiculos, true, true, 0);

            Add(hbox);

            ShowAll();
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
                Repuestos repuesto = _DataService.BuscarRepuestoPorId(idInt);
                
                   _txtRepuesto.Text = repuesto.Repuesto;
                _txtDetalles.Text = repuesto.Detalles;
                _txtCosto.Text = repuesto.Costo.ToString();
                
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
        }


        private void OnActualizarClicked(object? sender, EventArgs e)
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

            var repuestos = _txtRepuesto.Text;
            if (string.IsNullOrEmpty(repuestos))
            {
                PopError("El campo Nombres no puede estar vacío.");
                return;
            }

            var detalles = _txtDetalles.Text;
            if (string.IsNullOrEmpty(detalles))
            {
                PopError("El campo Apellidos no puede estar vacío.");
                return;
            }

            var costos = _txtCosto.Text;
            if (string.IsNullOrEmpty(costos))
            {
                PopError("El campo Correo no puede estar vacío.");
                return;
            }
            if (!double.TryParse(costos, out var costoDouble))
            {
                PopError("El campo Costo debe ser un número válido.");
                return;
            }
  //Data_Service _DataService = new Data_Service();
            try
            {
                _DataService.ActualizarRepuesto(idInt, repuestos, detalles, costoDouble);
                PopSucess("Repuesto actualizado correctamente.");
                ClearEntries();
                //_txtvVehiculos.Buffer.Text = "Hello World!\nVehiculos del Usuario";
                EnableViews(false);
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
        }
        private void OnModificarClicked(object? sender, EventArgs e)
        {
            EnableViews(true);
            PopSucess("Modo de edición activado.");
        }
        private void EnableViews(bool enable)
        {
            _txtId.Sensitive = !enable;
            _txtRepuesto.Sensitive = enable;
            _txtDetalles.Sensitive = enable;
            _txtCosto.Sensitive = enable;
        }
        private void ClearEntries()
        {
            _txtId.Text = "";
            _txtRepuesto.Text = "";
            _txtDetalles.Text = "";
            _txtCosto.Text = "";
        }   
    }
}