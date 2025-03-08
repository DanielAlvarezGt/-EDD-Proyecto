using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class IngresoRepuestoWindow : Gtk.Window
{
    private ListaCircular<Repuestos> listaRepuestos;

    public IngresoRepuestoWindow(ListaCircular<Repuestos> listaRepuestos) : base("Ingreso de Repuesto")
    {
        this.listaRepuestos = listaRepuestos;

        SetDefaultSize(500, 250);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblIngresoRepuesto = new Label("Ingreso de Repuesto");

        // Crear los campos de texto
        Entry entryID = new Entry() { PlaceholderText = "ID" };
        Entry entryRepuesto = new Entry() { PlaceholderText = "Repuesto" };
        Entry entryDetalles = new Entry() { PlaceholderText = "Detalles" };
        Entry entryCosto = new Entry() { PlaceholderText = "Costo" };

        // Crear el botón de guardar
        Button btnGuardar = new Button("Guardar");

        // Agregar los widgets al VBox
        vbox.PackStart(lblIngresoRepuesto, false, true, 5);
        vbox.PackStart(entryID, false, true, 5);
        vbox.PackStart(entryRepuesto, false, true, 5);
        vbox.PackStart(entryDetalles, false, true, 5);
        vbox.PackStart(entryCosto, false, true, 5);
        vbox.PackStart(btnGuardar, false, true, 5);

        btnGuardar.Clicked += (sender, e) => OnGuardarClicked(entryID, entryRepuesto, entryDetalles, entryCosto);

        Add(vbox);
        ShowAll();
    }

    private void OnGuardarClicked(Entry entryID, Entry entryRepuesto, Entry entryDetalles, Entry entryCosto)
    {
        // Crear un nuevo repuesto con los datos ingresados
        Repuestos nuevoRepuesto = new Repuestos
        {
            Id = int.Parse(entryID.Text),
            Repuesto = entryRepuesto.Text,
            Detalles = entryDetalles.Text,
            Costo = int.Parse(entryCosto.Text)
        };

        // Agregar el nuevo repuesto a la lista
        listaRepuestos.Agregar(nuevoRepuesto);

        // Imprimir la lista de repuestos para verificar
        listaRepuestos.Imprimir();
    }
}