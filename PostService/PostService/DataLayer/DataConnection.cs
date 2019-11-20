using Microsoft.Xrm.Sdk;
using MongoDB.Driver;
using PostService.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PostService.DataLayer
{
    public class DataConnection
    {
        public List<Post> GetUserPost()
        {
            List<Post> data = new List<Post>();
            var connectionString = "mongodb://localhost:27017";
            var client = new MongoClient(connectionString);
            IMongoDatabase db = client.GetDatabase("mongodb");
            var dblist = db.ListCollections().ToList();
            return data;
        }
        public Post AddPost(UserToken userToken)
        {
            Post data = null;
            if (CheckForValidUser(userToken))
            {
                data = new Post();
                DateTime dataTime = DateTime.Now;
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                IMongoDatabase db = client.GetDatabase("mongodb");
                var collection = db.GetCollection<Post>("posts");
                collection.InsertOne(new Post { Postid = "1", Content = userToken.Content, Timestamp = dataTime.ToString() });

            }

            return data;
        }
        public Post UpdatePost(UserToken userToken)
        {
            Post data = null;
            if (CheckForValidUser(userToken))
            {
                data = new Post();
                DateTime dataTime = DateTime.Now;
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                IMongoDatabase db = client.GetDatabase("mongodb");
                var collection = db.GetCollection<Post>("posts");
                //collection.UpdateOne(new Post { Postid = "1", Content = userToken.Content, Timestamp = dataTime.ToString() });
            }

            return data;
        }
        public void DeletePost(UserToken userToken)
        {
            if (CheckForValidUser(userToken))
            {
                DateTime dataTime = DateTime.Now;
                var connectionString = "mongodb://localhost:27017";
                var client = new MongoClient(connectionString);
                IMongoDatabase db = client.GetDatabase("mongodb");
                var collection = db.GetCollection<Post>("posts");
                //collection.DeleteOne(new Post { Postid = "1", Content = userToken.Content, Timestamp = dataTime.ToString() });
            }
            else
            {
                throw new Exception("Invalid User.");
            }
        }
        private bool CheckForValidUser(UserToken userToken)
        {
            bool result = true;
            using (HttpClient client = new HttpClient())
            {
                
            }
                return result;
        }
    }
}
