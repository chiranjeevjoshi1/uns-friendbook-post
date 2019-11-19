using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Models
{
    public class UserToken
    {
        private string userid;
        private string username;
        private string expiry;

        public string Userid { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public string Expiry { get => expiry; set => expiry = value; }
    }
}
