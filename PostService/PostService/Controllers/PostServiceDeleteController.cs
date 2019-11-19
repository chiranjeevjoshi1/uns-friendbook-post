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
    [Route("delete/[controller]")]
    [ApiController]
    public class PostServiceDeleteController : ControllerBase
    {
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public ActionResult Delete([FromBody] UserToken userToken)
        {
            try
            {
                DataConnection dataConnection = new DataConnection();
                dataConnection.DeletePost(userToken);

                ObjectResult objectResult = new ObjectResult("OK");
                objectResult.StatusCode = 200;
                return objectResult;
            }
            catch (Exception )
            {
                ObjectResult objectResult = new ObjectResult("Forbidden");
                objectResult.StatusCode = 403;
                return objectResult;
            }
        }
    }
}
