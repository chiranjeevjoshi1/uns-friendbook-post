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
    [Route("modify/[controller]")]
    [ApiController]
    public class PostServiceModifyController : ControllerBase
    {
        // PUT: api/PostService/5
        [HttpPut]
        public ActionResult Put([FromBody] UserToken userToken)
        {
            // POST: api/PostService
            try
            {
                DataConnection dataConnection = new DataConnection();
                Post postData = dataConnection.UpdatePost(userToken);

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
