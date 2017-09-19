using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
using System.Windows;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        private DataAccessObject db;
        private MainWindow _main;

        public NewProject(MainWindow main)
        {
            InitializeComponent();
            db = new DataAccessObject();
            _main = main;
            OnLoad();
        }

        private void OnLoad()
        {
            datePicker_ProjectStartDate.SelectedDate = DateTime.Now;
            datePicker_ProjectEndDate.SelectedDate = DateTime.Now;
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {
            try
            {
                var project = new Project
                {
                    Name = textBox_ProjectName.Text,
                    StartBudget = int.Parse(textBox_ProjectStartBudjet.Text),
                    CurrentBudget = int.Parse(textBox_ProjectStartBudjet.Text),
                    CreationDate = DateTime.Now.Date.ToShortDateString(),
                    StartDate = datePicker_ProjectStartDate.SelectedDate.Value.Date.ToShortDateString(),
                    EndDate = datePicker_ProjectEndDate.SelectedDate.Value.Date.ToShortDateString(),
                    Status = comboBox_ProjectStatus.SelectionBoxItem.ToString(),
                    Deleted = "0"
                };

                db.InsertProject(project);

                MessageBox.Show("Proyecto guardado correctamente!", "Atención", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el proyecto, por favor verifique los datos ingresados " + ex, "Error", MessageBoxButton.OK);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            _main.ProjectsGrid_Loaded(sender, e);
            Close();
        }
    }
}