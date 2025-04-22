using System.Xml.Serialization;
using EDD_Proyecto2.Src.Interfaz;
using EDD_Proyecto2.Src.Servicios;
using Gtk;

namespace EDD_Proyecto2Src.Interfaz
{
    public class Menu_Ingreso_Manual : My_Window
    {
        private readonly Data_Service _DataService;
        /**
         * Init the window
         */
        public Menu_Ingreso_Manual(Window contextParent, Data_Service dataService) : base("Menu | AutoGest Pro", contextParent)
        {
            // Inyectamos dataService
            _DataService = dataService;

            SetDefaultSize(450, 350);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => OnDeleteEvent();

            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            var btnIngresoUsuario = new Button("Ingresar Nuevo Usuario");
            btnIngresoUsuario.Clicked += OnIngresoUsuario;

           var btnIngresoVehiculo = new Button("Ingresar Nuevo Vehiculo");
            btnIngresoVehiculo.Clicked += OnIngresoVehiculo;

           // var btnIngresoRepuesto = new Button("Ingresar Nuevo Repuesto");
            //btnIngresoRepuesto.Clicked += OnIngresarRepuesto;

            // var btnIngresoServicio = new Button("Ingresar Nuevo Servicio");
            // btnIngresoServicio.Clicked += OnIngresarServicio;

            vbox.PackStart(btnIngresoUsuario, false, false, 10);
            vbox.PackStart(btnIngresoVehiculo, false, false, 10);
            //vbox.PackStart(btnIngresoRepuesto, false, false, 10);
            // vbox.PackStart(btnIngresoServicio, false, false, 10);

            Add(vbox);
            ShowAll();
        }

        private void OnIngresoUsuario(object? sender, System.EventArgs e)
        {
            var ingresoUsuario = new Ingresar_Usuario(this, _DataService);
            ingresoUsuario.ShowAll();
            Hide();
        }

        private void OnIngresoVehiculo(object? sender, System.EventArgs e)
        {
            var ingresoVehiculo = new IngresoVehiculo(this, _DataService);
            ingresoVehiculo.ShowAll();
            Hide();
        }
/*
        private void OnIngresarRepuesto(object? sender, System.EventArgs e)
        {
            var ingresoRepuesto = new Ingreso_Repuesto(this, _DataService);
            ingresoRepuesto.ShowAll();
            Hide();
        }*/

        // private void OnIngresarServicio(object? sender, System.EventArgs e)
        // {
        //     var ingresoServicio = new IngresoServicio(this);
        //     ingresoServicio.ShowAll();
        //     Hide();
        // }*/
    }
}