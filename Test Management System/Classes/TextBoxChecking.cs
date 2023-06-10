using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Test_Management_System.Classes
{
    public class TextBoxChecking
    {
        public bool CheckRuSymb(string input) // Проверка символов русского алфавита
        {
            var rus = new Regex(@"[а-яА-ЯёЁ -]");
            if (!rus.IsMatch(input))
            {
                MessageBox.Show("Пожалуйста, вводите данные на русском языке!");
                return false;
            }
            else return true;

        }

        public bool CheckLatSymb(string input) // Проверка символов латинского алфавита
        {
            var lat = new Regex(@"[a-zA-Z0-9]");
            if (!lat.IsMatch(input))
            {
                MessageBox.Show("Пожалуйста, используйте только латиницу и цифры!");
                return false;
            }
            else return true;
        }


        public string CheckOnlyCirSymb(string input) // Проверка символов киррилицы
        {
            var rus = new Regex(@"[а-яА-ЯёЁ]");
            string result = null;
            if (!rus.IsMatch(input)) 
                MessageBox.Show("Пожалуйста, используйте только кириллицу!");
            else
                result = input.Substring(0, 1).ToUpper() + input.Substring(1);
            return result;
        }

        public bool CheckEmailValue(string input) // Проверка ввода почты
        {
            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
            Match isMatch = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
            if (!isMatch.Success)
            {
                MessageBox.Show("Введите действующий Email, пожалуйста!");
                return false;
            }
            else
                return true;
        }

        public bool CheckPhoneValue(string input) // Проверка ввода телефона
        {
            Regex regexTelephone = new Regex(@"^[+]{0,1}[0-9]{11}");
            if (!regexTelephone.IsMatch(input))
            {
                MessageBox.Show("Обратите внимание, что вы вводите номер телефона. Он состоит из знака + и 11 цифр");
                return false;
            }
            else return true;
        }

    }
}
