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
using Test_Management_System.Entities;
using System.ComponentModel.Design;
using System.Data;
using System.Web.UI.WebControls;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewProject.xaml
    /// </summary>
    public partial class PageNewProject : Page
    {
        private List<string> attachmentsList = new List<string>();
        TextBoxChecking checking = new TextBoxChecking();
        private bool isEdit, success, success1;
        private int projectID;
        private int companyID, customerID;
        Testing_ToolEntity db = new Testing_ToolEntity();
        UserContext userContext { get; set; }
        List<string> attachmentNames;

        public PageNewProject(UserContext userContext, int projectID)
        {
            InitializeComponent();
            this.userContext = userContext;
            this.projectID = projectID;
            this.companyID = userContext.companyID;
            if (projectID == 0)
            {
                isEdit = false;
                ConfirmAdding.IsEnabled = true;
                SaveProjectChanges.IsEnabled = false;
            }
            else
            {
                isEdit = true;
                Header.Content = "Редактирование проекта";
                customerID = db.Project.Where(x => x.ProjectID == projectID).FirstOrDefault().CustomerID;

                var projInfo = db.Project.Where(x => x.ProjectID == projectID).FirstOrDefault();
                TBProjectName.Text = projInfo.ProjectName;
                dpStartDate.SelectedDate = projInfo.ProjectDateOfCreation;
                dpEndDate.SelectedDate = projInfo.ProjectDateOfDeadLine;
                TBProjectNotes.Text = projInfo.ProjectNotes;

                var custInfo = db.Customer.Where(x => x.CustomerID == customerID).FirstOrDefault();
                customerNameTB.Text = custInfo.CustomerFirstName;
                customerLastNameTB.Text = custInfo.CustomerLastName;
                customerEmailTB.Text = custInfo.CustomerEmail;
                customerPhoneTB.Text = custInfo.CustomerPhone;
                customerNotesTB.Text = custInfo.CustomerNotes;
                SaveProjectChanges.IsEnabled = true;
                ConfirmAdding.IsEnabled = false;

                var documentation = db.ProjectDocumentation.FirstOrDefault(x => x.ProjectID == projectID);
                string attString = documentation != null ? documentation.ProjectDocumentationAttachment?.ToString() : string.Empty;

                attachmentNames = attString.Split(';').Select(System.IO.Path.GetFileName).ToList();
                AttachmentsListBox.ItemsSource = attachmentNames;
            }
        }

        private void ConfirmAdding_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProject();
            if (success || success1)
                NavigationService.Navigate(new PageProjects(userContext));
        }

        private void SaveProjectChanges_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProject();
            if (success || success1)
                NavigationService.Navigate(new PageProjects(userContext));
        }

        private bool AreFieldsFilled() // поля заполнены?
        {
            bool isValid = true;

            foreach (var textBox in customerFields.Children.OfType<System.Windows.Controls.TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text) )
                {
                    textBox.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                    isValid = false;
                }
            }
            if(string.IsNullOrEmpty(TBProjectName.Text))
            {
                TBProjectName.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }

            return isValid;
        }

        private void AddOrEditProject()
        {
            var attString = string.Join(";", attachmentsList);
            DateTime? date = null;
            if (dpEndDate.DisplayDate != null)
                date = dpEndDate.SelectedDate;
            else
                date = null;

            DateTime start;
            if (dpStartDate.DisplayDate == null)
                start = DateTime.Now;
            else
                start = dpStartDate.DisplayDate;


            if (AreFieldsFilled()) // если поля заполнены
            {
                if (!isEdit) // добавление
                {
                    Header.Content = "Добавление нового проекта";
                    Customer customer = new Customer()
                    {
                        CustomerFirstName = customerNameTB.Text,
                        CustomerLastName = customerLastNameTB.Text,
                        CustomerEmail = customerEmailTB.Text,
                        CustomerPhone = customerPhoneTB.Text,
                        CustomerNotes = customerNotesTB.Text
                    };
                    try
                    {
                        db.Customer.Add(customer);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось создать заказчика");
                    }
                    finally
                    {
                        
                        //MessageBox.Show("Заказчик был добавлен");
                    }

                    int custID = db.Customer.Where(x => x.CustomerPhone == customerPhoneTB.Text).FirstOrDefault().CustomerID;

                    Project project = new Project()
                    {
                        ProjectName = TBProjectName.Text,
                        ProjectDateOfCreation = start,
                        ProjectDateOfDeadLine = date,
                        ProjectNotes = TBProjectNotes.Text,
                        CompanyID = companyID,
                        CustomerID = custID
                    };

                    try
                    {
                        db.Project.Add(project);
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось создать проект");
                        success = false;
                    }
                    finally
                    {
                        MessageBox.Show("Проект был добавлен");
                        success = true;
                    }

                    if (AttachmentsListBox.Items.Count > 0)
                    {
                        ProjectDocumentation projectDocumentation = new ProjectDocumentation()
                        {
                            ProjectID = projectID,
                            ProjectDocumentationAttachment = attString
                        };
                        try
                        {
                            db.ProjectDocumentation.Add(projectDocumentation);
                            db.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось добавить документацию");
                            success1 = false;
                        }
                        finally
                        {
                            MessageBox.Show("Документация была добавлена");
                            success1 = true;
                        }
                    }
                }
                else // редактирование
                {
                    try
                    {
                        var editCust = db.Customer.Find(customerID);
                        editCust.CustomerFirstName = customerNameTB.Text;
                        editCust.CustomerLastName = customerLastNameTB.Text;
                        editCust.CustomerEmail = customerEmailTB.Text;
                        editCust.CustomerPhone = customerPhoneTB.Text;
                        editCust.CustomerNotes = customerNotesTB.Text;
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать заказчика");
                    }
                    finally
                    {
                       // MessageBox.Show("Заказчик отредактирован");
                    }

                    try
                    {
                        var editProj = db.Project.Find(projectID);
                        editProj.ProjectName = TBProjectName.Text;
                        editProj.ProjectDateOfCreation = dpStartDate.DisplayDate;
                        editProj.ProjectDateOfDeadLine = date;
                        editProj.ProjectNotes = TBProjectNotes.Text;
                        editProj.CompanyID = companyID;
                        editProj.CustomerID = customerID;
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать проект");
                        success = false;
                    }
                    finally
                    {
                        MessageBox.Show("Проект отредактирован");
                        success = true;
                    }

                    try
                    {
                        int? projectDocID = db.ProjectDocumentation.Where(x => x.ProjectID == projectID).FirstOrDefault()?.ProjectDocumentationID;
                        if (projectDocID != null)
                        {
                            var editProjDoc = db.ProjectDocumentation.Find(projectDocID);
                            editProjDoc.ProjectDocumentationAttachment = attString;
                            editProjDoc.ProjectID = projectID;
                        }
                        else
                        {
                            ProjectDocumentation projectDocumentation = new ProjectDocumentation()
                            {
                                ProjectID = projectID,
                                ProjectDocumentationAttachment = attString
                            };
                            db.ProjectDocumentation.Add(projectDocumentation);
                        }
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать вложения");
                        success1 = false;
                    }
                    finally
                    {
                        success1 = true;
                        //MessageBox.Show("Вложения отредактированы");
                    }
                }
            }

            else
                MessageBox.Show("Пожалуйста, заполните поля!");

        }

        private void ExitWithoutSave_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
                NavigationService.Navigate(new PageProjects(userContext));
            else return;
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
            System.Windows.Controls.Button removeButton = (System.Windows.Controls.Button)sender;
            string fileName = removeButton.DataContext as string;
            string filePath = attachmentsList.FirstOrDefault(path => System.IO.Path.GetFileName(path) == fileName);
            attachmentsList.Remove(filePath);
            attachmentNames.Remove(fileName);
            AttachmentsListBox.ItemsSource = null;
            AttachmentsListBox.ItemsSource = attachmentNames;
        }

        private void customerPhoneTB_LostFocus(object sender, RoutedEventArgs e)
        {
            checking.CheckPhoneValue(customerPhoneTB.Text);
        }

        private void customerEmailTB_LostFocus(object sender, RoutedEventArgs e)
        {
            checking.CheckEmailValue(customerEmailTB.Text);
        }

        private void customerNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(customerNameTB.Text) != null)
                customerNameTB.Text = checking.CheckOnlyCirSymb(customerNameTB.Text);
        }

        private void customerLastNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(customerLastNameTB.Text) != null)
                customerLastNameTB.Text = checking.CheckOnlyCirSymb(customerLastNameTB.Text);

        }
    }
}
