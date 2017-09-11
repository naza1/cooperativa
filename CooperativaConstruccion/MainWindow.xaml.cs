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

        private void ProjectsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            var cadena = readFile.GetProjects();

            if (cadena.Count != 0)
            {
                foreach (var item in cadena)
                {
                    grillaProyectos.Items.Add(new { item.Name, item.StartBudget, item.StartDate, item.EndDate, item.Status, item.CurrentBudget });
                }
            }
        }

        private void Button_OpenFormNewProject(object sender, RoutedEventArgs e)
        {
            new NewProject().ShowDialog();
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
