using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ObjectResult objectResult = new ObjectResult(userToken);
            return objectResult;
        }
    }
}
