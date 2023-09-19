using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class User
    {
        

        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public string Email { get; private set;}
        public User(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email; 
        }
    }
}
