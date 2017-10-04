using Cooperativa.FileSystem;
using FileSystem.tablas;
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Input;

namespace CooperativaConstruccion
{
    /// <summary>
    /// Lógica de interacción para EditExpense.xaml
    /// </summary>
    public partial class EditExpense : Window
    {
        private DataAccessObject db;
        private MainWindow _main;
        private int _expenseId = 0;
        private CultureInfo culture = new CultureInfo("es-AR", true);

        public EditExpense(MainWindow main, int expenseId)
        {
            InitializeComponent();
            db = new DataAccessObject();
            _main = main;
            _expenseId = expenseId;
            OnLoad();
        }

        private void OnLoad()
        {
            var exp = db.GetExpense(_expenseId);
            comboBox_ExpenseType.Text = exp.Type;
            textBox_ExpenseName.Text = exp.Name;
            textBox_ExpenseAmount.Text = exp.Amount.ToString();
            textBox_ExpenseUnitPrice.Text = exp.UnitPrice.ToString();
            textBox_ExpenseTotalPrice.Text = exp.TotalPrice.ToString();
            textBox_ExpenseVoucherNumber.Text = exp.VoucherNumber;
            textBox_ExpenseDescription.Text = exp.Description;
            comboBox_ExpenseType.Focus();
        }

        private void comboBox_ExpenseType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
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
                _main.HideButtons();
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
                _main.HideButtons();
                Close();
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
                _main.HideButtons();
                Close();
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

        private void textBox_ExpenseTotalPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
                Close();
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
            if (e.Key == Key.Escape)
            {
                _main.HideButtons();
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
                _main.HideButtons();
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

        private void button_SaveExpense_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_ExpenseName.Text == string.Empty || textBox_ExpenseAmount.Text == string.Empty || textBox_ExpenseUnitPrice.Text == string.Empty || textBox_ExpenseTotalPrice.Text == string.Empty || textBox_ExpenseVoucherNumber.Text == string.Empty)
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
                        Id = _expenseId,
                        Name = textBox_ExpenseName.Text,
                        Type = comboBox_ExpenseType.SelectionBoxItem.ToString(),
                        Amount = decimal.Parse(textBox_ExpenseAmount.Text.Replace(" ", "").Replace(".", ","), culture),
                        UnitPrice = decimal.Parse(textBox_ExpenseUnitPrice.Text.Replace(" ", "").Replace(".", ","), culture),
                        TotalPrice = decimal.Parse(textBox_ExpenseTotalPrice.Text.Replace(" ", "").Replace(".", ","), culture),
                        VoucherNumber = textBox_ExpenseVoucherNumber.Text,
                        Description = textBox_ExpenseDescription.Text,
                    };

                    db.UpdateExpense(expense);

                    _main.ProjectsGrid_Loaded(sender, e);

                    _main.ExpensesGrid_Loaded(sender, e);

                    Close();

                    MessageBox.Show("Gasto / Jornal actualizado correctamente!", "Atención!", MessageBoxButton.OK);

                    _main.HideButtons();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar el Gasto / Jornal, por favor verifique los datos ingresados " + ex, "Error!", MessageBoxButton.OK);

                    comboBox_ExpenseType.Focus();

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