using ClassLibrary1.Reader;
using Cooperativa.FileSystem;
using FileSystem.Tables;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ReadFile readFile;
        public MainWindow()
        {
            InitializeComponent();

            readFile = new ReadFile();

        }

        private void GrillaProyectos_Loaded(object sender, RoutedEventArgs e)
        {
            var cadena = readFile.ReadProject();

            if (cadena != string.Empty)
            {
                var projects = JsonConvert.DeserializeObject<List<Project>>(cadena);

                foreach (var item in projects)
                {
                    grillaProyectos.Items.Add(new { item.Name, item.StartBudget, item.StartDate, item.EndDate, item.Status, item.CurrentBudget });
                }
            }
        }

        private void button_OpenFormNewProject_Click(object sender, RoutedEventArgs e)
        {
            NewProject newProject = new NewProject();
            newProject.Show();
        }
    }
}
