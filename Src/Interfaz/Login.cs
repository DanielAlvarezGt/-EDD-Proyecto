using Gtk;
using EDD_Proyecto2.Src.Autentificacion;
using EDD_Proyecto2.Src.Servicios;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System;


namespace EDD_Proyecto2.Src.Interfaz
{
    public partial class Login : My_Window 
    {
        private Entry entryUserName;
        private readonly Data_Service _DataService;
        private Entry entryPassword;

         private string userConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.config/userConfig.txt";


     public Login(Data_Service dataService) : base("Login | AutoGest Pro")
        {
           
            _DataService = dataService;
            SetDefaultSize(400, 300);
            SetPosition(WindowPosition.Center);
            DeleteEvent += (_, _) => Application.Quit();

            // Aplicando estilos
           
            var grid = new Grid
            {
                ColumnSpacing = 8,
                RowSpacing = 8
            };

            var vbox = new Box(Orientation.Vertical, 0)
            {
                Halign = Align.Center,
                Valign = Align.Center
            };

            var lblUserName = new Label("Username");
            entryUserName = new Entry();

                 if (File.Exists(userConfigPath))
    {
        entryUserName.Text = File.ReadAllText(userConfigPath);
    }

            var lblPassword = new Label("Password");
            entryPassword = new Entry { Visibility = false };
            entryPassword.KeyReleaseEvent += OnKeyRelease;

            var btnLogin = new Button("Login");
            btnLogin.Clicked += OnLoginClicked;

            btnLogin.StyleContext.AddClass("button_style");

            grid.Attach(lblUserName, 0, 0, 1, 1);
            grid.Attach(entryUserName, 1, 0, 1, 1);
            grid.Attach(lblPassword, 0, 1, 1, 1);
            grid.Attach(entryPassword, 1, 1, 1, 1);
            grid.Attach(btnLogin, 0, 2, 2, 1);
            vbox.Add(grid);
            Add(vbox);

            ShowAll();
        }

        private void OnKeyRelease(object sender, KeyReleaseEventArgs args)
        {
            if (args.Event.Key == Gdk.Key.Return || args.Event.Key == Gdk.Key.KP_Enter)
            {
                OnLoginClicked(sender, EventArgs.Empty);
            }
        }

        private void OnLoginClicked(object? sender, EventArgs e)
        {
            string username = entryUserName.Text;
            string password = entryPassword.Text;

            if (Log_In.Login(username, password))
            {
                PopSucess($"Bienvenido {username}");
                Hide();
                
                var mainWindow = new Main_Window(_DataService);
                mainWindow.ShowAll();

            }
            else
            {
                PopError("Usuario o contraseña incorrectos");
            }
        }
       
}
        }

