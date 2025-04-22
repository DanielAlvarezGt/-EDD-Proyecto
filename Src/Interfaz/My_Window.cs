using Gtk;


namespace EDD_Proyecto2.Src.Interfaz;

   public abstract class My_Window : Window
    {
        private readonly Window? _contextParent;
        public My_Window(string title, Window? contextParent = null) : base(title) { _contextParent = contextParent; }
      
        public void OnDeleteEvent()
        {
            _contextParent?.ShowAll();
            Destroy();
        }

        public void PopError(string txtError)
        {
            var dialogError = new MessageDialog(this, DialogFlags.Modal, MessageType.Error, ButtonsType.Ok, $"{txtError}");
            dialogError.Run();
            dialogError.Destroy();
        }

        public void PopSucess(string txtSuccess)
        {
            var dialogSuccess = new MessageDialog(this, DialogFlags.Modal, MessageType.Info, ButtonsType.Ok, $"{txtSuccess}");
            dialogSuccess.Run();
            dialogSuccess.Destroy();
        }
        
    }
