
using BreadFactoryIS.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace app.ViewModels
{
    class AuthorizationViewModel : ViewModelBase
    {
        public static User user { get; private set; }
        public string Login { get; set; }

        public AuthorizationViewModel()
        {
            Title = "Авторизация";
        }

        public IGettingPassword GettingPassword { private get; set; }

        private string Password
        {
            get => GettingPassword.GetPassword();
        }

        public bool LogIn()
        {
            try
            {
                

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return user != null;
        }
    }
}
