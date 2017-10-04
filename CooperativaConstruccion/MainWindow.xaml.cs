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
        private int _projectId = 0;
        private int _expenseId = 0;
        private CultureInfo culture = new CultureInfo("es-AR", true);

        public MainWindow()
        {
            InitializeComponent();
            db = new DataAccessObject();
            HideButtons();
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

                TotalGastos.Text = "TOTAL:   " + db.CalculateTotalExpenses(_projectId).ToString("C");
            }
        }

        private void grillaProyectos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = grillaProyectos.SelectedItem;

            if (item == null)
            {
                return;
            }

            button_EditProject.Visibility = Visibility.Visible;
            button_DeleteProject.Visibility = Visibility.Visible;
            button_NewExpense.Visibility = Visibility.Visible;

            _projectId = int.Parse(item.GetType().GetProperty("Id").GetValue(item, null).ToString());

            ExpensesGrid_Loaded(sender, e);
        }

        private void grillaGastos_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var item = grillaGastos.SelectedItem;

            if (item == null)
            {
                return;
            }

            button_EditExpense.Visibility = Visibility.Visible;
            button_DeleteExpense.Visibility = Visibility.Visible;

            _expenseId = int.Parse(item.GetType().GetProperty("Id").GetValue(item, null).ToString());
        }

        private void button_NewProject_Click(object sender, RoutedEventArgs e)
        {
            new NewProject(this).ShowDialog();
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
                new EditProject(this, _projectId).ShowDialog();
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

                        MessageBox.Show("Proyecto eliminado correctamente!", "Atención!", MessageBoxButton.OK);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el Proyecto " + ex, "Error!", MessageBoxButton.OK);
                }

                HideButtons();
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
                new NewExpense(this, _projectId).ShowDialog();
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
                new EditExpense(this, _expenseId).ShowDialog();
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

                        MessageBox.Show("Gasto / Jornal eliminado correctamente!", "Atención!", MessageBoxButton.OK);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el Gasto / Jornal " + ex, "Error!", MessageBoxButton.OK);
                }

                HideButtons();
            }
        }

        private void button_CloseMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
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