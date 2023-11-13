using Microsoft.AspNetCore.Mvc;
using Models.Dao;
using Models.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GotTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkOfCulController : ControllerBase
    {
        // GET: api/<MarkOfCulController>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            List<MarkByCul> list = null;
            try
            {
                list = await new DetailMarkDao().GetMarkByCul(1, id);
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

        //// GET api/<MarkOfCulController>/5
        //[HttpGet]
        //public string Get()
        //{
        //    return "value";
        //}

        //// POST api/<MarkOfCulController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<MarkOfCulController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<MarkOfCulController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
