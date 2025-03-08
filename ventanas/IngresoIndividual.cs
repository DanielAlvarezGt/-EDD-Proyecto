using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class IngresoIndividualWindow : Gtk.Window
{
    private ListaEnlazada<Usuario> listaUsuarios;
    private ListaDoblementeEnlazada<Vehiculo> listaVehiculos;
    private ListaCircular<Repuestos> listaRepuestos;

    public IngresoIndividualWindow(ListaEnlazada<Usuario> listaUsuarios, ListaDoblementeEnlazada<Vehiculo> listaVehiculos, ListaCircular<Repuestos> listaRepuestos) : base("Ingreso Individual")
    {
        this.listaUsuarios = listaUsuarios;
        this.listaVehiculos = listaVehiculos;
        this.listaRepuestos = listaRepuestos;

        SetDefaultSize(500, 230);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblIngresoIndividual = new Label("Ingreso Individual");
        Button btnUsuario = new Button("Ingresar Usuarios");
        btnUsuario.Clicked += onUsuarioClicked;
        Button btnVehiculo = new Button("Ingresar Vehiculos");
        btnVehiculo.Clicked += onVehiculoClicked;
        Button btnRepuesto = new Button("Ingresar Repuestos");
        btnRepuesto.Clicked += onRepuestoClicked;
        Button btnServicio = new Button("Ingresar Servicios");
        btnServicio.Clicked += onServicioClicked;

        vbox.PackStart(lblIngresoIndividual, false, true, 5);
        vbox.PackStart(btnUsuario, false, false, 5);
        vbox.PackStart(btnVehiculo, false, false, 5);
        vbox.PackStart(btnRepuesto, false, false, 5);
        vbox.PackStart(btnServicio, false, false, 5);

        Add(vbox);
        ShowAll();
    }

    private void onUsuarioClicked(object sender, EventArgs e) 
    {
        IngresoUsuarioWindow ingresoUsuarioWindow = new IngresoUsuarioWindow(listaUsuarios);
        ingresoUsuarioWindow.Show();
    }

    private void onVehiculoClicked(object sender, EventArgs e) 
    {
        IngresoVehiculoWindow ingresoVehiculoWindow = new IngresoVehiculoWindow(listaVehiculos);
        ingresoVehiculoWindow.Show();
    }

    private void onRepuestoClicked(object sender, EventArgs e) 
    {
        IngresoRepuestoWindow ingresoRepuestoWindow = new IngresoRepuestoWindow(listaRepuestos);
        ingresoRepuestoWindow.Show();
    }

    private void onServicioClicked(object sender, EventArgs e) 
    {
        IngresoServicioWindow ingresoServicioWindow = new IngresoServicioWindow();
        ingresoServicioWindow.Show();
    }
}