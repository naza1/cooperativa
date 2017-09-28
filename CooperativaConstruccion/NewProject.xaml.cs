using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

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
            textBox_ProjectStartBudget.Text = "";
            datePicker_ProjectStartDate.SelectedDate = DateTime.Now;
            datePicker_ProjectEndDate.SelectedDate = DateTime.Now;
            comboBox_ProjectStatus.Text = "Activo";
            textBox_ProjectObservations.Text = "";
            textBox_ProjectName.Focus();
        }

        private void textBox_ProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
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
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                datePicker_ProjectStartDate.Focus();
            }
        }

        private void datePicker_ProjectStartDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
        }

        private void datePicker_ProjectStartDate_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (datePicker_ProjectStartDate.SelectedDate.Value.Date > DateTime.Now)
            {
                comboBox_ProjectStatus.Text = "Inactivo";
            }
        }

        private void datePicker_ProjectEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
        }

        private void datePicker_ProjectEndDate_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (datePicker_ProjectEndDate.SelectedDate.Value.Date < DateTime.Now)
            {
                comboBox_ProjectStatus.Text = "Finalizado";
            }
        }

        private void comboBox_ProjectStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                textBox_ProjectObservations.Focus();
            }
        }

        private void textBox_ProjectObservations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
        }

        private void button_SaveProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
            }
        }

        private void button_Cancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
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
                    var culture = CultureInfo.CreateSpecificCulture("en-US");

                    var project = new Project
                    {
                        Name = textBox_ProjectName.Text,
                        StartBudget = decimal.Parse(textBox_ProjectStartBudget.Text.Replace(" ", ""), culture),
                        CreationDate = DateTime.Now.Date.ToShortDateString(),
                        StartDate = datePicker_ProjectStartDate.SelectedDate.Value.Date.ToShortDateString(),
                        EndDate = datePicker_ProjectEndDate.SelectedDate.Value.Date.ToShortDateString(),
                        Status = comboBox_ProjectStatus.SelectionBoxItem.ToString(),
                        Observations = textBox_ProjectObservations.Text,
                    };

                    db.InsertProject(project);

                    _main.ProjectsGrid_Loaded(sender, e);

                    MessageBox.Show("Proyecto guardado correctamente!", "Atención!", MessageBoxButton.OK);

                    OnLoad();
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo crear el proyecto, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK);

                    textBox_ProjectName.Focus();

                    return;
                }
            }
            
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            _main.HideButtons();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _main.HideButtons();
        }
    }
}