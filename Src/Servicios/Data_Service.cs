using EDD_Proyecto2.Src.Estructuras;
using EDD_Proyecto2.Src.Interfaz;
using EDD_Proyecto2.Src.Modelos;


//using Fase1.src.adt; 
//using Fase1.src.models;
namespace EDD_Proyecto2.Src.Servicios
{
  public class Data_Service
    {
        // Instancia única de DataService (Singleton)
        private static Data_Service? _instance;

        // Inicialización de las estructuras de datos
        public Lista_Simple ListadoUsuarios { get; } = new Lista_Simple();
       public Lista_Doble ListadoVehiculos { get; } = new Lista_Doble ();
       public Arbol_Avl Arbol_Avl_Repuestos { get; } = new Arbol_Avl ();
       public Arbol_Binario Arbol_Binario_Servicios { get; } = new Arbol_Binario ();
       public Arbol_B ArbolB_Factura { get; } = new Arbol_B ();
    
            
        // Constructor privado para evitar la creación de instancias fuera de la clase
        public  Data_Service() { }

        // Propiedad para obtener la instancia única de DataService
        public static Data_Service Instance
        {
            get
                {
                _instance ??= new Data_Service();
                return _instance;
            }
        }

        // Métodos para ingresar datos en las estructuras de datos
        public void IngresarUsuario(Usuario usuario)
        {
            if (ListadoUsuarios.Search(usuario.ID) == 1)
        {
                var id = usuario.ID;
                throw new Exception($"El ID {id} ya existe en la lista de usuarios");
            }
            ListadoUsuarios.Agregar(usuario.ID, usuario.Nombres, usuario.Apellidos, usuario.Correo, usuario.Edad, usuario.Contrasenia);
            Console.WriteLine($"Usuario con ID {usuario.ID} agregado correctamente.");
        }


        public Usuario BuscarUsuario(int id)
        {
            Usuario? result = ListadoUsuarios.Find(id);
            
            if (result == null)
            {
                throw new Exception($"El usuario con ID {id} no existe.");
            }
            return result;
        }

        public void ActualizarUsuario(int id, string nombres, string apellidos, string correo)
        {
            if (ListadoUsuarios.Actualizar(id, nombres, apellidos, correo) == 0)
            {
                throw new Exception($"Este ID '{id}', no existe en la lista de usuarios");
            }
        }

        public void EliminarUsuario(int id)
        {
            if (ListadoUsuarios.Eliminar(id) == 0)
            {
                throw new Exception($"El usuario con ID {id} no existe.");
            }
        }
      public void IngresarVehiculo(Vehiculo vehiculo)
        {
            if (ListadoVehiculos.Search(vehiculo.ID) == 1)
            {
                var id = vehiculo.ID;
                throw new Exception($"El ID {id} ya existe en la lista de vehículos");
            }
            ListadoVehiculos.Insertar(vehiculo.ID, vehiculo.ID_Usuario, vehiculo.Marca, vehiculo.Modelo, vehiculo.Placa);
            Console.WriteLine($"Vehiculo con ID {vehiculo.ID} agregado correctamente.");
        }

        public List<Vehiculo> BuscarVehiculoPorUsuario(int idUsuario)
        {
            var vehiculos = ListadoVehiculos.SearchVehiclesByUserId(idUsuario);
            if (vehiculos == null)
            {
                throw new Exception($"El usuario con ID {idUsuario} no tiene vehículos registrados.");
            }
            return vehiculos;
        }
        
      public void IngresarRepuesto(Repuestos repuesto)
        {
            if (Arbol_Avl_Repuestos.buscar(repuesto.ID) != null)
            {
                // Si el ID ya existe, lanzar una excepción
                var id = repuesto.ID;
                throw new Exception($"El ID {id} ya existe en la lista de repuestos");
            }
                // Si el ID no existe, agregar el repuesto al árbol AVL
               
                //Arbol_Avl_Repuestos.insert(repuesto.ID);
               Arbol_Avl_Repuestos.insert(new Nodo_Repuestos(repuesto.ID, repuesto.Repuesto, repuesto.Detalles, repuesto.Costo));
                                   
             Console.WriteLine($"Repuesto con ID {repuesto.ID} agregado correctamente.");
        
        //Arbol_Avl_Repuestos.inOrden();

        }

      
        public Repuestos BuscarRepuestoPorId(int id)
        {
            var nodoRepuesto = Arbol_Avl_Repuestos.buscar(id);
            if (nodoRepuesto == null)
            {
                throw new Exception($"El repuesto con ID {id} no existe.");
            }

            // Crear un objeto Repuestos a partir del Nodo_Repuestos
            var repuesto = new Repuestos
            {
                ID = nodoRepuesto.ID,
                Repuesto = nodoRepuesto.Repuesto,
                Detalles = nodoRepuesto.Detalle,
                Costo = nodoRepuesto.Costo
            };
            Console.WriteLine($"Repuesto con ID {repuesto.ID} encontrado.");
            return repuesto;
           
        }
        

public void ActualizarRepuesto(int id, string repuestos, string detalle, double costos)
        {
        
        if (Arbol_Avl_Repuestos.actualizar(id, repuestos, detalle, costos) == null)
            {
                throw new Exception($"Este ID '{id}', no existe en la lista de usuarios");
            }
        }

