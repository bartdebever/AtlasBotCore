using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Useraccounts.Implementation
{
    public class SmashAccount
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public bool? IsVerified { get; set; }
        public string Rank { get; set; }

        public SmashAccount(string username, string token, bool isVerified)
        {
            this.Username = username;
            this.Token = token;
            this.IsVerified = isVerified;
        }

        public override string ToString()
        {
            return Username + ": " + Rank;
        }

        public SmashAccount()
        {
            
        }
    }
}
