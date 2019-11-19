using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            ObjectResult objectResult = new ObjectResult(userToken);
            return objectResult;
        }

    }
}
