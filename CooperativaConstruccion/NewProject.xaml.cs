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
            try
            {
                var project = new Project
                {
                    Name = textBox_ProjectName.Text,
                    StartBudget = int.Parse(textBox_ProjectStartBudjet.Text),
                    Date = DateTime.Now.ToString(),
                    StartDate = datePicker_ProjectStartDate.SelectedDate.Value.ToString(),
                    EndDate = datePicker_ProjectEndDate.SelectedDate.Value.ToString(),
                    Status = comboBox_ProjectStatus.SelectionBoxItem.ToString()
                };

                writeFile.CreateProject(project);

                MessageBox.Show("Proyecto guardado correctemante");
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el proyecto, por favor verifique los datos ingresados" + ex);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
