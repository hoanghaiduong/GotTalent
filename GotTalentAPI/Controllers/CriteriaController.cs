using Microsoft.AspNetCore.Mvc;
using Models;
using Models.Dao;
using Models.EF;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GotTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriteriaController : ControllerBase
    {
        // GET: api/<CriteriaController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<Criteria> list = null;
            try
            {
                list = await new CriteraDao().GetCriteriaBySubject(0);

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

        // GET api/<CriteriaController>/5
        /// <summary>
        /// Get Criterial with subid
        /// </summary>
        /// <param name="id">subid</param>
        /// <returns>Criteria list</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            List<Criteria> list = null;
            try
            {
                list = await new CriteraDao().GetCriteriaBySubject(0);

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

        //// POST api/<CriteriaController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<CriteriaController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<CriteriaController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
