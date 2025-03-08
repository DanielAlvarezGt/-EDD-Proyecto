using Gtk;
using System;
using System.IO;

public class LoginWindow : Window
{
    private Entry usernameEntry;
    private Entry passwordEntry;

    private string userConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.config/userConfig.txt";


    public LoginWindow() : base("Login")
    {
        VBox vbox = new VBox(false, 5);
        Add(vbox);

        Label usernameLabel = new Label("Username:");
        usernameEntry = new Entry();
        vbox.PackStart(usernameLabel, false, false, 0);
        vbox.PackStart(usernameEntry, false, false, 0);

         if (File.Exists(userConfigPath))
    {
        usernameEntry.Text = File.ReadAllText(userConfigPath);
    }

        Label passwordLabel = new Label("Password:");
        passwordEntry = new Entry();
        passwordEntry.Visibility = false; // Oculta la contraseña
        vbox.PackStart(passwordLabel, false, false, 0);
        vbox.PackStart(passwordEntry, false, false, 0);

        Button loginButton = new Button("Login");
        loginButton.Clicked += OnLoginButtonClicked;
        vbox.PackStart(loginButton, false, false, 0);

        ShowAll();
    }

        private void OnLoginButtonClicked(object sender, EventArgs a)
    {
        
        string username = usernameEntry.Text;
        string password = "root123";


        // Aquí irá la lógica de autenticación
        if (username == "root@gmail.com")
 
        {
                   File.WriteAllText(userConfigPath, username);
             this.Destroy(); // Cierra la ventana de inicio de sesión
            //ejecutar comando de validacion de password.
            //Validar password.
            Console.WriteLine("Login attempted with username: " + username);

            //ventana

  //************************
            
            this.Hide();
            MyWindow w = new MyWindow();
            //Muestra la ventana
                        w.Show();

            //Permite a la interfaz responder a la interacion del usuariio
        }

        else
        {
            Console.WriteLine("usuario incorrecto");
        }
    }
}
    
