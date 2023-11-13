using Microsoft.AspNetCore.Mvc;
using Models.Dao;
using Models.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GotTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CulturaPerfomanceController : ControllerBase
    {
        // GET: api/<CulturaPerfomanceController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<CulturalPerformance> list = null;
            try
            {
                list = await new CulturalPerformanceDao().GetAlls(0);

                if (list == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(list);
        }

        // GET api/<CulturaPerfomanceController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {


            CulturalPerformance culturalPerformance1 = null;
            try
            {
                culturalPerformance1 = await new CulturalPerformanceDao().GetAllByID(id);

                if (culturalPerformance1 == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(culturalPerformance1);
        }

        //// POST api/<CulturaPerfomanceController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CulturaPerfomanceController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CulturaPerfomanceController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
