using Cooperativa.FileSystem;
using System;
using System.Windows;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataAccessObject db;
        private int _projectId = 0;

        public MainWindow()
        {
            InitializeComponent();

            db = new DataAccessObject();

        }

        public void ProjectsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            grillaProyectos.Items.Clear();

            var cadena = db.GetProjects();

            if (cadena.Count != 0)
            {
                foreach (var item in cadena)
                {
                    grillaProyectos.Items.Add(new {item.Id, item.Name, item.StartBudget, item.CurrentBudget, item.StartDate, item.EndDate, item.Status});
                }
            }
        }

        private void grillaProyectos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = grillaProyectos.SelectedItem;

            if (item == null)
            {
                return;
            }
            button_EditProject.Visibility = Visibility.Visible;
            button_DeleteProject.Visibility = Visibility.Visible;
            _projectId = int.Parse(item.GetType().GetProperty("Id").GetValue(item, null).ToString());
        }

        private void Button_OpenFormNewProject(object sender, RoutedEventArgs e)
        {
            new NewProject(this).ShowDialog();
        }

        private void button_EditProject_Click(object sender, RoutedEventArgs e)
        {
            new EditProject(this, _projectId).ShowDialog();
        }

        private void button_DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var result = MessageBox.Show("Seguro elimina el proyecto " + _projectId + "?", "Atención!", MessageBoxButton.YesNo);

                if (result == MessageBoxResult.Yes)
                {
                    db.DeleteProject(_projectId);

                    ProjectsGrid_Loaded(sender, e);

                    MessageBox.Show("Proyecto eliminado correctamente!", "Atención!", MessageBoxButton.OK);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo eliminar el proyecto " + ex, "Error!", MessageBoxButton.OK);
            }

            button_EditProject.Visibility = Visibility.Hidden;

            button_DeleteProject.Visibility = Visibility.Hidden;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
