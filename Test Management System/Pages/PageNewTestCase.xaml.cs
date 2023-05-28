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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Entities;
using Test_Management_System.Classes;
using Microsoft.Win32;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewTestCase.xaml
    /// </summary>
    public partial class PageNewTestCase : Page
    {
        private List<string> attachmentsList = new List<string>();

        //PriorityColorConverter cc = new PriorityColorConverter();
        public PageNewTestCase()
        {
            InitializeComponent();
            Testing_ToolEntity db = new Testing_ToolEntity();
            ComboStatusTC.ItemsSource = db.TestCaseStatus.ToList();
            ComboBehaviorTC.ItemsSource = db.TestCaseBehavior.ToList();
            ComboPriorityTC.ItemsSource = db.TestCasePriority.ToList();
            ComboTypeTC.ItemsSource = db.TestCaseType.ToList();
            ComboSeverityTC.ItemsSource = db.TestCaseSeverity.ToList();
        }

        private void SaveAndBackToTCPageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveAndAddTCButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NoSaveBackToTestCasePageButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveAttachment_Click(object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button)sender;
            string fileName = removeButton.DataContext as string;
            string filePath = attachmentsList.FirstOrDefault(path => System.IO.Path.GetFileName(path) == fileName);
            attachmentsList.Remove(filePath);
            AttachmentsListBox.Items.Remove(fileName);
        }

        private void AddAttachment_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                string fileName = System.IO.Path.GetFileName(filePath);
                attachmentsList.Add(filePath);
                AttachmentsListBox.Items.Add(fileName);
            }
        }
    }
}
