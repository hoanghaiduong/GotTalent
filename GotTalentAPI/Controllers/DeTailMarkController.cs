using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Models;
using Models.Dao;
using Models.EF;

namespace GotTalentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeTailMarkController : ControllerBase
    {
        /// <summary>
        /// Phương thức để lấy bảng xếp hạng của từng chủ đề thi
        /// </summary>
        /// <param name="id">subjec ID</param>
        /// <returns>Danh sách</returns>
        // GET: api/<DeTailMarkController>
        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            List<DetailMarkRank> list = null;
            try
            {
                list = await new DetailMarkDao().GetRankList(id);
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


        /// <summary>
        /// Phương thức dùng để lưu điểm của BGK vào trong database 
        /// </summary>
        /// <param name="detailMark">Một cấu trúc Json để lưu
        /// </param>
        /// <returns></returns>

        // POST api/<DeTailMarkController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DetailMark detailMark)
        {
            int result = 0;
            try
            {
                result = await new DetailMarkDao().InsertMartToDatabase(detailMark);

                if (result == 0)
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(result);
        }
        // POST api/<DeTailMarkController>
        //[HttpPost]
        //public async Task<IActionResult> Post(int jubgeID, int orgID, int culID, int criterialID, double mark, string comments)
        //{
        //    int result = 0;
        //    DetailMark detailMark = new DetailMark()
        //    {
        //        JubgeID = jubgeID,
        //        OrgID = orgID,
        //        CulId = culID,
        //        CriteriaID = criterialID,
        //        Mark = mark,
        //        Comments = comments
        //    };
        //    try
        //    {
        //        result = await new DetailMarkDao().InsertMartToDatabase(detailMark);

        //        if (result == 0)
        //        {
        //            return NotFound();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }
        //    return Ok(result);
        //}

    }
}
