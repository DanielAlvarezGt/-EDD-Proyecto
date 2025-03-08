using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class MyWindow : Gtk.Window
{
    private Label lblMenu;
    private Button btnCargaM;
    private Button btnIngresoI;
    private Button btnGestionS;
    private Button btnGenerarS;
    private Button btnCancelarF;

    private ListaEnlazada<Usuario> listaUsuarios;
    private ListaDoblementeEnlazada<Vehiculo> listaVehiculos;
    private ListaCircular<Repuestos> listaRepuestos;

    [Obsolete]
    public MyWindow() : base("AutoGest Pro")
    {
        SetDefaultSize(500, 500);
        SetPosition(WindowPosition.Center);

        listaUsuarios = new ListaEnlazada<Usuario>();
        listaVehiculos = new ListaDoblementeEnlazada<Vehiculo>();
        listaRepuestos = new ListaCircular<Repuestos>();

        VBox vbox = new VBox(false, 5);

        lblMenu = new Label("Menú AutoGest Pro");

        btnCargaM = new Button("Carga Masiva");
        btnCargaM.Clicked += onCargaMasivaClicked;

        btnIngresoI = new Button("Ingreso Individual");
        btnIngresoI.Clicked += onIngresoClicked;

        btnGestionS = new Button("Gestión de usuarios");
        btnGestionS.Clicked += onGestionClicked;

        btnGenerarS = new Button("Generar Servicio");
        btnGenerarS.Clicked += onGenerarClicked;

        btnCancelarF = new Button("Cancelar Factura");
        btnCancelarF.Clicked += onCancelarClicked;

        vbox.PackStart(lblMenu, true, true, 5);
        vbox.PackStart(btnCargaM, true, true, 5);
        vbox.PackStart(btnIngresoI, true, true, 5);
        vbox.PackStart(btnGestionS, true, true, 5);
        vbox.PackStart(btnGenerarS, true, true, 5);
        vbox.PackStart(btnCancelarF, true, true, 5);

        Add(vbox);
        ShowAll();
    }

    private void onCargaMasivaClicked(object sender, EventArgs e) 
    {
        CargaMasivaWindow cargaMasivaWindow = new CargaMasivaWindow(listaUsuarios, listaVehiculos, listaRepuestos);
        cargaMasivaWindow.Show();
    }

    private void onIngresoClicked(object sender, EventArgs e) 
    {
        IngresoIndividualWindow ingresoIndividualWindow = new IngresoIndividualWindow(listaUsuarios, listaVehiculos, listaRepuestos);
        ingresoIndividualWindow.Show();
    }

    private void onGestionClicked(object sender, EventArgs e) 
    {
        GestionWindow gestionWindow = new GestionWindow(listaUsuarios);
        gestionWindow.Show();
    }

    private void onGenerarClicked(object sender, EventArgs e) 
    {
        GenerarWindow generarWindow = new GenerarWindow();
        generarWindow.Show();
    }

    private void onCancelarClicked(object sender, EventArgs e) 
    {
        CancelarWindow cancelarWindow = new CancelarWindow();
        cancelarWindow.Show();
    }

    protected override bool OnDeleteEvent(Event e)
    {
        Application.Quit();
        return true;
    }

    class Program
    {
        static void Main()
        {
            Application.Init();
             LoginWindow wind = new LoginWindow();
            wind.DeleteEvent += delegate { Application.Quit(); };    

            //oculta ventana
            MyWindow win = new MyWindow();
           
           
            win.Hide();
             Application.Run();
        
            
        }
    }
}