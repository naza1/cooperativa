using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

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
            textBox_ProjectName.Text = "";
            textBox_ProjectStartBudjet.Text = "";
            datePicker_ProjectStartDate.SelectedDate = DateTime.Now;
            datePicker_ProjectEndDate.SelectedDate = DateTime.Now;
            comboBox_ProjectStatus.Text = "Activo";
            textBox_ProjectName.Focus();
        }

        private void CreateProject(object sender, RoutedEventArgs e)
        {
            try
            {
                var project = new Project
                {
                    Name = textBox_ProjectName.Text,
                    StartBudget = textBox_ProjectStartBudjet.Text,
                    CurrentBudget = textBox_ProjectStartBudjet.Text,
                    CreationDate = DateTime.Now.Date.ToShortDateString(),
                    StartDate = datePicker_ProjectStartDate.SelectedDate.Value.Date.ToShortDateString(),
                    EndDate = datePicker_ProjectEndDate.SelectedDate.Value.Date.ToShortDateString(),
                    Status = comboBox_ProjectStatus.SelectionBoxItem.ToString(),
                    Deleted = "0"
                };

                //var culture = CultureInfo.CreateSpecificCulture("US-en");
                //var a = decimal.Parse(project.StartBudget, culture);

                db.InsertProject(project);

                _main.ProjectsGrid_Loaded(sender, e);

                MessageBox.Show("Proyecto guardado correctamente!", "Atención!", MessageBoxButton.OK);

                OnLoad();
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo crear el proyecto, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK);
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void NumericOnly(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = !Regex.IsMatch(e.Text, "^((?:[1-9]\\d*)|(?:(?=[\\d.]+)(?:[1-9]\\d*|0)\\.\\d+))$");
        }
    }
}