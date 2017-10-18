using Cooperativa.FileSystem;
using System;
using System.Globalization;
using System.Windows;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private DataAccessObject db;
        public int _projectId = 0;
        public int _projectIndex = 0;
        public int _expenseId = 0;
        public int _expenseIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            db = new DataAccessObject();
            HideButtons();

            var height = SystemParameters.PrimaryScreenHeight;
            var width = SystemParameters.PrimaryScreenWidth;

            if (width < 801)
            {
                grillaProyectos.Width = 350;
                grillaGastos.Width = 250;
            }
            else if (width < 1281)
            {
                grillaProyectos.Width = 450;
                grillaGastos.Width = 350;
            }
            else if (width < 1367)
            {
                grillaProyectos.Width = 550;
                grillaGastos.Width = 450;
            }
            else
            {
                grillaProyectos.Width = 800;
                grillaGastos.Width = 600;
            }
        }

        public void ProjectsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            grillaProyectos.Items.Clear();

            var cadena = db.GetProjects();

            if (cadena.Count != 0)
            {
                foreach (var item in cadena)
                {
                    var StartBudget = item.StartBudget.ToString("C");
                    var CurrentBudget = item.CurrentBudget.ToString("C");
                    var o = new
                    {
                        item.Id,
                        item.Name,
                        StartBudget,
                        CurrentBudget,
                        item.StartDate,
                        item.EndDate,
                        item.Status,
                        item.RemainingDays
                    };

                    grillaProyectos.Items.Add(o);
                }
            }
        }

        public void ExpensesGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (_projectId != 0)
            {
                grillaGastos.Items.Clear();
                TotalGastos.Text = string.Empty;

                var cadena = db.GetExpenses(_projectId);

                if (cadena.Count != 0)
                {
                    foreach (var item in cadena)
                    {
                        var UnitPrice = item.UnitPrice.ToString("C");
                        var TotalPrice = item.TotalPrice.ToString("C");
                        var o = new
                        {
                            item.Id,
                            item.Name,
                            item.Amount,
                            UnitPrice,
                            TotalPrice
                        };

                        grillaGastos.Items.Add(o);
                    }
                }

                TotalGastos.Text = "TOTAL GASTOS / JORNALES:   " + db.CalculateTotalExpenses(_projectId).ToString("C");
            }
        }

        private void grillaProyectos_MouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = grillaProyectos.SelectedItem;

            if (item == null)
            {
                return;
            }

            button_EditProject.Visibility = Visibility.Visible;
            button_DeleteProject.Visibility = Visibility.Visible;
            button_NewExpense.Visibility = Visibility.Visible;
            button_EditExpense.Visibility = Visibility.Hidden;
            button_DeleteExpense.Visibility = Visibility.Hidden;

            _projectId = int.Parse(item.GetType().GetProperty("Id").GetValue(item, null).ToString());
            _projectIndex = grillaProyectos.SelectedIndex;

            ExpensesGrid_Loaded(sender, e);
        }

        private void grillaGastos_MouseClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = grillaGastos.SelectedItem;

            if (item == null)
            {
                return;
            }

            button_EditExpense.Visibility = Visibility.Visible;
            button_DeleteExpense.Visibility = Visibility.Visible;

            _expenseId = int.Parse(item.GetType().GetProperty("Id").GetValue(item, null).ToString());
            _expenseIndex = grillaGastos.SelectedIndex;
        }

        private void button_NewProject_Click(object sender, RoutedEventArgs e)
        {
            new NewProject(this).ShowDialog();

            if (_projectId != 0)
            {
                button_EditProject.Visibility = Visibility.Visible;
                button_DeleteProject.Visibility = Visibility.Visible;
                button_NewExpense.Visibility = Visibility.Visible;
                button_EditExpense.Visibility = Visibility.Hidden;
                button_DeleteExpense.Visibility = Visibility.Hidden;
                grillaGastos.Items.Clear();
                TotalGastos.Text = string.Empty;
            }
        }

        private void button_EditProject_Click(object sender, RoutedEventArgs e)
        {
            if (_projectId == 0)
            {
                MessageBox.Show("Seleccione un Proyecto!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                new EditProject(this).ShowDialog();

                grillaProyectos.SelectedIndex = _projectIndex;
            }
        }

        private void button_DeleteProject_Click(object sender, RoutedEventArgs e)
        {
            if (_projectId == 0)
            {
                MessageBox.Show("Seleccione un Proyecto!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                try
                {
                    var result = MessageBox.Show("Seguro desea eliminar el Proyecto " + _projectId + " y todos sus Gastos / Jornales?", "Atención!", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        db.DeleteProject(_projectId);

                        ProjectsGrid_Loaded(sender, e);

                        HideButtons();

                        MessageBox.Show("Proyecto eliminado correctamente!", "Atención!", MessageBoxButton.OK);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el Proyecto " + ex, "Error!", MessageBoxButton.OK);
                }
            }
        }

        private void button_NewExpense_Click(object sender, RoutedEventArgs e)
        {
            if (_projectId == 0)
            {
                MessageBox.Show("Seleccione un Proyecto!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                new NewExpense(this).ShowDialog();

                if (_expenseId != 0)
                {
                    button_EditExpense.Visibility = Visibility.Visible;
                    button_DeleteExpense.Visibility = Visibility.Visible;
                }
            }
        }

        private void button_EditExpense_Click(object sender, RoutedEventArgs e)
        {
            if (_expenseId == 0)
            {
                MessageBox.Show("Seleccione un Gasto / Jornal!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                new EditExpense(this).ShowDialog();

                grillaProyectos.SelectedIndex = _projectIndex;
            }
        }

        private void button_DeleteExpense_Click(object sender, RoutedEventArgs e)
        {
            if (_expenseId == 0)
            {
                MessageBox.Show("Seleccione un Gasto / Jornal!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                try
                {
                    var result = MessageBox.Show("Seguro desea eliminar el Gasto / Jornal " + _expenseId + "?", "Atención!", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        db.DeleteExpense(_expenseId);

                        ProjectsGrid_Loaded(sender, e);

                        ExpensesGrid_Loaded(sender, e);

                        grillaProyectos.SelectedIndex = _projectIndex;

                        MessageBox.Show("Gasto / Jornal eliminado correctamente!", "Atención!", MessageBoxButton.OK);

                        button_EditExpense.Visibility = Visibility.Hidden;
                        button_DeleteExpense.Visibility = Visibility.Hidden;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el Gasto / Jornal " + ex, "Error!", MessageBoxButton.OK);
                }
            }
        }

        private void button_CloseMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Help_Click(object sender, RoutedEventArgs e)
        {
            new HelpWindow().ShowDialog();
        }

        private void button_About_Click(object sender, RoutedEventArgs e)
        {
            new AboutWindow().ShowDialog();
        }

        public void HideButtons()
        {
            button_EditProject.Visibility = Visibility.Hidden;
            button_DeleteProject.Visibility = Visibility.Hidden;
            button_NewExpense.Visibility = Visibility.Hidden;
            button_EditExpense.Visibility = Visibility.Hidden;
            button_DeleteExpense.Visibility = Visibility.Hidden;
            grillaGastos.Items.Clear();
            TotalGastos.Text = string.Empty;
        }
    }
}