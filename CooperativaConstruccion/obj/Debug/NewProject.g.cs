﻿#pragma checksum "..\..\NewProject.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC9C5B0766DDCC42236104E9CCE7A387"
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
        internal System.Windows.Controls.TextBox textBox_ProjectStartBudjet;
        
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
        
        
        #line 24 "..\..\NewProject.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button button_SaveProject;
        
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
            this.textBox_ProjectName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.textBox_ProjectStartBudjet = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.datePicker_ProjectStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 4:
            this.datePicker_ProjectEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 5:
            this.comboBox_ProjectStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.Activo = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 7:
            this.Inactivo = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 8:
            this.Finalizado = ((System.Windows.Controls.ComboBoxItem)(target));
            return;
            case 9:
            this.button_SaveProject = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\NewProject.xaml"
            this.button_SaveProject.Click += new System.Windows.RoutedEventHandler(this.CreateProject);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 25 "..\..\NewProject.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Close);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

