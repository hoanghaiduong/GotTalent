using Microsoft.AspNetCore.Mvc;
using Models.Dao;
using Models.EF;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GotTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class SubjectController : ControllerBase
    {
        /// <summary>
        /// Phương thức lấy danh sách chủ đề
        /// </summary>
        /// <returns>Danh sách chủ đề cần lấy</returns>
        // GET: api/<SubjectController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Subject> subjects = null;
            try
            {
                subjects = await new SubjectDao().GetAll();

                if (subjects == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(subjects);
        }
        /// <summary>
        /// Phương thức lấy chủ đề theo id
        /// </summary>
        /// <param name="id">Id của chủ đề cần lấy</param>
        /// <returns>Chủ để lấy được</returns>
        // GET api/<SubjectController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Subject subject = null;
            try
            {
                subject = await new SubjectDao().GetByID(id);

                if (subject == null)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(subject);
        }

        //// POST api/<SubjectController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SubjectController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SubjectController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
