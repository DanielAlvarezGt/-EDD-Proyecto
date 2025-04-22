using EDD_Proyecto2.Src.Modelos;
using EDD_Proyecto2.Src.Servicios;
using EDD_Proyecto2.Src.Interfaz;
using EDD_Proyecto2.Src.Estructuras;
using System.Text.Json;
using Gtk;

namespace EDD_Proyecto2.Src.Interfaz
{
    public class Ordenar_Servicios : My_Window
    {
        //public Arbol_Avl Arbol_Avl_Repuestos { get; } = new Arbol_Avl ();
        private readonly Data_Service _DataService;
       // private Arbol_Avl arbolAvl;
          private Arbol_Binario arbolBinario = new Arbol_Binario();

        
        private TextView _txtvRepuestos;
         private ComboBoxText _comboBox;

        
        public Ordenar_Servicios(Window contextParent, Data_Service dataService, Arbol_Binario? arbol = null) : base("Gestion de Usuarios | AutoGest Pro", contextParent)
        {
            // Inyección de dependencias
            _DataService = dataService;


              // Inicializar el árbol AVL (usar el proporcionado o crear uno nuevo)
    arbolBinario = arbol ?? new Arbol_Binario();

            SetSizeRequest(900, 500);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => OnDeleteEvent();
            

            //AplicarEstilos();

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


            _txtvRepuestos = new TextView() { Editable = false, WrapMode = WrapMode.None };
            _txtvRepuestos.Buffer.Text = "Hello World!\nServicios del Usuario";

    
        // Cambiar el tamaño de la fuente
    var fontDescription = Pango.FontDescription.FromString("Monospace 7"); // Tamaño de fuente más pequeño
    _txtvRepuestos.ModifyFont(fontDescription);

    // Crear un ScrolledWindow para envolver el TextView
    var scrolledWindow = new ScrolledWindow
    {
        ShadowType = ShadowType.In,
        VscrollbarPolicy = PolicyType.Automatic,
        HscrollbarPolicy = PolicyType.Automatic
    };


    // Agregar el TextView al ScrolledWindow
    scrolledWindow.Add(_txtvRepuestos);

    // Ajustar el tamaño del ScrolledWindow
    scrolledWindow.SetSizeRequest(700, 300);

            _txtvRepuestos.SetSizeRequest(700, 300);
            _txtvRepuestos.VscrollPolicy = ScrollablePolicy.Natural;

            hbox.PackStart(vbox, true, true, 0);
            hbox.PackStart(scrolledWindow, true, true, 0);


            _comboBox = new ComboBoxText();

            _comboBox.AppendText("PreOrden");
            _comboBox.AppendText("InOrden");
            _comboBox.AppendText("PostOrden");
                     
            _comboBox.Active = 0;
            vbox.PackStart(_comboBox, false, false, 30);

            var btnCargar = new Button("Cargar");
          btnCargar.Clicked += OnCargarClicked;
         
            vbox.PackStart(_comboBox, false, false, 30);
            vbox.PackStart(btnCargar, false, false, 30);

            Add(hbox);
            ShowAll();
        }

        private void OnCargarClicked(object? sender, System.EventArgs e)
        {
  _txtvRepuestos.Buffer.Text = "";
          
            

            //si la opcion es inOrden que llame al metodo inOrden combobox
            if (_comboBox.ActiveText == "PreOrden")
            {
                // Mostrar los repuestos en orden
                var servicios = _DataService.Arbol_Binario_Servicios.preOrden();
                _txtvRepuestos.Buffer.Text = servicios;
            }    
            else if (_comboBox.ActiveText == "InOrden")
            {
                // Mostrar los repuestos en orden
                var servicios = _DataService.Arbol_Binario_Servicios.inOrden();
                _txtvRepuestos.Buffer.Text = servicios;
            }
            else if (_comboBox.ActiveText == "PostOrden")
            {
                // Mostrar los repuestos en orden
                var servicios = _DataService.Arbol_Binario_Servicios.postOrden();
                _txtvRepuestos.Buffer.Text = servicios;
            }
        
        }


    }
}
