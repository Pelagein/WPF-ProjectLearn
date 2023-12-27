using System.Windows;
using WPFLearn.Model;

namespace WPFLearn
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int Id_user;
        readonly ApplicationContext db = new ApplicationContext();
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Авторизация.
            if (Validation.MethodV(TextBoxLogin.Text, TextBoxPassword.Password) == true)
            {
                //Проверка метода Validation.MethodV2 (Пройдёна успешно)
                //if(Validation.MethodV2(TextBoxLogin.Text,"login"))
                //    MessageBox.Show($"Login valid!");
                //else
                //    MessageBox.Show($"Login invalid!");

                if (MethodAutorization(TextBoxLogin.Text, TextBoxPassword.Password) == true)
                {
                    MessageBox.Show("Вы успешно авторизовались!");
                    var person = db.Users.FirstOrDefault(user => user.Name == TextBoxLogin.Text);
                    switch (person.Role)
                    {
                        case "admin":

                            //adminHome.Show(); // Открытие окно при успешной авторизации.
                            this.Close(); Id_user = person.id; break;


                        case "user":

                            //home.Show(); // Открытие окно при успешной авторизации.
                            this.Close(); Id_user = person.id; break;
                        default:

                            MessageBox.Show($"Это провал, {person.Name}!"); break;
                    }
                }
                else
                {
                    MessageBox.Show("Введены неверные данные!");
                }
            }
            else
            {
                MessageBox.Show("Проверьте введенные данные!");
            }
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            //Регистрация
            if (Validation.MethodV(TextBoxLogin.Text, TextBoxPassword.Password) == true)
            {
                if (MethodRegistration(TextBoxLogin.Text, TextBoxPassword.Password) == true)
                {
                    MessageBox.Show("Вы успешно зарегистровались, осталось войти!");
                }
                else
                {
                    MessageBox.Show("Логин занят!");
                }
            }
            else { MessageBox.Show("Проверьте введенные данные!"); }
        }
        public bool MethodRegistration(string Login, string Password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int countUsers = (from p in db.Users where p.Name == Login select p).Count();
                if (countUsers == 0)
                {
                    Users user = new Users(Login, Password);
                    db.Users.Add(user);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            };
        }
        public bool MethodAutorization(string Login, string Password)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                int countUsers = (from p in db.Users where p.Name == Login && p.Password == Password select p).Count();
                return (countUsers > 0);
            };
        }
    }
}