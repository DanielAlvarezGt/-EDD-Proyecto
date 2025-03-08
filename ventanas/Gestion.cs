using Gdk;
using Gtk;
using System;
using System.IO;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

class GestionWindow : Gtk.Window
{
    private ListaEnlazada<Usuario> listaUsuarios;
    private Entry entryID;
    private Entry entryNombres;
    private Entry entryApellidos;
    private Entry entryCorreo;
    private Usuario usuarioActual;

    public GestionWindow(ListaEnlazada<Usuario> listaUsuarios) : base("Gestión de usuarios")
    {
        this.listaUsuarios = listaUsuarios;

        SetDefaultSize(500, 200);
        SetPosition(WindowPosition.Center);

        VBox vbox = new VBox(false, 5);

        Label lblGestion = new Label("Gestión de usuarios");
        Button btnActualizar = new Button("Actualizar");

        // Crear los widgets para ID y botón de buscar
        HBox hboxID = new HBox(false, 5);
        entryID = new Entry() { PlaceholderText = "ID" };
        Button btnBuscar = new Button("Buscar");
        btnBuscar.ModifyBg(StateType.Normal, new Gdk.Color(0, 255, 0)); // Botón verde
        hboxID.PackStart(entryID, true, true, 5);
        hboxID.PackStart(btnBuscar, false, false, 5);

        // Crear los widgets para Nombres
        HBox hboxNombres = new HBox(false, 5);
        Label lblNombres = new Label("Nombres:");
        entryNombres = new Entry();
        hboxNombres.PackStart(lblNombres, false, false, 5);
        hboxNombres.PackStart(entryNombres, true, true, 5);

        // Crear los widgets para Apellidos
        HBox hboxApellidos = new HBox(false, 5);
        Label lblApellidos = new Label("Apellidos:");
        entryApellidos = new Entry();
        hboxApellidos.PackStart(lblApellidos, false, false, 5);
        hboxApellidos.PackStart(entryApellidos, true, true, 5);

        // Crear los widgets para Correo
        HBox hboxCorreo = new HBox(false, 5);
        Label lblCorreo = new Label("Correo:");
        entryCorreo = new Entry();
        hboxCorreo.PackStart(lblCorreo, false, false, 5);
        hboxCorreo.PackStart(entryCorreo, true, true, 5);

        // Agregar los widgets al VBox
        vbox.PackStart(lblGestion, false, true, 5);
        vbox.PackStart(hboxID, false, true, 5);
        vbox.PackStart(hboxNombres, false, true, 5);
        vbox.PackStart(hboxApellidos, false, true, 5);
        vbox.PackStart(hboxCorreo, false, true, 5);
        vbox.PackStart(btnActualizar, false, true, 5);

        btnBuscar.Clicked += OnBuscarClicked;
        btnActualizar.Clicked += OnActualizarClicked;

        Add(vbox);
        ShowAll();
    }

    private void OnBuscarClicked(object sender, EventArgs e)
    {
        int id;
        if (int.TryParse(entryID.Text, out id))
        {
            Nodo<Usuario> actual = listaUsuarios.cabeza;
            while (actual != null)
            {
                if (actual.Valor.Id == id)
                {
                    usuarioActual = actual.Valor;
                    entryNombres.Text = usuarioActual.Nombres;
                    entryApellidos.Text = usuarioActual.Apellidos;
                    entryCorreo.Text = usuarioActual.Correo;
                    return;
                }
                actual = actual.Siguiente;
            }
            MessageDialog dialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Usuario no encontrado");
            dialog.Run();
            dialog.Destroy();
        }
        else
        {
            MessageDialog dialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "ID inválido");
            dialog.Run();
            dialog.Destroy();
        }
    }

    private void OnActualizarClicked(object sender, EventArgs e)
    {
        if (usuarioActual != null)
        {
            usuarioActual.Nombres = entryNombres.Text;
            usuarioActual.Apellidos = entryApellidos.Text;
            usuarioActual.Correo = entryCorreo.Text;
            MessageDialog dialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Usuario actualizado");
            dialog.Run();
            dialog.Destroy();
        }
        else
        {
            MessageDialog dialog = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, "Primero busque un usuario");
            dialog.Run();
            dialog.Destroy();
        }
    }
}