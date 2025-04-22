using EDD_Proyecto2.Src.Interfaz;
using EDD_Proyecto2.Src.Servicios;
using EDD_Proyecto2.Src.Modelos;
using Gtk;
using System;
using EDD_Proyecto2Src.Interfaz;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Main_Window : My_Window
    {
        
 private readonly Data_Service _DataService;

        public Main_Window(Data_Service dataService) : base("Menu Principal | AutoGest Pro")
        {
            
             _DataService = dataService;    
            SetDefaultSize(450, 400);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => Application.Quit();

       
            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };


            // Creando botones
            var btnCargaMasiva = new Button("Carga Masiva");
            btnCargaMasiva.Clicked += OnCargaMasivaClicked;
           
            var btnIngresoIndividual = new Button("Ingreso Individual");
           btnIngresoIndividual.Clicked += OnIngresoIndividualClicked;

           var btnGestionDeUsuarios = new Button("Gestión de Usuarios");
            btnGestionDeUsuarios.Clicked += OnGestionDeUsuariosClicked;

            var btn_visualizar_repuestos = new Button("Visualizar Repuestos");
            btn_visualizar_repuestos.Clicked += OnVisualizarRepuestosClicked;
 
            var btn_actualizar_repuestos = new Button("Actualizar Repuestos");
            btn_actualizar_repuestos.Clicked += OnActualizarRepuestosClicked;

           var btn_Generar_Servivio = new Button("Generar Servicio");
            btn_Generar_Servivio.Clicked += OnGenerarServicioClicked;
            
             var btnControlLogueo = new Button("Control de Logueo");
             btnControlLogueo.Clicked += OnControlLogueoClicked;

            //var btnAgregarFactura = new Button("Agregar factura");
            //btnAgregarFactura.Clicked += OnAgregarFacturaClicked;

            

            var btnGenerarReportes = new Button("Generar Reportes");
            //btnGenerarReportes.Clicked += OnGenerarReportesClicked;*/

            // Agregando botones al vbox
            vbox.PackStart(btnCargaMasiva, false, false, 6);
            vbox.PackStart(btnIngresoIndividual, false, false, 6);
            vbox.PackStart(btnGestionDeUsuarios, false, false, 6);
            vbox.PackStart(btn_actualizar_repuestos, false, false, 6);
            vbox.PackStart(btn_visualizar_repuestos, false, false, 6);
            vbox.PackStart(btn_Generar_Servivio, false, false, 6);
            vbox.PackStart(btnControlLogueo, false, false, 6);
            vbox.PackStart(btnGenerarReportes, false, false, 6);
            //vbox.PackStart(btnCancelarFactura, false, false, 6);
            // Aplicando estilos a los botones
         

            Add(vbox);
            ShowAll();
        }

        private void OnCargaMasivaClicked(object? sender, EventArgs e)
        {
            var cargaMasiva = new Carga_Masiva(this, _DataService);
            cargaMasiva.ShowAll();

         
            Hide();
        }


        private void OnIngresoIndividualClicked(object? sender, EventArgs e)
        {
            var MenuIngresoManual = new Menu_Ingreso_Manual(this, _DataService);
            MenuIngresoManual.ShowAll();
            Hide();
        }

        private void OnGestionDeUsuariosClicked(object? sender, EventArgs e)
        {
            var GestionUsuarios = new Gestion_Usuarios(this, _DataService);
            GestionUsuarios.ShowAll();
            Hide();
        }

            private void OnActualizarRepuestosClicked(object? sender, EventArgs e)
        {
            var ActualizarRepuestos = new Actualizar_Repuestos(this, _DataService);
            ActualizarRepuestos.ShowAll();
            Hide();
        }

    private void OnVisualizarRepuestosClicked(object? sender, EventArgs e)
        {
            var VisualizarRepuestos = new Visualizar_Repuestos(this, _DataService);
            VisualizarRepuestos.ShowAll();
            Hide();
        }

        private void OnGenerarServicioClicked(object? sender, EventArgs e)
        {
            var GenerarServicio = new Generar_Servicio(this, _DataService);
            GenerarServicio.ShowAll();
            Hide();
        }

          private void OnControlLogueoClicked(object? sender, EventArgs e)
        {
            var InterfazUsuario = new Interfaz_Usuario(this, _DataService);
            InterfazUsuario.ShowAll();
            Hide();
        }
/*
        private void OnGenerarReportesClicked(object? sender, EventArgs e)
        {
            try
            {
                _DataService.GenerarReporteListadoUsuarios();
                PopSucess("Reporte de usuarios generado correctamente");
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            try
            {
                _DataService.GenerarReporteListadoVehiculos();
                PopSucess("Reporte de vehículos generado correctamente");
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            try
            {
                _DataService.GenerarReporteListadoRepuestos();
                PopSucess("Reporte de repuestos generado correctamente");
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            try
            {
                _DataService.GenerarReporteListadoServicios();
                PopSucess("Reporte de servicios generado correctamente");
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            try
            {
                _DataService.GenerarReporteListadoFacturas();
                PopSucess("Reporte de facturas generado correctamente");
            }
            catch (Exception ex)
            {
                PopError(ex.Message);
            }
            
        }*/
    
    }
}