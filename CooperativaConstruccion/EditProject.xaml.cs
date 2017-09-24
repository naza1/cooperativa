﻿using Cooperativa.FileSystem;
using FileSystem.Tables;
using System;
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
        private int _projectId = 0;
        private MainWindow _main;

        public EditProject(MainWindow main, int projectId)
        {
            InitializeComponent();
            db = new DataAccessObject();
            _main = main;
            _projectId = projectId;
            OnLoad();
        }

        private void OnLoad()
        {
            var proj = db.GetProject(_projectId);
            textBox_ProjectName.Text = proj.Name;
            textBox_ProjectStartBudget.Text = proj.StartBudget;
            datePicker_ProjectStartDate.SelectedDate = DateTime.Parse(proj.StartDate);
            datePicker_ProjectEndDate.SelectedDate = DateTime.Parse(proj.EndDate);
            comboBox_ProjectStatus.Text = proj.Status;
            textBox_ProjectObservations.Text = proj.Observations;
            textBox_ProjectName.Focus();
        }

        private void textBox_ProjectName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HiddenButtons();
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
                _main.HiddenButtons();
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
                _main.HiddenButtons();
                Close();
            }
        }

        private void datePicker_ProjectEndDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HiddenButtons();
                Close();
            }
        }

        private void comboBox_ProjectStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HiddenButtons();
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
                _main.HiddenButtons();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                button_SaveProject.Focus();
            }
        }

        private void button_SaveProject_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HiddenButtons();
                Close();
            }
        }

        private void button_Cancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HiddenButtons();
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
                    var project = new Project
                    {
                        Id = _projectId,
                        Name = textBox_ProjectName.Text,
                        StartBudget = textBox_ProjectStartBudget.Text.Replace(" ", ""),
                        StartDate = datePicker_ProjectStartDate.SelectedDate.Value.Date.ToShortDateString(),
                        EndDate = datePicker_ProjectEndDate.SelectedDate.Value.Date.ToShortDateString(),
                        Status = comboBox_ProjectStatus.SelectionBoxItem.ToString(),
                        Observations = textBox_ProjectObservations.Text,
                    };

                    db.UpdateProject(project);

                    _main.ProjectsGrid_Loaded(sender, e);

                    Close();

                    MessageBox.Show("Proyecto actualizado correctamente!", "Atención!", MessageBoxButton.OK);

                    _main.HiddenButtons();
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
            _main.HiddenButtons();
            Close();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            _main.HiddenButtons();
        }
    }
}