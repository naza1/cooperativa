using Cooperativa.FileSystem;
using FileSystem.Tables;
using System.Data;
using System.Windows;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WriteFile writeFile;
        public MainWindow()
        {
            InitializeComponent();
            writeFile = new WriteFile();
        }

        private void Button_CreateProject(object sender, RoutedEventArgs e)
        {
            
            var project = new Project();

            project.Name = textBox_ProjectName.Text;            

            writeFile.SaveProject(project);
        }
    }
}
