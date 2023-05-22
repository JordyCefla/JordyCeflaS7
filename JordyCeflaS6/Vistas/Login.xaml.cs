using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using System.IO;

namespace JordyCeflaS6.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        public Login()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();

        }

        public static IEnumerable<Estudiante> Selet_Where(SQLiteConnection db,string usuario, string contrasena)
        {
            return db.Query<Estudiante>("SELECT * FROM Estudiante Where Usuario =? and  Contrasena=?",usuario,contrasena);

        }

        private void btnRegistro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Registro());
        }

        private void btnInicio_Clicked(object sender, EventArgs e)
        {
            try
            {

                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                db.CreateTable<Estudiante>();
                IEnumerable<Estudiante> resultado = Selet_Where(db,txtUsuario.Text,txtContrasena.Text);
                if (resultado.Count() > 0) 
                
                {
                    Navigation.PushAsync(new ConsultaRegistros());
                }else
                {
                    DisplayAlert("Alerta", "Usuario/Contraseña Incorrectos", "Cerrar");

                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}