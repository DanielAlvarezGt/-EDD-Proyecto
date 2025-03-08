using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class IngresoVehiculoWindow : Gtk.Window
{
    private ListaDoblementeEnlazada<Vehiculo> listaVehiculos;

    public IngresoVehiculoWindow(ListaDoblementeEnlazada<Vehiculo> listaVehiculos) : base("Ingreso de Vehículo")
    {
        this.listaVehiculos = listaVehiculos;

        SetDefaultSize(500, 250);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblIngresoVehiculo = new Label("Ingreso de Vehículo");

        // Crear los campos de texto
        Entry entryID = new Entry() { PlaceholderText = "ID" };
        Entry entryIDUsuario = new Entry() { PlaceholderText = "ID Usuario" };
        Entry entryMarca = new Entry() { PlaceholderText = "Marca" };
        Entry entryModelo = new Entry() { PlaceholderText = "Modelo" };
        Entry entryPlaca = new Entry() { PlaceholderText = "Placa" };

        // Crear el botón de guardar
        Button btnGuardar = new Button("Guardar");

        // Agregar los widgets al VBox
        vbox.PackStart(lblIngresoVehiculo, false, true, 5);
        vbox.PackStart(entryID, false, true, 5);
        vbox.PackStart(entryIDUsuario, false, true, 5);
        vbox.PackStart(entryMarca, false, true, 5);
        vbox.PackStart(entryModelo, false, true, 5);
        vbox.PackStart(entryPlaca, false, true, 5);
        vbox.PackStart(btnGuardar, false, true, 5);

        btnGuardar.Clicked += (sender, e) => OnGuardarClicked(entryID, entryIDUsuario, entryMarca, entryModelo, entryPlaca);

        Add(vbox);
        ShowAll();
    }

    private void OnGuardarClicked(Entry entryID, Entry entryIDUsuario, Entry entryMarca, Entry entryModelo, Entry entryPlaca)
    {
        // Crear un nuevo vehículo con los datos ingresados
        Vehiculo nuevoVehiculo = new Vehiculo
        {
            Id = int.Parse(entryID.Text),
            Id_Usuario = int.Parse(entryIDUsuario.Text),
            Marca = entryMarca.Text,
            Modelo = entryModelo.Text,
            Placa = entryPlaca.Text
        };

        // Agregar el nuevo vehículo a la lista
        listaVehiculos.AgregarAlFinal(nuevoVehiculo);

        // Imprimir la lista de vehículos para verificar
        listaVehiculos.ImprimirDesdeCabeza();
    }
}