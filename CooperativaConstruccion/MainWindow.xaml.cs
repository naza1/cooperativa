using Cooperativa.FileSystem;
using System;
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

        public MainWindow()
        {
            InitializeComponent();

            db = new DataAccessObject();
        }

        public void ProjectsGrid_Loaded(object sender, RoutedEventArgs e)
        {
            grillaProyectos.Items.Clear();

            var cadena = db.GetProjects();

            if (cadena.Count != 0)
            {
                foreach (var item in cadena)
                {
                    grillaProyectos.Items.Add(new {item.Id, item.Name, item.StartBudget, item.CurrentBudget, item.StartDate, item.EndDate, item.Status, item.RemainingDays});
                }
            }
        }

        public void ExpensesGrid_Loaded(object sender, RoutedEventArgs e)
        {
            if (_projectId != 0)
            {
                grillaGastos.Items.Clear();

                var cadena = db.GetExpenses(_projectId);

                if (cadena.Count != 0)
                {
                    foreach (var item in cadena)
                    {
                        grillaGastos.Items.Add(new { item.Id, item.Name, item.Amount, item.UnitPrice, item.TotalPrice });
                    }
                }
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
            button_EditExpense.Visibility = Visibility.Visible;
            button_DeleteExpense.Visibility = Visibility.Visible;
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
                MessageBox.Show("Seleccione un proyecto!", "Error!", MessageBoxButton.OK);
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
                MessageBox.Show("Seleccione un proyecto!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                try
                {
                    var result = MessageBox.Show("Seguro desea eliminar el proyecto " + _projectId + "?", "Atención!", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        db.DeleteProject(_projectId);

                        ProjectsGrid_Loaded(sender, e);

                        MessageBox.Show("Proyecto eliminado correctamente!", "Atención!", MessageBoxButton.OK);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el proyecto " + ex, "Error!", MessageBoxButton.OK);
                }

                button_EditProject.Visibility = Visibility.Hidden;

                button_DeleteProject.Visibility = Visibility.Hidden;
            }
        }

        private void button_NewExpense_Click(object sender, RoutedEventArgs e)
        {
            if (_projectId == 0)
            {
                MessageBox.Show("Seleccione un proyecto!", "Error!", MessageBoxButton.OK);
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
                MessageBox.Show("Seleccione un gasto / jornal!", "Error!", MessageBoxButton.OK);
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
                MessageBox.Show("Seleccione un gasto / jornal!", "Error!", MessageBoxButton.OK);
                return;
            }
            else
            {
                try
                {
                    var result = MessageBox.Show("Seguro desea eliminar el gasto / jornal " + _expenseId + "?", "Atención!", MessageBoxButton.YesNo);

                    if (result == MessageBoxResult.Yes)
                    {
                        db.DeleteExpense(_expenseId);

                        ExpensesGrid_Loaded(sender, e);

                        MessageBox.Show("Gasto / jornal eliminado correctamente!", "Atención!", MessageBoxButton.OK);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el gasto / jornal " + ex, "Error!", MessageBoxButton.OK);
                }

                button_EditProject.Visibility = Visibility.Hidden;

                button_DeleteProject.Visibility = Visibility.Hidden;
            }
        }

        private void button_CloseMainWindow_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}