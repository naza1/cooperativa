﻿#pragma checksum "..\..\NewExpense.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "B2B1F4D900D09328CB3F47678BBB7D4E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using CooperativaConstruccion;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CooperativaConstruccion {
    
    
    /// <summary>
    /// NewExpense
    /// </summary>
    public partial class NewExpense : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_ExpenseType;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Gasto;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Jornal;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ExpenseName;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ExpenseAmount;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ExpenseUnitPrice;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ExpenseTotalPrice;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ExpenseVoucherNumber;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ExpenseDescription;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_SaveExpense;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\NewExpense.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_Cancel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CooperativaConstruccion;component/newexpense.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewExpense.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\NewExpense.xaml"
            ((CooperativaConstruccion.NewExpense)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.comboBox_ExpenseType = ((System.Windows.Controls.ComboBox)(target));
            
            #line 11 "..\..\NewExpense.xaml"
            this.comboBox_ExpenseType.KeyDown += new System.Windows.Input.KeyEventHandler(this.comboBox_ExpenseType_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Gasto = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 4:
            this.Jornal = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 5:
            this.textBox_ExpenseName = ((System.Windows.Controls.TextBox)(target));
            
            #line 16 "..\..\NewExpense.xaml"
            this.textBox_ExpenseName.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ExpenseName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 6:
            this.textBox_ExpenseAmount = ((System.Windows.Controls.TextBox)(target));
            
            #line 18 "..\..\NewExpense.xaml"
            this.textBox_ExpenseAmount.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ExpenseAmount_KeyDown);
            
            #line default
            #line hidden
            
            #line 18 "..\..\NewExpense.xaml"
            this.textBox_ExpenseAmount.LostFocus += new System.Windows.RoutedEventHandler(this.textBox_ExpenseAmount_LostFocus);
            
            #line default
            #line hidden
            
            #line 18 "..\..\NewExpense.xaml"
            this.textBox_ExpenseAmount.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.textBox_ExpenseAmount_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 7:
            this.textBox_ExpenseUnitPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 20 "..\..\NewExpense.xaml"
            this.textBox_ExpenseUnitPrice.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ExpenseUnitPrice_KeyDown);
            
            #line default
            #line hidden
            
            #line 20 "..\..\NewExpense.xaml"
            this.textBox_ExpenseUnitPrice.LostFocus += new System.Windows.RoutedEventHandler(this.textBox_ExpenseUnitPrice_LostFocus);
            
            #line default
            #line hidden
            
            #line 20 "..\..\NewExpense.xaml"
            this.textBox_ExpenseUnitPrice.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.textBox_ExpenseUnitPrice_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 8:
            this.textBox_ExpenseTotalPrice = ((System.Windows.Controls.TextBox)(target));
            
            #line 22 "..\..\NewExpense.xaml"
            this.textBox_ExpenseTotalPrice.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ExpenseTotalPrice_KeyDown);
            
            #line default
            #line hidden
            
            #line 22 "..\..\NewExpense.xaml"
            this.textBox_ExpenseTotalPrice.LostFocus += new System.Windows.RoutedEventHandler(this.textBox_ExpenseTotalPrice_LostFocus);
            
            #line default
            #line hidden
            return;
            case 9:
            this.textBox_ExpenseVoucherNumber = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\NewExpense.xaml"
            this.textBox_ExpenseVoucherNumber.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ExpenseVoucherNumber_KeyDown);
            
            #line default
            #line hidden
            return;
            case 10:
            this.textBox_ExpenseDescription = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\NewExpense.xaml"
            this.textBox_ExpenseDescription.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ExpenseDescription_KeyDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.button_SaveExpense = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\NewExpense.xaml"
            this.button_SaveExpense.Click += new System.Windows.RoutedEventHandler(this.button_SaveExpense_Click);
            
            #line default
            #line hidden
            
            #line 27 "..\..\NewExpense.xaml"
            this.button_SaveExpense.KeyDown += new System.Windows.Input.KeyEventHandler(this.button_SaveExpense_KeyDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.button_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\NewExpense.xaml"
            this.button_Cancel.KeyDown += new System.Windows.Input.KeyEventHandler(this.button_Cancel_KeyDown);
            
            #line default
            #line hidden
            
            #line 28 "..\..\NewExpense.xaml"
            this.button_Cancel.Click += new System.Windows.RoutedEventHandler(this.button_Cancel_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

