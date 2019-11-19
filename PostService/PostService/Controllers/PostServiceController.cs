using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostService.DataLayer;
using PostService.Models;

namespace PostService.Controllers
{
    [Route("post/[controller]")]
    [ApiController]
    public class PostServiceController : ControllerBase
    {
        // GET: api/PostService
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                DataConnection dataConnection = new DataConnection();
                List<Post> postList = dataConnection.GetUserPost();

                if (postList.Count > 0)
                {

                    ObjectResult objectResult = new ObjectResult(postList);
                    objectResult.StatusCode = 200;
                    return objectResult;
                }
                else
                {
                    ObjectResult objectResult = new ObjectResult("Not found");
                    objectResult.StatusCode = 201;
                    return objectResult;
                }
            }
            catch (Exception ex)
            {
                ObjectResult objectResult = new ObjectResult("Bad Request");
                objectResult.StatusCode = 400;
                return objectResult;
            }
        }

        // POST: api/PostService
        [HttpPost]
        public ActionResult Post([FromBody] UserToken userToken)
        {
            try
            {
                DataConnection dataConnection = new DataConnection();
                Post postData = dataConnection.AddPost(userToken);

                if (postData != null)
                {

                    ObjectResult objectResult = new ObjectResult(postData);
                    objectResult.StatusCode = 201;
                    return objectResult;
                }
                else
                {
                    ObjectResult objectResult = new ObjectResult("Not found");
                    objectResult.StatusCode = 404;
                    return objectResult;
                }
            }
            catch (Exception ex)
            {
                ObjectResult objectResult = new ObjectResult("Bad Request");
                objectResult.StatusCode = 403;
                return objectResult;
            }
        }
    }
}
