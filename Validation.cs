using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace WPFLearn
{
    internal class Validation
    {
        public static bool MethodV(string Login, string Password)
        {
            return (Login != "" && Password != "") && (Password.Length >= 8);
        }
        public static bool MethodV2(string Stroka, string Pattern)
        {
            // Задумка:
            // Приходит переменная, и приходит pattern проверки этой переменной.
            // Например: Alex, login. Проверяем соответсвует ли строка "Alex" нашему логину. Возращаем true или false.


            switch (Pattern)
            {
                case "login":

                    Pattern = "^[A-Z][a-z0-9_-]{3,16}$";
                    break;

                case "password":
                    Pattern = "^(?=.*[A-Z].*[A-Z])(?=.*[!@#$&*])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,}$";
                    break;

                default:
                    MessageBox.Show($"Это провал, забыли тип проверки");
                    break;
            }
            return (Regex.Match(Stroka, Pattern).Success);
        }

    }
}
