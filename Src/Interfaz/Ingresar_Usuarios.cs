using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;
using Gtk;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Ingresar_Usuario : My_Window
    {
       private readonly Data_Service _DataService;
        private Entry _txtId;
        private Entry _txtNombre;
        private Entry _txtApellido;
        private Entry _txtCorreo;
        private Entry _txtEdad;
        private Entry _txtContrasenia;

        public Ingresar_Usuario(Window contextParent, Data_Service dataService) : base("Ingreso Individual | AutoGest Pro", contextParent)
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

            _txtId = new Entry() { PlaceholderText = "ID" };
            _txtNombre = new Entry() { PlaceholderText = "Nombres" };
            _txtApellido = new Entry() { PlaceholderText = "Apellidos" };
            _txtCorreo = new Entry() { PlaceholderText = "Correo" };
             _txtEdad = new Entry() { PlaceholderText = "Edad" };
            _txtContrasenia = new Entry() { PlaceholderText = "Contraseña" };
           
            var btnIngresar = new Button("Ingresar");
            btnIngresar.Clicked += OnIngresarClicked;

            vbox.PackStart(_txtId, false, false, 5);
            vbox.PackStart(_txtNombre, false, false, 5);
            vbox.PackStart(_txtApellido, false, false, 5);
            vbox.PackStart(_txtCorreo, false, false, 5);
            vbox.PackStart(_txtEdad, false, false, 5);
            vbox.PackStart(_txtContrasenia, false, false, 5);

            vbox.PackStart(btnIngresar, false, false, 20);

            Add(vbox);
            ShowAll();
        }
        private void OnIngresarClicked(object? sender, System.EventArgs e)
        {
          
            var id = _txtId.Text;
            var nombre = _txtNombre.Text;
            var apellido = _txtApellido.Text;
            var correo = _txtCorreo.Text;
            var edad = _txtEdad.Text;
            var contrasenia = _txtContrasenia.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(edad) || string.IsNullOrEmpty(contrasenia))
            {
                PopError("Por favor, llene todos los campos");
                return;
            }
             
  //Data_Service _DataService = new Data_Service();
            try
            
            {
                _DataService.IngresarUsuario(new Usuario
                {
                    ID = int.Parse(id),
                    Nombres = nombre,
                    Apellidos = apellido,
                    Correo = correo,
                    Edad = int.Parse(edad),
                    Contrasenia = contrasenia,
                });
                PopSucess("Usuario ingresado exitosamente");
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            finally
            {
                _txtId.Text = "";
                _txtNombre.Text = "";
                _txtApellido.Text = "";
                _txtCorreo.Text = "";
                _txtEdad.Text = "";
                _txtContrasenia.Text = "";
            }
        }
    }
}