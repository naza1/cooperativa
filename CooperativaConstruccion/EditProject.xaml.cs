using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for EditProject.xaml
    /// </summary>
    public partial class EditProject : Window
    {
        private DataAccessObject db;
        private MainWindow _main;
        private CultureInfo culture = new CultureInfo("es-AR", true);

        public EditProject(MainWindow main)
        {
            InitializeComponent();
            db = new DataAccessObject();
            _main = main;
            OnLoad();
        }

        private void OnLoad()
        {
            var proj = db.GetProject(_main._projectId);

            textBox_ProjectName.Text = proj.Name;
            textBox_ProjectStartBudget.Text = proj.StartBudget.ToString(culture);
            datePicker_ProjectStartDate.SelectedDate = DateTime.Parse(proj.StartDate, culture);
            datePicker_ProjectEndDate.SelectedDate = DateTime.Parse(proj.EndDate, culture);
            comboBox_ProjectStatus.Text = proj.Status;
            textBox_ProjectObservations.Text = proj.Observations;
            textBox_ProjectName.Focus();
        }

        private void EditProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void textBox_ProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textBox_ProjectStartBudget.Focus();
            }
        }

        private void textBox_ProjectStartBudget_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Decimal || e.Key == Key.OemPeriod || e.Key == Key.Tab || e.Key == Key.Escape)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (e.Key == Key.Enter)
            {
                datePicker_ProjectStartDate.Focus();
            }
        }

        private void textBox_ProjectStartBudget_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void datePicker_ProjectStartDate_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void datePicker_ProjectEndDate_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void comboBox_ProjectStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textBox_ProjectObservations.Focus();
            }
        }

        private void textBox_ProjectObservations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                button_SaveProject.Focus();
            }
        }

        private void button_SaveProject_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_ProjectName.Text == string.Empty || textBox_ProjectStartBudget.Text == string.Empty || datePicker_ProjectStartDate.Text == string.Empty || datePicker_ProjectEndDate.Text == string.Empty)
            {
                MessageBox.Show("Verifique los datos ingresados!", "Error!", MessageBoxButton.OK);

                textBox_ProjectName.Focus();

                return;
            }
            else if (datePicker_ProjectStartDate.SelectedDate.Value.Date.CompareTo(datePicker_ProjectEndDate.SelectedDate.Value.Date) > 0)
            {

                MessageBox.Show("Verifique las fechas ingresadas!", "Error!", MessageBoxButton.OK);

                datePicker_ProjectStartDate.Focus();

                return;
            }
            else
            {
                try
                {
                    var project = new Project
                    {
                        Id = _main._projectId,
                        Name = textBox_ProjectName.Text,
                        StartBudget = decimal.Parse(textBox_ProjectStartBudget.Text.Replace(" ", "").Replace(".", ","), culture),
                        StartDate = datePicker_ProjectStartDate.SelectedDate.Value.ToShortDateString().ToString(culture),
                        EndDate = datePicker_ProjectEndDate.SelectedDate.Value.ToShortDateString().ToString(culture),
                        Status = comboBox_ProjectStatus.SelectionBoxItem.ToString(),
                        Observations = textBox_ProjectObservations.Text
                    };

                    db.UpdateProject(project);

                    _main.ProjectsGrid_Loaded(sender, e);

                    _main.grillaProyectos.SelectedIndex = _main._projectIndex;

                    Close();

                    MessageBox.Show("Proyecto actualizado correctamente!", "Atención!", MessageBoxButton.OK);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar el Proyecto, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK);

                    textBox_ProjectName.Focus();

                    return;
                }
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}