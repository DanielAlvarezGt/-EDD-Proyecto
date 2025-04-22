using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;
using Gtk;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class IngresoVehiculo: My_Window 
    {
        private readonly Data_Service _DataService;
        private Entry _txtId;
        private Entry _txtiIdUsuario;
        private Entry _txtMarca;
        private Entry _txtModelo;
        private Entry _txtPlaca;
        /**
         * Init the window
         */
        public IngresoVehiculo(Window contextParent, Data_Service dataService): base("Ingreso de Vehiculos | AutoGest Pro", contextParent)
        {
            // Inyectamos dataService
            _DataService = dataService;

            SetDefaultSize(450, 350);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => OnDeleteEvent();

            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            _txtId = new Entry(){ PlaceholderText = "ID"};
            _txtiIdUsuario = new Entry(){ PlaceholderText = "ID Usuario"};
            _txtMarca = new Entry(){ PlaceholderText = "Marca"};
            _txtModelo = new Entry(){ PlaceholderText = "Modelo"};
            _txtPlaca = new Entry(){ PlaceholderText = "Placa"};

            var btnIngresar = new Button("Ingresar");
            btnIngresar.Clicked += OnIngresarClicked;

            vbox.PackStart(_txtId, false, false, 5);
            vbox.PackStart(_txtiIdUsuario, false, false, 5);
            vbox.PackStart(_txtMarca, false, false, 5);
            vbox.PackStart(_txtModelo, false, false, 5);
            vbox.PackStart(_txtPlaca, false, false, 5);
            vbox.PackStart(btnIngresar, false, false, 20);

            Add(vbox);
            ShowAll();
        }

        private void OnIngresarClicked(object? sender, System.EventArgs e)
        {
            var id = _txtId.Text;
            var idUsuario = _txtiIdUsuario.Text;
            var marca = _txtMarca.Text;
            var modelo = _txtModelo.Text;
            var placa = _txtPlaca.Text;
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(idUsuario) || string.IsNullOrEmpty(marca) || string.IsNullOrEmpty(modelo) || string.IsNullOrEmpty(placa))
            {
                PopError("Todos los campos son requeridos");
                return;
            }

             //Data_Service _DataService = new Data_Service();
            try
            {
                _DataService.IngresarVehiculo(new Vehiculo
                {
                    ID = int.Parse(id),
                    ID_Usuario = int.Parse(idUsuario),
                    Marca = marca,
                    Modelo = int.Parse(modelo),
                    Placa = placa
                });
                PopSucess("Vehiculo ingresado correctamente");
                OnDeleteEvent();
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            } finally {
                _txtId.Text = "";
                _txtiIdUsuario.Text = "";
                _txtMarca.Text = "";
                _txtModelo.Text = "";
                _txtPlaca.Text = "";
            }
        }
    }
}