using Gtk;
using EDD_Proyecto2.Src.Modelos;
using System.Text.Json;
using EDD_Proyecto2.Src.Servicios;
using EDD_Proyecto2.Src.Interfaz;

namespace EDD_Proyecto2.Src.Interfaz
   

{
    public class Carga_Masiva : My_Window 
    {
       private readonly Data_Service _DataService;
        private ComboBoxText _comboBox;

        public Carga_Masiva(Window contextParent,Data_Service dataService) : base("Carga Masiva | AutoGest Pro", contextParent)
        {
            // Inyección de dependencias
            _DataService = dataService;

            SetDefaultSize(450, 350);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => OnDeleteEvent();

            // AplicarEstilos();

            var vbox = new Box(Orientation.Vertical, 15)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            _comboBox = new ComboBoxText();

            _comboBox.AppendText("Carga de Usuarios");
            _comboBox.AppendText("Carga de Vehiculos");
            _comboBox.AppendText("Carga de Repuestos");
            _comboBox.Active = 0;

            var btnCargar = new Button("Cargar");
            btnCargar.Clicked += OnCargarClicked;

            vbox.PackStart(_comboBox, false, false, 30);
            vbox.PackStart(btnCargar, false, false, 30);

            Add(vbox);
            ShowAll();
        }

        private void OnCargarClicked(object? sender, System.EventArgs e)
        {
            using var dialog = new FileChooserDialog("Seleccione el archivo JSON a cargar",
                this,
                FileChooserAction.Open,
                "Cancelar", ResponseType.Cancel,
                "Abrir", ResponseType.Accept);
            dialog.SetSizeRequest(600, 400);
            dialog.SelectMultiple = false;
            var filter = new FileFilter { Name = "Archivos JSON" };
            filter.AddPattern("*.json");
            //dialog.Filter = filter;
            dialog.SetCurrentFolder("/home/danielpc07/Documentos/ArchivosPrueba/");

            try
            {
                if (dialog.Run() == (int)ResponseType.Accept)
                {
                    var filename = dialog.Filename;

                    string jsonText = File.ReadAllText(filename);
                    // Console.WriteLine(jsonText);
                    ProcessFileByType(jsonText);
                }
                else
                {
                    PopError("No se seleccionó ningún archivo");
                }
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            finally
            {
                dialog.Destroy();
            }
        }
        private void ProcessFileByType(string jsonText)
        {
            switch (_comboBox.ActiveText)
            {
                case "Carga de Usuarios":
                    DeserializarUsuarios(jsonText);
                    break;
                case "Carga de Vehiculos":
                    DeserializarVehiculos(jsonText);
                    break;
                case "Carga de Repuestos":
                   DeserializarRepuestos(jsonText);
                    break;
                default:
                    break;
            }
            return;
        }
        // metodo DeserializarUsuarios en el cual se deserializa el json 
        // y se ingresa a la lista de usuarios
        
        private void DeserializarUsuarios(string jsonText)
        {
            //aca se deserializa el json y se ingresa a la lista de usuarios
            List<Usuario>? usuarios = null;
            try
            {
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(jsonText);
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            if (usuarios is null)
            {
                PopError("No se pudo deserializar el archivo JSON");
                return;
            }
//Data_Service _DataService = new Data_Service();
//aca lo que hace es recorrer la lista de usuarios y los ingresa a la lista de usuarios
            foreach (var usuario in usuarios)
            {
                  //Data_Service _DataService = new Data_Service();
                try
                {
                    //aca lo que hace con el _DataService es ingresar el usuario a la lista de usuarios
                    _DataService.IngresarUsuario(usuario);
                }
                catch (Exception ex)
                {
                    PopError(ex.Message);
                }
            }
            PopSucess("Usuarios cargados exitosamente");
            // _DataService.ListadoUsuarios.Print();
        }

        private void DeserializarVehiculos(string jsonText)
        {
            List<Vehiculo>? vehiculos = null;
            try
            {
                vehiculos = JsonSerializer.Deserialize<List<Vehiculo>>(jsonText);
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            if (vehiculos is null)
            {
                PopError("No se pudo deserializar el archivo JSON");
                return;
            }
//Data_Service _DataService = new Data_Service();
            foreach (var vehiculo in vehiculos)
            {

                  //Data_Service _DataService = new Data_Service();
                try
                {
                    _DataService.IngresarVehiculo(vehiculo);
                }
                catch (Exception ex)
                {
                    PopError(ex.Message);
                }
            }
            PopSucess("Vehiculos cargados exitosamente");
            // _DataService.ListadoVehiculos.Print();
        }
        
        private void DeserializarRepuestos(string jsonText)
        {
            List<Repuestos>? repuestos = null;
            try
            {
                repuestos = JsonSerializer.Deserialize<List<Repuestos>>(jsonText);
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            if (repuestos is null)
            {
                PopError("No se pudo deserializar el archivo JSON");
                return;
            }

            foreach (var repuesto in repuestos)
            {
                //Data_Service _DataService = new Data_Service();
                try
                {
                   _DataService.IngresarRepuesto(repuesto);
                }
                catch (Exception ex)
                {
                    PopError(ex.Message);
                }
            }
            PopSucess("Repuestos cargados exitosamente");
                    // _DataService.ListadoRepuestos.Print();
                }
            }
        }


