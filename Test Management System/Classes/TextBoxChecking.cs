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
        public void CheckRuSymb(string input) // Проверка символов русского алфавита
        {
            var rus = new Regex(@"[а-яА-ЯёЁ -]");
            if (!rus.IsMatch(input))
                MessageBox.Show("Пожалуйста, вводите данные на русском языке!");
        }

        public void CheckLatSymb(string input) // Проверка символов латинского алфавита
        {
            var rus = new Regex(@"[a-zA-Z0-9]");
            if (!rus.IsMatch(input))
                MessageBox.Show("Пожалуйста, используйте только латиницу и цифры!");
        }


        public bool CheckEmailValue(string input) // Оба варианта работают, выбирай - не хочу
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(input);

                if (addr.Address == input)
                    return true;
                else
                    return false;
            }
            catch
            {
                MessageBox.Show("Введите действующий Email, пожалуйста!");
                return false;
            }
            /*            string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
                        Match isMatch = Regex.Match(input, pattern, RegexOptions.IgnoreCase);
                        if (!isMatch.Success)
                        {
                            MessageBox.Show("Введите действующий Email, пожалуйста!");
                            return false;
                        }
                        else
                            return true;*/
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
