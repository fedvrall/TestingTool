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

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageNewProject.xaml
    /// </summary>
    public partial class PageNewProject : Page
    {
        private List<string> attachmentsList = new List<string>();
        TextBoxChecking checking = new TextBoxChecking();
        private bool isEdit;
        private int projectID;
        private int companyID;
        Testing_ToolEntity db = new Testing_ToolEntity();
        UserContext userContext { get; set; }

        public PageNewProject(UserContext userContext, int projectID)
        {
            InitializeComponent();
            this.projectID = projectID;
            this.companyID = userContext.companyID;
            if (projectID == 0)
                isEdit = false;
            else
                isEdit = true;
        }

        private void ConfirmAdding_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProject();
        }

        private void SaveProjectChanges_Click(object sender, RoutedEventArgs e)
        {
            AddOrEditProject();
        }

        private bool AreFieldsFilled()
        {
            // Ограничения полей по длине
            // Тут нет полей, относящихся к проекту
            bool isValid = true;

            foreach (var textBox in customerFields.Children.OfType<TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Style = (Style)FindResource("InvalidFieldStyle");
                    isValid = false;
                }
                else
                {
                    textBox.Style = (Style)FindResource("ClassicTB");
                }
            }

            return isValid;
        }

        private void AddOrEditProject()
        {
            var attString = string.Join(";", attachmentsList);
            
            if (AreFieldsFilled())
            {
                if (!isEdit)
                {
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
                        MessageBox.Show("Заказчик был добавлен");
                    }

                    int custID = db.Customer.Where(x => x.CustomerPhone == customerPhoneTB.Text).FirstOrDefault().CustomerID;

                    Project project = new Project()
                    {
                        ProjectName = TBProjectName.Text,
                        ProjectDateOfCreation = dpStartDate.DisplayDate,
                        ProjectDateOfDeadLine = dpEndDate.DisplayDate,
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
                    }
                    finally
                    {
                        MessageBox.Show("Проект был добавлен");
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
                        }
                        finally
                        {
                            MessageBox.Show("Документация была добавлена");
                        }
                    }
                }
                else
                {
                    int customerID = db.Project.Where(x => x.ProjectID == projectID).FirstOrDefault().CustomerID;

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
                        MessageBox.Show("Заказчик отредактирован");
                    }

                    try
                    {
                        var editProj = db.Project.Find(projectID);
                        editProj.ProjectName = TBProjectName.Text;
                        editProj.ProjectDateOfCreation = dpStartDate.DisplayDate;
                        editProj.ProjectDateOfDeadLine = dpEndDate.DisplayDate;
                        editProj.ProjectNotes = TBProjectNotes.Text;
                        editProj.CompanyID = companyID;
                        editProj.CustomerID = customerID;
                        db.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать проект");
                    }
                    finally
                    {
                        MessageBox.Show("Проект отредактирован");
                    }

                    try
                    {
                        var projectDocID = db.ProjectDocumentation.Where(x => x.ProjectID == projectID).FirstOrDefault().ProjectDocumentationID;
                        if (projectDocID > 0)
                        {
                            var editProjDoc = db.ProjectDocumentation.Find(projectDocID);
                            editProjDoc.ProjectDocumentationAttachment = attString;
                            db.SaveChanges();
                        }
                        else
                        {
                            ProjectDocumentation projectDocumentation = new ProjectDocumentation()
                            {
                                ProjectID = projectID,
                                ProjectDocumentationAttachment = attString
                            };
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось отредактировать вложения");
                    }
                    finally
                    {
                        MessageBox.Show("Вложения отредактирован");
                    }

                }
            }

            else
                MessageBox.Show("Пожалуйста, заполните поля!");

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
                
            }
            else
                customerNameTB.Text = string.Empty;
        }

        private void customerLastNameTB_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(customerLastNameTB.Text) != null)
            {
                customerLastNameTB.Text = checking.CheckOnlyCirSymb(customerLastNameTB.Text);
                //customerLastNameTB.Text = string.Empty;
            }
            else
                customerLastNameTB.Text = string.Empty;
        }
    }
}
