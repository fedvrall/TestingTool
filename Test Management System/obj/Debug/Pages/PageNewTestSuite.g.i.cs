﻿#pragma checksum "..\..\..\Pages\PageNewTestSuite.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "531825F0F5DC57FB0195E813607E84BED9AC5470B9BDFFAD5F731A8A7CAFCA68"
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
    /// PageNewTestSuite
    /// </summary>
    public partial class PageNewTestSuite : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBtestSuiteSummary;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBTestSuiteDescription;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBTestSuiteLabel;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TBTestSuitePreconditions;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboTestSuiteParentID;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveTestSuite;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\PageNewTestSuite.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackToTestSuitePageButton;
        
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
            System.Uri resourceLocater = new System.Uri("/Test Management System;component/pages/pagenewtestsuite.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageNewTestSuite.xaml"
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
            this.TBtestSuiteSummary = ((System.Windows.Controls.TextBox)(target));
            
            #line 25 "..\..\..\Pages\PageNewTestSuite.xaml"
            this.TBtestSuiteSummary.LostFocus += new System.Windows.RoutedEventHandler(this.TBtestSuiteSummary_LostFocus);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TBTestSuiteDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TBTestSuiteLabel = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.TBTestSuitePreconditions = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.ComboTestSuiteParentID = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.SaveTestSuite = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\Pages\PageNewTestSuite.xaml"
            this.SaveTestSuite.Click += new System.Windows.RoutedEventHandler(this.SaveTestSuite_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackToTestSuitePageButton = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Pages\PageNewTestSuite.xaml"
            this.BackToTestSuitePageButton.Click += new System.Windows.RoutedEventHandler(this.BackToTestSuitePageButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

