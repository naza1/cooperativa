using Cooperativa.FileSystem;
using FileSystem.tablas;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Lógica de interacción para NewExpense.xaml
    /// </summary>
    public partial class NewExpense : Window
    {
        private DataAccessObject db;
        private int _projectId = 0;
        private MainWindow _main;

        public NewExpense(MainWindow main, int projectId)
        {
            InitializeComponent();
            db = new DataAccessObject();
            _main = main;
            _projectId = projectId;
            OnLoad();
        }

        private void OnLoad()
        {
            comboBox_ExpenseType.Text = "Gasto";
            textBox_ExpenseName.Text = "";
            textBox_ExpenseAmount.Text = "";
            textBox_ExpenseUnitPrice.Text = "";
            textBox_ExpenseTotalPrice.Text = "";
            textBox_ExpenseVoucherNumber.Text = "";
            textBox_ExpenseDescription.Text = "";
            comboBox_ExpenseType.Focus();
        }

        private void comboBox_ExpenseType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseName.Focus();
            }
        }

        private void textBox_ExpenseName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseAmount.Focus();
            }
        }

        private void textBox_ExpenseAmount_KeyDown(object sender, KeyEventArgs e)
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
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseUnitPrice.Focus();
            }
        }

        private void textBox_ExpenseUnitPrice_KeyDown(object sender, KeyEventArgs e)
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
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if(textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
                {
                    textBox_ExpenseTotalPrice.Text = (decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", ""), CultureInfo.CreateSpecificCulture("en-US")) * decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", ""), CultureInfo.CreateSpecificCulture("en-US"))).ToString().Replace(",", ".");
                }
                else
                {
                    textBox_ExpenseTotalPrice.Text = "0";
                }
                textBox_ExpenseVoucherNumber.Focus();
            }
        }

        private void textBox_ExpenseTotalPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseVoucherNumber.Focus();
            }
        }

        private void textBox_ExpenseVoucherNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.OemMinus || e.Key == Key.Subtract || e.Key == Key.Tab)
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseDescription.Focus();
            }
        }

        private void textBox_ExpenseDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
            if (e.Key == Key.Enter)
            {
                button_SaveExpense.Focus();
            }
        }

        private void button_SaveExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
        }

        private void button_Cancel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.button_EditProject.Visibility = Visibility.Hidden;
                _main.button_DeleteProject.Visibility = Visibility.Hidden;
                _main.button_NewExpense.Visibility = Visibility.Hidden;
                _main.button_EditExpense.Visibility = Visibility.Hidden;
                _main.button_DeleteExpense.Visibility = Visibility.Hidden;
                _main.grillaGastos.Items.Clear();
                Close();
            }
        }

        private void button_SaveExpense_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_ExpenseName.Text == string.Empty || textBox_ExpenseAmount.Text == string.Empty || textBox_ExpenseUnitPrice.Text == string.Empty || textBox_ExpenseVoucherNumber.Text == string.Empty)
            {
                MessageBox.Show("Verifique los datos ingresados!", "Error!", MessageBoxButton.OK);
                comboBox_ExpenseType.Focus();
                return;
            }
            else
            {
                try
                {
                    var expense = new Expense
                    {
                        ProjectId = _projectId,
                        Name = textBox_ExpenseName.Text,
                        Type = comboBox_ExpenseType.SelectionBoxItem.ToString(),
                        Amount = textBox_ExpenseAmount.Text.Replace(" ", ""),
                        UnitPrice = textBox_ExpenseUnitPrice.Text.Replace(" ", ""),
                        TotalPrice = textBox_ExpenseTotalPrice.Text.Replace(" ", ""),
                        VoucherNumber = textBox_ExpenseVoucherNumber.Text,
                        Date = DateTime.Now.Date.ToShortDateString(),
                        Description = textBox_ExpenseDescription.Text,
                    };

                    db.InsertExpense(expense);

                    _main.ProjectsGrid_Loaded(sender, e);

                    _main.ExpensesGrid_Loaded(sender, e);

                    MessageBox.Show("Gasto / Jornal guardado correctamente!", "Atención!", MessageBoxButton.OK);

                    OnLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el Gasto / Jornal, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK);
                    comboBox_ExpenseType.Focus();
                    return;
                }
            }
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            _main.button_EditProject.Visibility = Visibility.Hidden;
            _main.button_DeleteProject.Visibility = Visibility.Hidden;
            _main.button_NewExpense.Visibility = Visibility.Hidden;
            _main.button_EditExpense.Visibility = Visibility.Hidden;
            _main.button_DeleteExpense.Visibility = Visibility.Hidden;
            _main.grillaGastos.Items.Clear();
            Close();
        }
    }
}