﻿#pragma checksum "..\..\..\Pages\PageTestSuites.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "2BED4892DF3DFF135A10482A3EEC085E6549D0F954A07CA88D04FA8FBEDE251C"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using Test_Management_System.Pages;


namespace Test_Management_System.Pages {
    
    
    /// <summary>
    /// PageTestSuites
    /// </summary>
    public partial class PageTestSuites : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 20 "..\..\..\Pages\PageTestSuites.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgvTestSuites;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\Pages\PageTestSuites.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button NewTestSuiteButton;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\Pages\PageTestSuites.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditTestSuite;
        
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
            System.Uri resourceLocater = new System.Uri("/Test Management System;component/pages/pagetestsuites.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageTestSuites.xaml"
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
            this.dgvTestSuites = ((System.Windows.Controls.DataGrid)(target));
            
            #line 20 "..\..\..\Pages\PageTestSuites.xaml"
            this.dgvTestSuites.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgvTestSuites_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.NewTestSuiteButton = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Pages\PageTestSuites.xaml"
            this.NewTestSuiteButton.Click += new System.Windows.RoutedEventHandler(this.NewTestSuiteButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.EditTestSuite = ((System.Windows.Controls.Button)(target));
            
            #line 54 "..\..\..\Pages\PageTestSuites.xaml"
            this.EditTestSuite.Click += new System.Windows.RoutedEventHandler(this.EditTestSuite_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 2:
            
            #line 31 "..\..\..\Pages\PageTestSuites.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.WatchTestCases_Click);
            
            #line default
            #line hidden
            break;
            case 3:
            
            #line 36 "..\..\..\Pages\PageTestSuites.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.EditTestSuite_Click);
            
            #line default
            #line hidden
            break;
            case 4:
            
            #line 41 "..\..\..\Pages\PageTestSuites.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteTestSuite_Click);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

