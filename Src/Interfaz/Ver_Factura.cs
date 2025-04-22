
using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;
using EDD_Proyecto2.Src.Interfaz;
using System.Text.Json;
using Gtk;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Ver_Factura : My_Window
    {
        private readonly Data_Service _DataService;
        private Entry _txtId;
        private Entry _txtTotal;
        
        public Ver_Factura(Window contextParent, Data_Service dataService) : base("Gestion de Usuarios | AutoGest Pro", contextParent)
        {
            // Inyección de dependencias
            _DataService = dataService;

            SetSizeRequest(900, 500);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => OnDeleteEvent();

         
            var hbox = new Box(Orientation.Horizontal, 20)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            var grid = new Grid() { ColumnSpacing = 8, RowSpacing = 8 };

            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Start,
                Valign = Align.Center
            };

            var lblId = new Label("ID") { Halign = Align.Start };
            var lblTotal = new Label("Total") { Halign = Align.Start };
            

            _txtId = new Entry() { PlaceholderText = "ID" };
            _txtTotal = new Entry() { PlaceholderText = "Total", Sensitive = false };
          
            var btnIngresar = new Button("Ingresar");
            //btnIngresar.Clicked += OnIngresarClicked;
            
            var btnBuscar = new Button("Buscar");
            //btnBuscar.Clicked += OnBuscarClicked;

            

            grid.Attach(lblId, 0, 0, 1, 1);
            grid.Attach(_txtId, 1, 0, 1, 1);
            grid.Attach(lblTotal, 0, 0, 1, 1);
            grid.Attach(_txtTotal, 1, 0, 1, 1);
            grid.Attach(btnIngresar, 2, 0, 1, 1);
            grid.Attach(btnBuscar, 1, 4, 1, 1);
        

            vbox.Add(grid);
    

            hbox.PackStart(vbox, true, true, 0);
        

            Add(hbox);

            ShowAll();
        }
}
}