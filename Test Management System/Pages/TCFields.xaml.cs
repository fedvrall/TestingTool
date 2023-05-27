using System;
using System.Collections.Generic;
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

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для TCFields.xaml
    /// </summary>
    public partial class TCFields : Window
    {
        public event EventHandler<FieldsSelectedEventArgs> FieldsSelected;
        public class FieldsSelectedEventArgs : EventArgs
        {
            public bool IsSeveritySelected { get; set; }
            public bool IsPrioritySelected { get; set; }
            public bool IsTypeSelected { get; set; }
            public bool IsBehaviorSelected { get; set; }
            public bool IsDescriptionSelected { get; set; }
            public bool IsCreationDateSelected { get; set; }
            public bool IsExecutionDateSelected { get; set; }
            public bool IsPreconditionSelected { get; set; }
            public bool IsPostconditionSelected { get; set; }
            public bool IsAttachmentSelected { get; set; }
            public bool IsEnvironmentSelected { get; set; }
            public bool IsTestDataSelected { get; set; }
        }
        public TCFields()
        {
            InitializeComponent();
        }

        private void SaveTCFields_Click(object sender, RoutedEventArgs e)
        {
            FieldsSelectedEventArgs args = new FieldsSelectedEventArgs
            {
                IsSeveritySelected = severityCheckBox.IsChecked ?? false,
                IsPrioritySelected = priorityCheckBox.IsChecked ?? false,
                IsTypeSelected = typeCheckBox.IsChecked ?? false,
                IsBehaviorSelected = behaviorCheckBox.IsChecked ?? false,
                IsDescriptionSelected = descriptionCheckBox.IsChecked ?? false,
                IsCreationDateSelected = creationDateCheckBox.IsChecked ?? false,
                IsExecutionDateSelected = executionDateCheckBox.IsChecked ?? false,
                IsPreconditionSelected = preconditionCheckBox.IsChecked ?? false,
                IsPostconditionSelected = postconditionCheckBox.IsChecked ?? false,
                IsAttachmentSelected = attachmentCheckBox.IsChecked ?? false,
                IsEnvironmentSelected = environmentCheckBox.IsChecked ?? false,
                IsTestDataSelected = testdataCheckBox.IsChecked ?? false,
            };

            FieldsSelected?.Invoke(this, args);
        }

        private void CancelTCFields_Click(object sender, RoutedEventArgs e)
        {

            Close();
        }
    }
}
