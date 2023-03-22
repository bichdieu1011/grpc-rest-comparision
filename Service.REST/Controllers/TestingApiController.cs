using DataModel;
using Microsoft.AspNetCore.Mvc;

namespace Service.REST.Controllers
{
    [ApiController]
    [Route("restApi")]
    public class TestingApiController : ControllerBase
    {
     
        [HttpGet]
        [Route("GetAllStudentInfo")]
        public ActionResult<IEnumerable<TestingData>> GetLargePayloadAsync()
        {
            return StudentData.ListStudentForRest;
        }

        [HttpPost]
        [Route("PostAllStudentInfo")]
        public string PostLargePayload([FromBody] IEnumerable<TestingData> data)
        {
            return "SUCCESS";
        }
    }

    public class IdModel
    {
        
    }
}