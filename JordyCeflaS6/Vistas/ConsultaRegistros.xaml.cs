using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JordyCeflaS6.Vistas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ConsultaRegistros : ContentPage
    {
        private SQLiteAsyncConnection conexion;
        private ObservableCollection<Estudiante> tablaEstudiante;
        public ConsultaRegistros()
        {
            InitializeComponent();
            conexion = DependencyService.Get<DataBase>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            ObtenerEstudiante();

        }
        public async void ObtenerEstudiante()
        {
            var resultadoEstudiante = await conexion.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(resultadoEstudiante);
            ListaEstudiante.ItemsSource = tablaEstudiante;

        }

        private void ListaEstudiante_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (Estudiante)e.SelectedItem;
            var ItemId = objetoEstudiante.Id.ToString();
            int id = Convert.ToInt32(ItemId);//ID
            string nombre = objetoEstudiante.nombre.ToString();
            string usuario = objetoEstudiante.usuario.ToString();
            string contrasena = objetoEstudiante.contrasena.ToString();

            Navigation.PushAsync(new Elemento(id, nombre, usuario, contrasena));
        }

        private void btnSalir_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());

        }
    }
}