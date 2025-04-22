using System;
// using TuLibreriaDeAlmacenamientoSeguro; // Reemplaza con la librería que uses

namespace EDD_Proyecto2.Src.Autentificacion
{
    public class Log_In
    {
    
        // Este método se encarga de autenticar al usuario
        // Recibe el nombre de usuario y la contraseña como parámetros
        // Devuelve true si la autenticación es exitosa, false en caso contrario
        public static bool Login(string username, string password)
        {
                
            return username == "admin@usac.com" && password == "admin123";
          
                    
           

            //codigo para guardar el usuario en n archivo de texto
            string userConfigPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/.config/userConfig.txt";
            File.WriteAllText(userConfigPath, username);
            Console.WriteLine($"Usuario guardado en {userConfigPath}");
            return true;

           

        
        }


    }
}