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
        private string postId;
        private string content;

        public string Userid { get => userid; set => userid = value; }
        public string Username { get => username; set => username = value; }
        public string Expiry { get => expiry; set => expiry = value; }
        public string PostId { get => postId; set => postId = value; }
        public string Content { get => content; set => content = value; }
    }
}
