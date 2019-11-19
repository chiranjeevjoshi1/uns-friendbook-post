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
            DataConnection dataConnection = new DataConnection();
            List<Post> postList = dataConnection.GetUserPost();

            ObjectResult objectResult = new ObjectResult(postList);
            objectResult.StatusCode = 201;
            return objectResult;
        }

        // POST: api/PostService
        [HttpPost]
        public ActionResult Post([FromBody] UserToken userToken)
        {
            ObjectResult objectResult = new ObjectResult(userToken);
            return objectResult;
        }
    }
}
