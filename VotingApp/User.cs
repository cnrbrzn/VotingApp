using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VotingApp
{
    public class User
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool voted { get; set; }

        public static List<User> UserList = new List<User>()
        {
            new User{UserName="caner", Password="123456", voted=false }
        };
        public User()
        {
            
        }
        public User(string userName, string password, bool voted)
        {
            this.UserName = userName;
            this.Password = password;
            this.voted = voted;
            UserList.Add(this);

        }


    }
}
