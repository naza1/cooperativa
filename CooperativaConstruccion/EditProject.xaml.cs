using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
using System.Windows;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for EditProject.xaml
    /// </summary>
    public partial class EditProject : Window
    {
        private DataAccessObject db;
        private int _projectId = 0;
        private MainWindow mainWindow;

        public EditProject(MainWindow mainWindow, int projectId)
        {
            InitializeComponent();
            db = new DataAccessObject();
            this.mainWindow = mainWindow;
            _projectId = projectId;
            OnLoad();
        }

        private void OnLoad()
        {

            var proj = db.GetProject(_projectId);
            textBox_ProjectName.Text = proj.Name;
            textBox_ProjectStartBudjet.Text = proj.StartBudget.ToString();
            datePicker_ProjectStartDate.SelectedDate = DateTime.Parse(proj.StartDate);
            datePicker_ProjectEndDate.SelectedDate = DateTime.Parse(proj.EndDate);
            comboBox_ProjectStatus.SelectedValue = proj.Status;

        }

        private void UpdateProject(object sender, RoutedEventArgs e)
        {
            try
            {
                var project = new Project
                {
                    Name = textBox_ProjectName.Text,
                    StartBudget = int.Parse(textBox_ProjectStartBudjet.Text),
                    CreationDate = DateTime.Now.Date.ToShortDateString(),
                    StartDate = datePicker_ProjectStartDate.SelectedDate.Value.Date.ToShortDateString(),
                    EndDate = datePicker_ProjectEndDate.SelectedDate.Value.Date.ToShortDateString(),
                    Status = comboBox_ProjectStatus.SelectionBoxItem.ToString()
                };

                db.UpdateProject(project);

                MessageBox.Show("Proyecto guardado correctamente!", "Atención", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el proyecto, por favor verifique los datos ingresados " + ex, "Error", MessageBoxButton.OK);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
