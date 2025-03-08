using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class CancelarWindow : Gtk.Window
{
    public CancelarWindow() : base("Cancelar Servicio")
    {
        SetDefaultSize(500, 500);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblCancelar = new Label("Cancelar Servicio");

        vbox.PackStart(lblCancelar, true, true, 5);

        Add(vbox);
        ShowAll();
    }
}