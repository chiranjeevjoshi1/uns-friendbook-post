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
                //var connectionString = "mongodb://localhost:27017";
                //var client = new MongoClient(connectionString);
                //IMongoDatabase db = client.GetDatabase("mongodb");
                //var collection = db.GetCollection<Post>("posts");
                //collection.InsertOne(new Post { Postid = "1", Content = userToken.Content, Timestamp = dataTime.ToString() });

                DataSet originalDataSet = new DataSet("Posts");
                //originalDataSet.ReadXml(Directory.GetCurrentDirectory() + @"/DataLayer/PostData.xml");
                DataTable table = new DataTable("Post");
                DataColumn postidColumn = new DataColumn("Postid",
                    Type.GetType("System.Int32"));
                postidColumn.AutoIncrement = true;

                DataColumn useridColumn = new DataColumn("Userid");
                DataColumn contentColumn = new DataColumn("Content");
                DataColumn timeStampColumn = new DataColumn("TimeStamp");
                table.Columns.Add(postidColumn);
                table.Columns.Add(useridColumn);
                table.Columns.Add(contentColumn);
                table.Columns.Add(timeStampColumn);

                originalDataSet.Tables.Add(table);
                // Add ten rows.

                DataRow newRow = table.NewRow();
                newRow["Userid"] = userToken.Userid;
                newRow["Content"] = userToken.Content;
                newRow["TimeStamp"] = dataTime.ToString();
                table.Rows.Add(newRow);
               
                originalDataSet.AcceptChanges();
                originalDataSet.WriteXml(Directory.GetCurrentDirectory() + @"/DataLayer/PostData.xml");

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
                //var connectionString = "mongodb://localhost:27017";
                //var client = new MongoClient(connectionString);
                //IMongoDatabase db = client.GetDatabase("mongodb");
                //var collection = db.GetCollection<Post>("posts");
                ////collection.UpdateOne(new Post { Postid = "1", Content = userToken.Content, Timestamp = dataTime.ToString() });

                DataSet originalDataSet = new DataSet("Posts");
                //originalDataSet.ReadXml(Directory.GetCurrentDirectory() + @"/DataLayer/PostData.xml");
                DataTable table = new DataTable("Post");
                DataColumn postidColumn = new DataColumn("Postid",
                    Type.GetType("System.Int32"));
                postidColumn.AutoIncrement = true;

                DataColumn useridColumn = new DataColumn("Userid");
                DataColumn contentColumn = new DataColumn("Content");
                DataColumn timeStampColumn = new DataColumn("TimeStamp");
                table.Columns.Add(postidColumn);
                table.Columns.Add(useridColumn);
                table.Columns.Add(contentColumn);
                table.Columns.Add(timeStampColumn);

                originalDataSet.Tables.Add(table);
                // Add ten rows.

                DataRow newRow = table.NewRow();
                newRow["Userid"] = userToken.Userid;
                newRow["Content"] = userToken.Content;
                newRow["TimeStamp"] = dataTime.ToString();
                table.Rows.Add(newRow);

                originalDataSet.AcceptChanges();

                DataSet oldDataSet = new DataSet("Posts");
                oldDataSet.ReadXml(Directory.GetCurrentDirectory() + @"/DataLayer/PostData.xml");
                originalDataSet.Merge(oldDataSet);

                originalDataSet.WriteXml(Directory.GetCurrentDirectory() + @"/DataLayer/PostData.xml");
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
