using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class IngresoUsuarioWindow : Gtk.Window
{
    private ListaEnlazada<Usuario> listaUsuarios;

    public IngresoUsuarioWindow(ListaEnlazada<Usuario> listaUsuarios) : base("Ingreso de Usuario")
    {
        this.listaUsuarios = listaUsuarios;

        SetDefaultSize(500, 250);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblIngresoUsuario = new Label("Ingreso de Usuario");

        // Crear los campos de texto
        Entry entryID = new Entry() { PlaceholderText = "ID" };
        Entry entryNombres = new Entry() { PlaceholderText = "Nombres" };
        Entry entryApellidos = new Entry() { PlaceholderText = "Apellidos" };
        Entry entryCorreo = new Entry() { PlaceholderText = "Correo" };
        Entry entryContrasena = new Entry() { PlaceholderText = "Contraseña", Visibility = false };

        // Crear el botón de guardar
        Button btnGuardar = new Button("Guardar");

        // Agregar los widgets al VBox
        vbox.PackStart(lblIngresoUsuario, false, true, 5);
        vbox.PackStart(entryID, false, true, 5);
        vbox.PackStart(entryNombres, false, true, 5);
        vbox.PackStart(entryApellidos, false, true, 5);
        vbox.PackStart(entryCorreo, false, true, 5);
        vbox.PackStart(entryContrasena, false, true, 5);
        vbox.PackStart(btnGuardar, false, true, 5);

        btnGuardar.Clicked += (sender, e) => OnGuardarClicked(entryID, entryNombres, entryApellidos, entryCorreo, entryContrasena);

        Add(vbox);
        ShowAll();
    }

    private void OnGuardarClicked(Entry entryID, Entry entryNombres, Entry entryApellidos, Entry entryCorreo, Entry entryContrasena)
    {
        // Crear un nuevo usuario con los datos ingresados
        Usuario nuevoUsuario = new Usuario
        {
            Id = int.Parse(entryID.Text),
            Nombres = entryNombres.Text,
            Apellidos = entryApellidos.Text,
            Correo = entryCorreo.Text,
            Contraseña = entryContrasena.Text
        };

        // Agregar el nuevo usuario a la lista
        listaUsuarios.Agregar(nuevoUsuario);

        // Imprimir la lista de usuarios para verificar
        listaUsuarios.Imprimir();
    }
}