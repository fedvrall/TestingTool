﻿#pragma checksum "..\..\..\Pages\PageCheckListItems.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "420B6F4BBB302C7A1F4F8559E7063800459E29AAA7181178DC54451B75354812"
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
    /// PageCheckListItems
    /// </summary>
    public partial class PageCheckListItems : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 30 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxDescription;
        
        #line default
        #line hidden
        
        
        #line 34 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxStatus;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboBoxPriority;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBoxComment;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox AttachmentsListBox;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddChecklistItem;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid CheckListGrid;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExecuteList;
        
        #line default
        #line hidden
        
        
        #line 116 "..\..\..\Pages\PageCheckListItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExitFromAddingCheckListItem;
        
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
            System.Uri resourceLocater = new System.Uri("/Test Management System;component/pages/pagechecklistitems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\PageCheckListItems.xaml"
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
            this.TextBoxDescription = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.ComboBoxStatus = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.ComboBoxPriority = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            this.TextBoxComment = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AttachmentsListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 7:
            
            #line 53 "..\..\..\Pages\PageCheckListItems.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.AddAttachmentToCheckList_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.AddChecklistItem = ((System.Windows.Controls.Button)(target));
            
            #line 55 "..\..\..\Pages\PageCheckListItems.xaml"
            this.AddChecklistItem.Click += new System.Windows.RoutedEventHandler(this.AddChecklistItem_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.CheckListGrid = ((System.Windows.Controls.DataGrid)(target));
            
            #line 56 "..\..\..\Pages\PageCheckListItems.xaml"
            this.CheckListGrid.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.CLListView_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 11:
            this.ExecuteList = ((System.Windows.Controls.Button)(target));
            
            #line 115 "..\..\..\Pages\PageCheckListItems.xaml"
            this.ExecuteList.Click += new System.Windows.RoutedEventHandler(this.ExecuteList_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.ExitFromAddingCheckListItem = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\Pages\PageCheckListItems.xaml"
            this.ExitFromAddingCheckListItem.Click += new System.Windows.RoutedEventHandler(this.ExitFromAddingCheckListItem_Click);
            
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
            case 6:
            
            #line 48 "..\..\..\Pages\PageCheckListItems.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RemoveAttachment_Click);
            
            #line default
            #line hidden
            break;
            case 10:
            
            #line 106 "..\..\..\Pages\PageCheckListItems.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.DeleteCheckListItem);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}

