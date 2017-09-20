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
        private MainWindow _main;

        public EditProject(MainWindow mainWindow, int projectId)
        {
            InitializeComponent();
            db = new DataAccessObject();
            this._main = mainWindow;
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
            comboBox_ProjectStatus.Text = proj.Status;
        }

        private void UpdateProject(object sender, RoutedEventArgs e)
        {
            try
            {
                var project = new Project
                {
                    Id = _projectId,
                    Name = textBox_ProjectName.Text,
                    StartBudget = decimal.Parse(textBox_ProjectStartBudjet.Text),
                    CurrentBudget = decimal.Parse(textBox_ProjectStartBudjet.Text),
                    CreationDate = DateTime.Now.Date.ToShortDateString(),
                    StartDate = datePicker_ProjectStartDate.SelectedDate.Value.Date.ToShortDateString(),
                    EndDate = datePicker_ProjectEndDate.SelectedDate.Value.Date.ToShortDateString(),
                    Status = comboBox_ProjectStatus.SelectionBoxItem.ToString(),
                    Deleted = "0"
                };

                db.UpdateProject(project);
                _main.ProjectsGrid_Loaded(sender, e);
                MessageBox.Show("Proyecto actualizado correctamente!", "Atención!", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo actualizar el proyecto, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            _main.button_EditProject.Visibility = Visibility.Hidden;
            _main.button_DeleteProject.Visibility = Visibility.Hidden;
            Close();
        }
    }
}
