﻿using ControlzEx.Standard;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.UI.WebControls.WebParts;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Test_Management_System.Classes;
using Test_Management_System.Entities;

namespace Test_Management_System.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageEditUsers.xaml
    /// </summary>
    public partial class PageEditUsers : Page
    {
        private bool isEditUser = false;
        private bool isAddUser = false;
        private int userID, companyID, currUser;
        TextBoxChecking checking = new TextBoxChecking();
        Testing_ToolEntity db = new Testing_ToolEntity();

        public UserContext UserContext { get; set; }
        public PageEditUsers(UserContext userContext)
        {
            this.UserContext = userContext;
            this.companyID = userContext.companyID;
            currUser = userContext.userId;
            InitializeComponent();

            dgvUsers.ItemsSource = db.Userinfo.Where(x=> x.CompanyID == companyID).ToList();
            RoleComboBox.Items.Clear();
            RoleComboBox.Items.Add("");

            List<Role> roles = db.Role.ToList();
            foreach(var item in roles)
            {
                RoleComboBox.Items.Add(item);
            }
            NewPassBlock.Visibility = Visibility.Hidden;           
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            LastNameTextBox.Text = "";
            FirstNameTextBox.Text = "";
            LoginTextBox.Text = "";
            RoleComboBox.Text = "";
            LastNameTextBox.IsReadOnly = false;
            FirstNameTextBox.IsReadOnly = false;
            LoginTextBox.IsReadOnly = false;
            RoleComboBox.IsReadOnly = false;

            PassLabel.Visibility = Visibility.Collapsed;
            PassBox.Visibility = Visibility.Collapsed;
            PassTextBox.Visibility = Visibility.Collapsed;
            ShowCurrentPass.Visibility = Visibility.Collapsed;

            NewPassBlock.Visibility = Visibility.Visible;
            reminder1.Visibility = Visibility.Visible;
            reminder2.Visibility = Visibility.Visible;
            reminder3.Visibility = Visibility.Visible;
            AddButton.IsEnabled = false;
            SaveButton.IsEnabled = true;

            isAddUser = true;
            isEditUser = false;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            LastNameTextBox.IsReadOnly = false;
            FirstNameTextBox.IsReadOnly = false;
            LoginTextBox.IsReadOnly = false;
            RoleComboBox.IsReadOnly = false;
            ChangePass.Visibility = Visibility.Visible;
            SaveButton.IsEnabled = true;
            AddButton.IsEnabled = false;
            EditButton.IsEnabled = false;
            isAddUser = false;
            isEditUser = true;
        }

        private bool AreFieldsFilled()
        {
            bool isValid = true;

            foreach (var textBox in userInfo1.Children.OfType<System.Windows.Controls.TextBox>())
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                    isValid = false;
                }
            }
            if (string.IsNullOrEmpty(LoginTextBox.Text))
            {
                LoginTextBox.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }
            if (string.IsNullOrEmpty(NewPass.Password) || string.IsNullOrEmpty(NewPassTextBox.Text))
            {
                NewPassTextBox.Style = (System.Windows.Style)FindResource("InvalidFieldStyle");
                isValid = false;
            }

            if(RoleComboBox.SelectedIndex == -1 || RoleComboBox.SelectedIndex == 0)
                isValid = false;
            return isValid;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (currUser == userID)
            {
                MessageBox.Show("Вы не можете удалить самого себя");

            }
            else
            {
                var dialog = MessageBox.Show("Вы действительно хотите удалить выбранного пользователя? Вам придётся выбрать пользователя, для передачи ему всех текущих наработок.", "Удалить?", MessageBoxButton.YesNo);
                if (dialog == MessageBoxResult.Yes)
                {
                    WindowChoseNewUser newUser = new WindowChoseNewUser();
                    if (newUser.ShowDialog() == true)
                    {
                        Userinfo selectedUser = newUser.SelectedUser;
                        db.TestCase.Where(t => t.CreatorUserID == userID).ToList().ForEach(t => t.CreatorUserID = selectedUser.UserID);
                        db.TestCase.Where(t => t.ExecutorUserID == userID).ToList().ForEach(t => t.ExecutorUserID = selectedUser.UserID);
                        db.BugReport.Where(t => t.UserID == userID).ToList().ForEach(t => t.UserID = selectedUser.UserID);
                        db.CheckList.Where(t => t.UserID == userID).ToList().ForEach(t => t.UserID = selectedUser.UserID);
                        db.CheckListItem.Where(t => t.UserID == userID).ToList().ForEach(t => t.UserID = selectedUser.UserID);

                        try
                        {
                            db.SaveChanges();
                        }
                        catch
                        {
                            MessageBox.Show("Не удалось изменить связи");
                        }

                        finally
                        {
                            var userToDelete = db.Userinfo.Find(userID);
                            int projectUser;
                            ProjectUser projectUserToDelete;
                            var selprojectUser = db.ProjectUser.FirstOrDefault(x => x.UserID == userID);

                            if (selprojectUser != null && selprojectUser.ProjectUserID != null)
                            {
                                projectUser = db.ProjectUser.Where(x => x.UserID == userID).FirstOrDefault().ProjectUserID;
                                projectUserToDelete = db.ProjectUser.Find(projectUser);
                                db.ProjectUser.Remove(projectUserToDelete);
                            }

                            db.Userinfo.Remove(userToDelete);
                            db.SaveChanges();
                            MessageBox.Show("Связи успешно обновлены для выбранного пользователя: \n " + selectedUser.LastName + " " + selectedUser.FirstName + ", " +
                                "\nпользователь " + userToDelete.LastName + " " + userToDelete.FirstName + " успешно удалён.");
                            RefreshGrid();
                        }
                    }
                }
                else
                    return;
            }    
        }

        private void RefreshGrid()
        {
            dgvUsers.ItemsSource = null;
            var user = db.Userinfo.Where(x => x.CompanyID == companyID).ToList();
            dgvUsers.ItemsSource = user;
            PassBox.Clear();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (ShowCurrentPass.IsChecked == true)
            {
                PassTextBox.Text = PassBox.Password; // показан
                PassTextBox.Visibility = Visibility.Visible; 
                PassBox.Visibility = Visibility.Collapsed; 
            }

            if(ShowNewPass.IsChecked == true)
            {
                NewPassTextBox.Text = NewPass.Password;
                NewPassAgreementTextBox.Text = NewPassAgreement.Password;

                NewPassTextBox.Visibility = Visibility.Visible;
                NewPassAgreementTextBox.Visibility = Visibility.Visible;
                NewPass.Visibility = Visibility.Collapsed;
                NewPassAgreement.Visibility = Visibility.Collapsed;
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (ShowCurrentPass.IsChecked == false)
            {
                PassBox.Password = PassTextBox.Text;
                PassTextBox.Visibility = Visibility.Collapsed;
                PassBox.Visibility = Visibility.Visible;
            }

            if (ShowNewPass.IsChecked == false)
            {
                NewPass.Password = NewPassTextBox.Text;
                NewPassAgreement.Password = NewPassAgreementTextBox.Text;

                NewPassTextBox.Visibility = Visibility.Collapsed;
                NewPassAgreementTextBox.Visibility = Visibility.Collapsed;
                NewPass.Visibility = Visibility.Visible;
                NewPassAgreement.Visibility = Visibility.Visible;
            }
        }

        private void ChangePass_Click(object sender, RoutedEventArgs e)
        {
            NewPassBlock.Visibility = Visibility.Visible;
            PassBox.Visibility=Visibility.Collapsed;
            PassTextBox.Visibility=Visibility.Collapsed;
            ShowCurrentPass.Visibility = Visibility.Collapsed;
            SaveButton.IsEnabled = true;
            reminder1.Visibility = Visibility.Visible;
            reminder2.Visibility = Visibility.Visible;
            reminder3.Visibility = Visibility.Visible;
            PassLabel.Visibility = Visibility.Collapsed;
        }

        private void ClearFields()
        {
            LoginTextBox.Text = "";
            FirstNameTextBox.Text = "";
            LastNameTextBox.Text = "";

            NewPass.Password = "";
            NewPassTextBox.Text = "";
            NewPassAgreement.Password = "";
            NewPassAgreementTextBox.Text = "";

            NewPassBlock.Visibility = Visibility.Collapsed;
            reminder1.Visibility = Visibility.Collapsed;
            reminder2.Visibility = Visibility.Collapsed;
            reminder3.Visibility = Visibility.Collapsed;

            RoleComboBox.SelectedIndex = 0;

            ShowNewPass.IsChecked = false;

            AddButton.IsEnabled = true;
            SaveButton.IsEnabled = false;

            PassLabel.Visibility = Visibility.Visible;
            PassBox.Visibility = Visibility.Visible;
            ShowCurrentPass.Visibility = Visibility.Visible;
            PassTextBox.Visibility = Visibility.Collapsed;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (AreFieldsFilled())
            {
                string newUserPass;
                if (NewPassAgreement.Visibility == Visibility.Visible)
                    newUserPass = NewPassAgreement.Password;
                else
                    newUserPass = NewPassAgreementTextBox.Text;
                if(IsIdenticalPass())
                {
                    if (isAddUser)
                    {
                        if (LoginTextBox.Text != "" && FirstNameTextBox.Text != "" && LastNameTextBox.Text != "" && NewPass.Password != "" && RoleComboBox.SelectedIndex != 0)
                        {
                            Userinfo user = new Userinfo
                            {
                                FirstName = FirstNameTextBox.Text.ToString(),
                                LastName = LastNameTextBox.Text.ToString(),
                                Login = LoginTextBox.Text.ToString(),
                                Password = newUserPass,
                                RoleID = RoleComboBox.SelectedIndex,
                                CompanyID = UserContext.companyID
                            };

                            try
                            {
                                db.Userinfo.Add(user);
                                db.SaveChanges();
                            }
                            catch
                            {
                                MessageBox.Show("Пользователь не был добавлен");
                            }
                            finally
                            {
                                MessageBox.Show("Пользователь был добавлен");
                                RefreshGrid();
                                ClearFields();
                            }
                        }
                        else
                            MessageBox.Show("Вы заполнили не все поля! Пожалуйста, заполните все поля и попробуйте ещё раз.");
                    }
                    if (isEditUser)
                    {
                        var dialog = MessageBox.Show("Вы действительно хотите отредактировать данного пользователя?", "Изменить?", MessageBoxButton.YesNo);
                        if (dialog == MessageBoxResult.Yes)
                        {
                            var findUser = db.Userinfo.Find(userID);
                            findUser.FirstName = FirstNameTextBox.Text.ToString();
                            findUser.LastName = LastNameTextBox.Text.ToString();
                            findUser.RoleID = RoleComboBox.SelectedIndex;
                            findUser.Login = LoginTextBox.Text.ToString();
                            findUser.Password = NewPassAgreement.Password.ToString();
                            findUser.CompanyID = findUser.CompanyID;
                            try
                            {
                                db.SaveChanges();
                            }
                            catch
                            {
                                MessageBox.Show("Данные пользователя не были сохранены.");
                            }
                            finally
                            {
                                MessageBox.Show("Данные пользователя изменены.");
                                RefreshGrid();
                                ClearFields();
                            }
                        }
                        else
                            return;
                    }
                }
            }
            else
                MessageBox.Show("Заполните поля");
        
        }

        private bool IsIdenticalPass()
        {
            string pass1 = NewPassTextBox.Text.ToString();
            string pass2 = NewPassAgreementTextBox.Text.ToString();

            if (NewPass.Password == NewPassAgreement.Password || pass1 == pass2)
                return true;
            else
            {
                MessageBox.Show("Пароли не совпадают");
                return false;
            }
        }

        private bool IsSuitablePass(string pass)
        {
            var num = new Regex(@"[0-9]");
            var sym = new Regex(@"[!@#$%^_*()/.-]");
            var up = new Regex(@"[A-Z]");
            bool noPopular = false;
            string[] badPass = new string[]
                {
                   "123456", "123", "qwerty", "111", "234", "345", "456", "567", "678", "765", "876", "543", "432", "666",  "777", "321", "789", "222", "333",  "444", "000", "654", "555", "888",
                    "vkontakte", "ghbdtn", "gfhjkm", "159753",  "qazwsx", "1q2w3e", "112233", "121212", "qq18ww899", "987", "zxcvbn", 
                    "001", "002", "003", "004", "005", "006", "007", "008", "009", "col", "314",
                    "zxcvbnm", "999", "samsung", "1q2w3e4r",  "159357", "131313", "qazwsxedc",  "222222", "asdfgh", "zinch",
                    "asdf", "4815162342", "knopka",  "1q2w3e4r5t", "iloveyou", "vfhbyf", "marina", "asd",
                    "password", "qwe", "10203", "yfnfif", "cjkysirj", "nikita", "vfrcbv", "k.,jdm",  "natasha",
                    "fylhtq", "q1w2e3", "stalker",  "q1w2e3r4", "nastya", "147258369", "147258", "fyfcnfcbz", "1qaz2wsx", "andrey",
                    "147852", "genius", "sergey",  "232323",  "fktrcfylh", "spartak", "admin", "azerty", "lol", "easytocrack1", "hello",
                    "saravn", "holysh!t",  "Test", "tundra_cool2",  "dragon", "thomas", "killer", "root",  "pass", "master", "aaa", "monkey", "daniel",
                    "changeme", "computer", "jessica", "letmein", "mirage", "loulou", "superman", "shadow", "secret",
                    "sophie", "kikugalanetroot", "doudou", "liverpool", "hallo", "sunshine", "charlie", "parola", "100827092", "/", "michael", "andrew",
                    "fuckyou", "matrix", "cjmasterinf", "internet", "hallo123", "eminem", "demo", "gewinner", "pokemon", "abcd1234", "guest", "ngockhoa", "martin", "sandra",
                    "hejsan", "george",  "lollipop", "lovers", "q1q1q1", "tecktonik", "naruto",
                    "maximius", "123abc", "baseball1", "football1", "soccer", "princess", "test1",
                    "slipknot", "nokia", "super", "star",  "135790", "159951", "212121", "zzzzzz", "121314", "134679", "142536", "19921992",
                    "753951", "7007",  "19951995",  "qwaszx", "zaqwsx",  "qwert", "iloveu"
                };
            
            foreach (var bp in badPass)
            {
                if (pass.ToLower().Contains(bp.ToLower()))
                {
                    noPopular = false;
                    break;
                }
                else
                    noPopular = true;
            }
            if(num.IsMatch(pass) && sym.IsMatch(pass) && up.IsMatch(pass) && pass.Length >= 8 && pass.Length < 20 && noPopular == true)
                return true;
            else
            {
                MessageBox.Show("Пароль не соответствует требованиям");
                return false;
            }
        }

        private void NewPassAgreement_LostFocus(object sender, RoutedEventArgs e)
        {
            IsIdenticalPass();
        }

        private void NewPass_LostFocus(object sender, RoutedEventArgs e)
        {
            IsSuitablePass(NewPass.Password.ToString());
        }

        private void NewPassTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if(NewPassTextBox.Visibility == Visibility.Visible)
                IsSuitablePass(NewPassTextBox.Text.ToString());
        }

        private void dgvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgvUsers.SelectedItem != null)
            {
                userID = ((Userinfo)dgvUsers.SelectedItem).UserID;
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                PassTextBox.Text = db.Userinfo.Where(x=>x.UserID == userID).FirstOrDefault().Password.ToString();
                PassBox.Password = db.Userinfo.Where(x => x.UserID == userID).FirstOrDefault().Password.ToString();
            }
            else
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }
        }

        private void FirstNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(FirstNameTextBox.Text) != null)
            {
                FirstNameTextBox.Text = checking.CheckOnlyCirSymb(FirstNameTextBox.Text);
            }
            if (FirstNameTextBox.Text.Length >= 50)
                MessageBox.Show("Слишком длинное имя");
        }

        private void LastNameTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (checking.CheckOnlyCirSymb(LastNameTextBox.Text) != null)
            {
                LastNameTextBox.Text = checking.CheckOnlyCirSymb(LastNameTextBox.Text);
            }
            if (LastNameTextBox.Text.Length >= 50)
                MessageBox.Show("Слишком длинная фамилия");
        }

        private void NewPassAgreementTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            IsIdenticalPass();
        }

        private void LoginTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            checking.CheckLatSymb(LoginTextBox.Text.ToString());
            if (LoginTextBox.Text.Length >= 20)
                MessageBox.Show("Сократите, пожалуйста, логин!");
        }
    }
}
