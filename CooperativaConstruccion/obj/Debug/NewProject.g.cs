﻿#pragma checksum "..\..\NewProject.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "6E33A26EACE2F0DC21D875C5EF329AC6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
    /// NewProject
    /// </summary>
    public partial class NewProject : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ProjectName;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ProjectStartBudget;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker_ProjectStartDate;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker datePicker_ProjectEndDate;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox comboBox_ProjectStatus;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Activo;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Inactivo;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBoxItem Finalizado;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBox_ProjectObservations;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_SaveProject;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\NewProject.xaml"
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
            System.Uri resourceLocater = new System.Uri("/CooperativaConstruccion;component/newproject.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\NewProject.xaml"
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
            
            #line 8 "..\..\NewProject.xaml"
            ((CooperativaConstruccion.NewProject)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.Window_Closing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.textBox_ProjectName = ((System.Windows.Controls.TextBox)(target));
            
            #line 11 "..\..\NewProject.xaml"
            this.textBox_ProjectName.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ProjectName_KeyDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.textBox_ProjectStartBudget = ((System.Windows.Controls.TextBox)(target));
            
            #line 13 "..\..\NewProject.xaml"
            this.textBox_ProjectStartBudget.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ProjectStartBudget_KeyDown);
            
            #line default
            #line hidden
            
            #line 13 "..\..\NewProject.xaml"
            this.textBox_ProjectStartBudget.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.textBox_ProjectStartBudget_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 4:
            this.datePicker_ProjectStartDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 15 "..\..\NewProject.xaml"
            this.datePicker_ProjectStartDate.KeyDown += new System.Windows.Input.KeyEventHandler(this.datePicker_ProjectStartDate_KeyDown);
            
            #line default
            #line hidden
            
            #line 15 "..\..\NewProject.xaml"
            this.datePicker_ProjectStartDate.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.datePicker_ProjectStartDate_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 5:
            this.datePicker_ProjectEndDate = ((System.Windows.Controls.DatePicker)(target));
            
            #line 17 "..\..\NewProject.xaml"
            this.datePicker_ProjectEndDate.KeyDown += new System.Windows.Input.KeyEventHandler(this.datePicker_ProjectEndDate_KeyDown);
            
            #line default
            #line hidden
            
            #line 17 "..\..\NewProject.xaml"
            this.datePicker_ProjectEndDate.AddHandler(System.Windows.Input.CommandManager.PreviewExecutedEvent, new System.Windows.Input.ExecutedRoutedEventHandler(this.datePicker_ProjectEndDate_PreviewExecuted));
            
            #line default
            #line hidden
            return;
            case 6:
            this.comboBox_ProjectStatus = ((System.Windows.Controls.ComboBox)(target));
            
            #line 19 "..\..\NewProject.xaml"
            this.comboBox_ProjectStatus.KeyDown += new System.Windows.Input.KeyEventHandler(this.comboBox_ProjectStatus_KeyDown);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Activo = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.Inactivo = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.Finalizado = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 10:
            this.textBox_ProjectObservations = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\NewProject.xaml"
            this.textBox_ProjectObservations.KeyDown += new System.Windows.Input.KeyEventHandler(this.textBox_ProjectObservations_KeyDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.button_SaveProject = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\NewProject.xaml"
            this.button_SaveProject.Click += new System.Windows.RoutedEventHandler(this.button_SaveProject_Click);
            
            #line default
            #line hidden
            
            #line 26 "..\..\NewProject.xaml"
            this.button_SaveProject.KeyDown += new System.Windows.Input.KeyEventHandler(this.button_SaveProject_KeyDown);
            
            #line default
            #line hidden
            return;
            case 12:
            this.button_Cancel = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\NewProject.xaml"
            this.button_Cancel.Click += new System.Windows.RoutedEventHandler(this.button_Cancel_Click);
            
            #line default
            #line hidden
            
            #line 27 "..\..\NewProject.xaml"
            this.button_Cancel.KeyDown += new System.Windows.Input.KeyEventHandler(this.button_Cancel_KeyDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

