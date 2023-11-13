using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dao;
using Models.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GotTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JudgesController : ControllerBase
    {
        // GET: api/<JudgesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            List<Judges> list = null;
            try
            {
                list = await new JudgesDao().GetAll(0);

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

        // GET api/<JudgesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var Judges = new JudgesDao().GetJubgeByID(id);


            Judges judges = null;
            try
            {
                judges = await new JudgesDao().GetJubgeByID(id);

                if (judges == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(judges);
        }

        //// POST api/<JudgesController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<JudgesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<JudgesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
