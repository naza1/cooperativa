using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        private WriteFile writeFile;
        public NewProject()
        {
            InitializeComponent();
            writeFile = new WriteFile();
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {

            var project = new Project
            {
                Id = 1,
                Name = textBox_ProjectName.Text,
                StartBudget = decimal.Parse(textBox_ProjectStartBudjet.Text),
                Date = DateTime.Now,
                StartDate = datePicker_ProjectStartDate.SelectedDate.Value,
                EndDate = datePicker_ProjectEndDate.SelectedDate.Value,
                Status = comboBox_ProjectStatus.SelectedItem.ToString()
            };

            writeFile.SaveProject(project);
        }
    }
}
