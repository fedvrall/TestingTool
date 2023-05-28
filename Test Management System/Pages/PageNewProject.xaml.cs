using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
using System.IO;
using Test_Management_System.Classes;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewProject.xaml
    /// </summary>
    public partial class PageNewProject : Page
    {
        private List<string> attachmentsList = new List<string>();
        TextBoxChecking checking = new TextBoxChecking();
        public PageNewProject()
        {
            InitializeComponent();
        }

        private void ConfirmAdding_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveProjectChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ExitWithoutSave_Click(object sender, RoutedEventArgs e)
        {
            // предупреждение только если есть несохранённые изменения
/*            if()
            var result = MessageBox.Show("", "", MessageBoxButton.YesNo);*/
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

        private void RemoveAttachment_Click(object sender, RoutedEventArgs e)
        {
            Button removeButton = (Button)sender;
            string fileName = removeButton.DataContext as string;
            string filePath = attachmentsList.FirstOrDefault(path => System.IO.Path.GetFileName(path) == fileName);
            attachmentsList.Remove(filePath);
            AttachmentsListBox.Items.Remove(fileName);
        }

        private void customerPhoneTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!checking.CheckPhoneValue(customerPhoneTB.Text))
            {
                customerPhoneTB.Text = string.Empty;
            }   
        }

        private void customerEmailTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (!checking.CheckEmailValue(customerEmailTB.Text))
            {
                customerEmailTB.Text = string.Empty;
            }
        }

        private void customerNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(customerNameTB.Text) != null)
            {
                customerNameTB.Text = checking.CheckOnlyCirSymb(customerNameTB.Text);
                customerEmailTB.Text = string.Empty;
            }
        }

        private void customerLastNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(customerLastNameTB.Text) != null)
            {
                customerLastNameTB.Text = checking.CheckOnlyCirSymb(customerLastNameTB.Text);
                customerLastNameTB.Text = string.Empty;
            }
        }
    }
}
