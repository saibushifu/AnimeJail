using AnimeJail.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AnimeJail.App.Methods;

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

        public User? TryLogin() {
            var user = App.Context.Users.FirstOrDefault(x => x.Login == _username);
            return (user != null && CheckPassword(user)) ? user : null;
        }
        private bool CheckPassword(User user) => user.Password == CryptoFunc.QuickHash(_password);  
    }
}
