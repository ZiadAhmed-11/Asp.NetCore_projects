using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class LoginManager
    {
        public delegate void Handler(User user);
        public event Handler UserLoginSuccessful;
        public void LoginUser(User user)
        {
            if(!user.Email.EndsWith(".com"))
            {
                return;
            }
            UserLoginSuccessful.Invoke(user);

        }
    }
}
