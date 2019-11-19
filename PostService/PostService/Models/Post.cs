using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.Models
{
    public class Post
    {
        private string postid;
        private string userid;
        private string content;
        private string timestamp;

        public string Postid { get => postid; set => postid = value; }
        public string Userid { get => userid; set => userid = value; }
        public string Content { get => content; set => content = value; }
        public string Timestamp { get => timestamp; set => timestamp = value; }
    }
}
