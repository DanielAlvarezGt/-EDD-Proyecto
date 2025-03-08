using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class GenerarWindow : Gtk.Window
{
    public GenerarWindow() : base("Generar Servicio")
    {
        SetDefaultSize(500, 200);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblGenerar = new Label("Generar Servicio");

        // Crear los campos de texto
        Entry entryID = new Entry() { PlaceholderText = "ID" };
        Entry entryIDRepuesto = new Entry() { PlaceholderText = "ID Repuesto" };
        Entry entryIDVehiculo = new Entry() { PlaceholderText = "ID Vehiculo" };
        Entry entryDetalles = new Entry() { PlaceholderText = "Detalles" };
        Entry entryCosto = new Entry() { PlaceholderText = "Costo" };

        // Crear el botón de guardar
        Button btnGuardar = new Button("Guardar");

        // Agregar los widgets al VBox
        vbox.PackStart(lblGenerar, false, true, 5);
        vbox.PackStart(entryID, false, true, 5);
        vbox.PackStart(entryIDRepuesto, false, true, 5);
        vbox.PackStart(entryIDVehiculo, false, true, 5);
        vbox.PackStart(entryDetalles, false, true, 5);
        vbox.PackStart(entryCosto, false, true, 5);
        vbox.PackStart(btnGuardar, false, true, 5);

        Add(vbox);
        ShowAll();
    }
}