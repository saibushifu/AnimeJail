using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimeJail.App.Methods
{
   public class LoginData
    {
        private string _username;
        private string _password;
        public LoginData(string username, string password) {
            _username = username;
            _password = password;
        }

        public bool TryLogin() { 
            if (true)
            {
               return CheckPassword();
            }
            return true; 
        }
        private bool CheckPassword() { 
            return false; 
        }
    }
}
