using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

class CargaMasivaWindow : Gtk.Window
{
    public ListaEnlazada<Usuario> listaUsuarios;
    public ListaDoblementeEnlazada<Vehiculo> listaVehiculos;
    public ListaCircular<Repuestos> listaRepuestos;

    public CargaMasivaWindow(ListaEnlazada<Usuario> listaUsuarios, ListaDoblementeEnlazada<Vehiculo> listaVehiculos, ListaCircular<Repuestos> listaRepuestos) : base("Carga Masiva")
    {
        this.listaUsuarios = listaUsuarios;
        this.listaVehiculos = listaVehiculos;
        this.listaRepuestos = listaRepuestos;

        SetDefaultSize(500, 100);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 10);

        Label lblCargaMasiva = new Label("Carga Masiva");
        ComboBoxText comboBoxCarga = new ComboBoxText();
        comboBoxCarga.AppendText("Usuarios");
        comboBoxCarga.AppendText("Vehiculos");
        comboBoxCarga.AppendText("Repuestos");
        Button btnSubirJson = new Button("Subir JSON");
        Button btnIngresoIndividual = new Button("Ingreso Individual");

        vbox.PackStart(lblCargaMasiva, false, true, 5);
        vbox.PackStart(comboBoxCarga, false, false, 5);
        vbox.PackStart(btnSubirJson, false, true, 20);
        //vbox.PackStart(btnIngresoIndividual, false, true, 20);

        btnSubirJson.Clicked += (sender, e) => OnJsonClicked(sender, e, comboBoxCarga);
        btnIngresoIndividual.Clicked += (sender, e) => OnIngresoIndividualClicked();

        Add(vbox);
        ShowAll();
    }

    private void OnIngresoIndividualClicked()
    {
        IngresoIndividualWindow ingresoIndividualWindow = new IngresoIndividualWindow(listaUsuarios, listaVehiculos, listaRepuestos);
        ingresoIndividualWindow.Show();
    }

    public void OnJsonClicked(object sender, EventArgs e, ComboBoxText comboBoxCarga)
    {
        // Crear el dialogo para seleccionar el archivo
        FileChooserDialog fileChooser = new FileChooserDialog(
            "Seleccionar un archivo JSON", this, 
            FileChooserAction.Open,
            "Cancelar", ResponseType.Cancel, 
            "Abrir", ResponseType.Accept
        );

        // Filtro para elegir solo archivos json
        FileFilter filter = new FileFilter();
        filter.AddPattern("*.json"); 
        fileChooser.Filter = filter;

        if (fileChooser.Run() == (int)ResponseType.Accept)
        {
            string filePath = fileChooser.Filename; // Obtener la ruta del archivo
            fileChooser.Destroy();

            try 
            {
                string jsonContent = File.ReadAllText(filePath);
                //Console.WriteLine("Contenido JSON:\n" + jsonContent); 

                string tipoCarga = comboBoxCarga.ActiveText;

                if (tipoCarga == "Usuarios")
                {
                    List<Usuario> usuarios = JsonConvert.DeserializeObject<List<Usuario>>(jsonContent);
                    foreach (var usuario in usuarios)
                    {
                        listaUsuarios.Agregar(usuario);
                    }
                    listaUsuarios.Imprimir();
                }
                else if (tipoCarga == "Vehiculos")
                {
                    List<Vehiculo> vehiculos = JsonConvert.DeserializeObject<List<Vehiculo>>(jsonContent);
                    foreach (var vehiculo in vehiculos)
                    {
                        listaVehiculos.AgregarAlFinal(vehiculo);
                    }
                    listaVehiculos.ImprimirDesdeCabeza();
                }
                else if (tipoCarga == "Repuestos")
                {
                    List<Repuestos> repuestos = JsonConvert.DeserializeObject<List<Repuestos>>(jsonContent);
                    foreach (var repuesto in repuestos)
                    {
                        listaRepuestos.Agregar(repuesto);
                    }
                    listaRepuestos.Imprimir();
                }
            } 
            catch (Exception ex)
            {
                Console.WriteLine("Error al leer el archivo.");
                Console.WriteLine("Error: " + ex.Message);
            }
        } 
        else 
        {
            fileChooser.Destroy();
        }
    }
}