       public  void IngresarServicio(Servicio servicio)
        {
            if (Arbol_Binario_Servicios.Buscar(servicio.ID) != null)
            {
                // Si el ID ya existe, lanzar una excepción
                var id = servicio.ID;
                throw new Exception($"El ID {id} ya existe en la lista de repuestos");
            }
                // Si el ID no existe, agregar el repuesto al árbol AVL
               
                //Arbol_Avl_Repuestos.insert(repuesto.ID);
               Arbol_Binario_Servicios.Agregar(new Nodo_T(servicio.ID, servicio.IdRepuesto, servicio.IdVehiculo, servicio.Detalles, servicio.Costo));
                                   
             Console.WriteLine($"Servicio con ID {servicio.ID} agregado correctamente.");
        }

        //buscar servicio


        public Servicio BuscarServicioPorId(int id)
        {
            var nodoServicio = Arbol_Binario_Servicios.Buscar(id);
            if (nodoServicio == null)
            {
                throw new Exception($"El servicio con ID {id} no existe.");
            }

            // Crear un objeto Repuestos a partir del Nodo_Repuestos
            var servicio = new Servicio
            {
                ID = nodoServicio.ID,
                IdRepuesto = nodoServicio.IdRepuesto,
                IdVehiculo = nodoServicio.IdVehiculo,
                Detalles = nodoServicio.Detalles,
                Costo = (float)nodoServicio.Costo
            };
            Console.WriteLine($"Servicio con ID {servicio.ID} encontrado.");
            return servicio;
           
        }

      /*
        public Servicios BuscarRepuestoPorId(int id)
        {
            var nodoRepuesto = Arbol_Avl_Servicios.buscar(id);
            if (nodoRepuesto == null)
            {
                throw new Exception($"El repuesto con ID {id} no existe.");
            }

            // Crear un objeto Repuestos a partir del Nodo_Repuestos
            var repuesto = new Servicios
            {
                ID = nodoRepuesto.ID,
                Repuesto = nodoRepuesto.Repuesto,
                Detalles = nodoRepuesto.Detalle,
                Costo = nodoRepuesto.Costo
            };
            Console.WriteLine($"Repuesto con ID {repuesto.ID} encontrado.");
            return repuesto;
           
        }
        
/*
public void ActualizarServicio(int id, string repuestos, string detalle, double costos)
        {
        
        if (Arbol_Avl_Servicios.actualizar(id, repuestos, detalle, costos) == null)
            {
                throw new Exception($"Este ID '{id}', no existe en la lista de usuarios");
            }
        }*/

        public void CrearFactura(Factura factura)
        {
              if (Arbol_Binario_Servicios.IsEmpty())
            {
                throw new Exception("No hay servicios en la cola para generar la factura");
            }
            ArbolB_Factura.Insertar(factura.ID, factura.IdOrden, factura.Total);
             Console.WriteLine("Factura creada correctamente"+factura.ID+" "+factura.Total);
            // PilaFactura.Print();
        }
       public  Factura?  CancelarFactura(Factura factura)
        {
            if (ArbolB_Factura.IsEmpty())
            {
                throw new Exception("No existen Facturas pendientes por cancelar");
            }

            // Verifica si la factura existe en el árbol B antes de eliminarla
    var nodoFactura = ArbolB_Factura.Buscar(factura.ID);
    if (nodoFactura == null)
    {
        throw new Exception($"La factura con ID {factura.ID} no existe.");
    }

    // Elimina la factura del árbol B
    ArbolB_Factura.Eliminar(factura.ID);

    // Devuelve la factura eliminada
    return new Factura
    {
        ID = factura.ID,
        IdOrden = factura.IdOrden,
        Total = factura.Total
    };
        }

          public  Factura?  BuscarFacturaPorId(Factura factura)
        {
        
        var nodoFactura = ArbolB_Factura.Buscar(factura.ID);
    
        if (nodoFactura == null)
        {
            throw new Exception($"La factura con ID {factura.ID} no existe.");
        }
     
//buscar factura
        
    return new Factura
    {
        ID = factura.ID,
        IdOrden = factura.IdOrden,
        Total = factura.Total
    };



            
        /*
        public void GenerarReporteListadoUsuarios()
        {
            if (!ListadoUsuarios.GenerarReporte())
            {
                throw new Exception("No hay usuarios registrados");
            }
        }

        public void GenerarReporteListadoVehiculos()
        {
            if (!ListadoVehiculos.GenerarReporte())
            {
                throw new Exception("No hay vehículos registrados");
            }
        }

        public void GenerarReporteListadoRepuestos()
        {
            if (!ListadoRepuestos.GenerarReporte())
            {
                throw new Exception("No hay repuestos registrados");
            }
        }

        public void GenerarReporteListadoServicios()
        {
            if (!ColaServicio.GenerarReporte())
            {
                throw new Exception("No hay servicios registrados");
            }
        }

        public void GenerarReporteListadoFacturas()
        {
            if (!PilaFactura.GenerarReporte())
            {
                throw new Exception("No hay facturas registradas");
            }
        }*/

        
    }

    }
}
