using Cooperativa.FileSystem;
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
                    grillaProyectos.Items.Add(new {item.Id, item.Name, item.StartBudget, item.StartDate, item.EndDate, item.Status, item.CurrentBudget });
                }
            }
        }

        private void Button_OpenFormNewProject(object sender, RoutedEventArgs e)
        {
            new NewProject(this).ShowDialog();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void grillaProyectos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = grillaProyectos.SelectedItem;

            button_EditProject.Visibility = Visibility.Visible;

            _projectId = int.Parse(item.GetType().GetProperty("Id").GetValue(item, null).ToString());
        }

        private void button_EditProject_Click(object sender, RoutedEventArgs e)
        {
            new EditProject(this, _projectId).ShowDialog();
        }
    }
}
