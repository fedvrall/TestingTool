﻿#pragma checksum "..\..\..\Pages\PageBugReports.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "998A44A42F4B7F41480B9B737ADA943ACD719309C0893654135C8F6F61BDA65C"
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
    /// PageBugReports
    /// </summary>
    public partial class PageBugReports : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 11 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid mainGrid;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddBR;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditBR;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteBR;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ChoseBRFields;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border FormContainer;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CloseAdding;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox addFieldsList;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Pages\PageBugReports.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid bugReportGrid;
        
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
            System.Uri resourceLocater = new System.Uri("/Test Management System;component/pages/pagebugreports.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageBugReports.xaml"
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
            this.mainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.AddBR = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\..\Pages\PageBugReports.xaml"
            this.AddBR.Click += new System.Windows.RoutedEventHandler(this.AddBR_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditBR = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Pages\PageBugReports.xaml"
            this.EditBR.Click += new System.Windows.RoutedEventHandler(this.EditBR_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteBR = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Pages\PageBugReports.xaml"
            this.DeleteBR.Click += new System.Windows.RoutedEventHandler(this.DeleteBR_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ChoseBRFields = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\PageBugReports.xaml"
            this.ChoseBRFields.Click += new System.Windows.RoutedEventHandler(this.ChoseBRFields_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FormContainer = ((System.Windows.Controls.Border)(target));
            return;
            case 7:
            this.CloseAdding = ((System.Windows.Controls.Button)(target));
            
            #line 52 "..\..\..\Pages\PageBugReports.xaml"
            this.CloseAdding.Click += new System.Windows.RoutedEventHandler(this.CloseAdding_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.addFieldsList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 10:
            this.bugReportGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 67 "..\..\..\Pages\PageBugReports.xaml"
            this.bugReportGrid.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.bugReportGrid_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 67 "..\..\..\Pages\PageBugReports.xaml"
            this.bugReportGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.bugReportGrid_MouseDoubleClick);
            
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
            case 9:
            
            #line 59 "..\..\..\Pages\PageBugReports.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Checked += new System.Windows.RoutedEventHandler(this.CheckBox_Checked);
            
            #line default
            #line hidden
            
            #line 59 "..\..\..\Pages\PageBugReports.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Unchecked += new System.Windows.RoutedEventHandler(this.CheckBox_Unchecked);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

