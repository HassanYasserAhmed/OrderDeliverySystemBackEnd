using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystemDataAccessLayer.Login;

namespace OrderDeliverySystemBusinessLayer.Login
{
    public class LoginService
    {
        public  static string LoginByUserNameAndPassword(string UserName,string Password)
        {
            return LoginData.LoginByUserNameAndPassword(UserName,Password);
        }
    }
}
