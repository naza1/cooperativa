using Cooperativa.FileSystem;
using FileSystem.tablas;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Lógica de interacción para NewExpense.xaml
    /// </summary>
    public partial class NewExpense : Window
    {
        private DataAccessObject db;
        private MainWindow _main;
        private CultureInfo culture = new CultureInfo("es-AR", true);

        public NewExpense(MainWindow main)
        {
            InitializeComponent();
            db = new DataAccessObject();
            _main = main;
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
            textBox_ExpenseName.Focus();
        }

        private void NewExpense_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
        }

        private void comboBox_ExpenseType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseName.Focus();
            }
        }

        private void textBox_ExpenseName_KeyDown(object sender, KeyEventArgs e)
        {
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
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
                {
                    var amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture);

                    var unitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture);

                    textBox_ExpenseTotalPrice.Text = (amount * unitPrice).ToString();
                }
                else
                {
                    textBox_ExpenseTotalPrice.Text = "0,00";
                }

                textBox_ExpenseUnitPrice.Focus();
            }
        }

        private void textBox_ExpenseAmount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
            {
                var amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture);

                var unitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture);

                textBox_ExpenseTotalPrice.Text = (amount * unitPrice).ToString();
            }
            else
            {
                textBox_ExpenseTotalPrice.Text = "0,00";
            }
        }

        private void textBox_ExpenseAmount_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
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
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
                {
                    var amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture);

                    var unitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture);

                    textBox_ExpenseTotalPrice.Text = (amount * unitPrice).ToString();
                }
                else
                {
                    textBox_ExpenseTotalPrice.Text = "0,00";
                }

                textBox_ExpenseVoucherNumber.Focus();
            }
        }

        private void textBox_ExpenseUnitPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
            {
                var amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture);

                var unitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture);

                textBox_ExpenseTotalPrice.Text = (amount * unitPrice).ToString();
            }
            else
            {
                textBox_ExpenseTotalPrice.Text = "0,00";
            }
        }

        private void textBox_ExpenseUnitPrice_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }

        private void textBox_ExpenseTotalPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Tab || e.Key == Key.Enter)
            {
                if (textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
                {
                    var amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture);

                    var unitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture);

                    textBox_ExpenseTotalPrice.Text = (amount * unitPrice).ToString();
                }
                else
                {
                    textBox_ExpenseTotalPrice.Text = "0,00";
                }

                textBox_ExpenseVoucherNumber.Focus();
            }
        }

        private void textBox_ExpenseTotalPrice_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBox_ExpenseAmount.Text != "" && textBox_ExpenseUnitPrice.Text != "")
            {
                var amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture);

                var unitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture);

                textBox_ExpenseTotalPrice.Text = (amount * unitPrice).ToString();
            }
            else
            {
                textBox_ExpenseTotalPrice.Text = "0,00";
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
            if (e.Key == Key.Enter)
            {
                textBox_ExpenseDescription.Focus();
            }
        }

        private void button_SaveExpense_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_ExpenseName.Text == string.Empty || textBox_ExpenseAmount.Text == string.Empty || textBox_ExpenseUnitPrice.Text == string.Empty || textBox_ExpenseTotalPrice.Text == string.Empty || textBox_ExpenseVoucherNumber.Text == string.Empty)
            {
                MessageBox.Show("Verifique los datos ingresados!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                comboBox_ExpenseType.Focus();

                return;
            }
            else
            {
                try
                {
                    var expense = new Expense
                    {
                        ProjectId = _main._projectId,
                        Name = textBox_ExpenseName.Text,
                        Type = comboBox_ExpenseType.SelectionBoxItem.ToString(),
                        Amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture),
                        UnitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture),
                        TotalPrice = decimal.Parse(textBox_ExpenseTotalPrice.Text.Replace(" ", "").Replace(".", ","), culture),
                        VoucherNumber = textBox_ExpenseVoucherNumber.Text,
                        Date = DateTime.Now.Date.ToShortDateString(),
                        Description = textBox_ExpenseDescription.Text
                    };

                    _main._expenseId = db.InsertExpense(expense);

                    _main.ProjectsGrid_Loaded(sender, e);

                    _main.ExpensesGrid_Loaded(sender, e);

                    _main.grillaProyectos.SelectedIndex = _main._projectIndex;

                    var expenseIndex = _main.grillaGastos.Items.Count - 1;

                    _main.grillaGastos.SelectedIndex = expenseIndex;

                    _main._expenseIndex = expenseIndex;

                    MessageBox.Show("Gasto / Jornal guardado correctamente!", "Atención!", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    OnLoad();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo guardar el Gasto / Jornal, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);

                    textBox_ExpenseName.Focus();

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