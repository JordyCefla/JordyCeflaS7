using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JordyCeflaS6.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSeleccionado;
        private SQLiteAsyncConnection conexion;
        IEnumerable<Estudiante> rActualizar;
        IEnumerable<Estudiante> rEliminar;
        public Elemento(int id, string nombre, string usuario, string contrasena)
        {
            InitializeComponent();
            txtID.Text = id.ToString();
            txtUsuario.Text = usuario;
            txtNombre.Text = nombre;
            txtContrasena.Text = contrasena;

            conexion = DependencyService.Get<DataBase>().GetConnection();
            idSeleccionado = id;
        }
        public static IEnumerable<Estudiante> Eliminar(SQLiteConnection db, int id )
        {
            return db.Query<Estudiante>("DELETE FROM Estudiante where Id = ?", id);
                

        }

        public static IEnumerable<Estudiante> Actualizar(SQLiteConnection db, string nombre, string usuario, string contrasena, int id)
        {
            return db.Query<Estudiante>("UPDATE Estudiante set nombre=?,usuario=?,contrasena=? where Id=?",nombre,usuario,contrasena, id);


        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try 
            {

                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rActualizar = Actualizar(db,txtNombre.Text,txtUsuario.Text,txtContrasena.Text,idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());
            
            }catch (Exception ex) 
            {
                DisplayAlert("Alerta", ex.Message, "Cerrar");
            }
        }

        private void brntEmilimar_Clicked(object sender, EventArgs e)
        {
            try 
            {
                var ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
                var db = new SQLiteConnection(ruta);
                rEliminar = Eliminar(db, idSeleccionado);
                Navigation.PushAsync(new ConsultaRegistros());  

            }
            catch (Exception ex) 
            
            {
                DisplayAlert("Alerta",ex.Message, "Cerar");
            
            }
        }
    }
}