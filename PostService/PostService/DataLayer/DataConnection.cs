using PostService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostService.DataLayer
{
    public class DataConnection
    {
        public List<Post> GetUserPost()
        {
            List<Post> data = new List<Post>();

            return data;
        }
        public Post AddPost(UserToken userToken)
        {
            Post data = new Post();

            return data;
        }
        public Post UpdatePost(UserToken userToken)
        {
            Post data = new Post();

            return data;
        }
        public void DeletePost(UserToken userToken)
        {
           
        }
    }
}
