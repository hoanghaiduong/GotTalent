using Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.EF;

namespace Models.Dao
{
    public class DetailMarkDao
    {
        MyDatabase _myDatabase;
        public DetailMarkDao()
        {
            _myDatabase = new MyDatabase();
        }

        public async Task<int> InsertMartToDatabase(DetailMark detailMark)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("@CulId",detailMark.CulId),
                new SqlParameter("@CriteriaID",detailMark.CriteriaID),
                new SqlParameter("@JubgeID",detailMark.JubgeID),
                new SqlParameter("@OrgID",detailMark.OrgID),
                new SqlParameter("@Mark",detailMark.Mark),
                new SqlParameter("@Comments",detailMark.Comments),
            };
            return await _myDatabase.MyExcuteNonQuery("PSP_DetailMark_Insert", CommandType.StoredProcedure, sqlParameters);
        }
        public async Task<List<DetailMark>> GetDetailAll(int subID)
        {

            DataTable dataTable = new DataTable();
            List<DetailMark> list = new List<DetailMark>();
            dataTable = await _myDatabase.GetDataTable("PSP_DetailMark_Select", CommandType.StoredProcedure, new SqlParameter("@SubId", subID));
            if (dataTable.Rows.Count > 0)
            {
                DetailMark detailMark;
                foreach (DataRow row in dataTable.Rows)
                {
                    //JubgeID, Title, JubgeName, Phone, Address, Images, IsDelete
                    detailMark = new DetailMark()
                    {
                        JubgeID = Convert.ToInt32(row["JubgeID"].ToString()),
                        OrgID = Convert.ToInt32(row["OrgID"].ToString()),
                        CulId = Convert.ToInt32(row["CulId"].ToString()),
                        CriteriaID = Convert.ToInt32(row["CriteriaID"].ToString()),
                        Mark = Convert.ToDouble(row["Mark"].ToString()),
                        Comments = row["Comments"].ToString(),
                    };
                    list.Add(detailMark);
                }

            }
            return list.ToList();
        }

        public async Task<List<DetailMarkRank>> GetRankList(int subID)
        {


            DataTable dataTable = new DataTable();
            List<DetailMarkRank> list = new List<DetailMarkRank>();
            dataTable = await _myDatabase.GetDataTable("PSP_DetailMark_SelectTeamRank", CommandType.StoredProcedure, new SqlParameter("@SubId", subID));
            if (dataTable.Rows.Count > 0)
            {
                DetailMarkRank detailMarkRank;
                foreach (DataRow row in dataTable.Rows)
                {
                    //JubgeID, Title, JubgeName, Phone, Address, Images, IsDelete
                    detailMarkRank = new DetailMarkRank()
                    {
                        CulName = row["CulName"].ToString(),
                        CulChineseName = row["CulChineseName"].ToString(),
                        Images = row["Images"].ToString(),
                        AgvMark = Convert.ToDouble(row["AgvMark"].ToString()),
                    };
                    list.Add(detailMarkRank);
                }

            }
            return list.ToList();
        }
        //PSP_Detail_GetDetailByCulID
        //Lấy điểm của từng đội
        // int jubgeID, culId;
        // string jubgeName, imagesJub, culName, culChineseName, imagescul, subName, subChineseName;
        public async Task<List<MarkByCul>> GetMarkByCul(int ogr, int culID)
        {
            DataTable dataTable = new DataTable();
            List<MarkByCul> list = new List<MarkByCul>();
            dataTable = await _myDatabase.GetDataTable("PSP_Detail_GetDetailByCulID", CommandType.StoredProcedure, new SqlParameter("@CulID", culID));
            if (dataTable.Rows.Count > 0)
            {
                MarkByCul markByCul;
                foreach (DataRow row in dataTable.Rows)
                {

                    markByCul = new MarkByCul()
                    {
                        // int jubgeID, culId;
                        // string jubgeName, imagesJub, culName, culChineseName, imagescul, subName, subChineseName;
                        JubgeID = Convert.ToInt32(row["JubgeID"].ToString()),
                        CulId = Convert.ToInt32(row["CulId"].ToString()),

                        JubgeName = row["JubgeName"].ToString(),
                        ImagesJub = row["ImagesJub"].ToString(),

                        CulName = row["CulName"].ToString(),
                        CulChineseName = row["CulChineseName"].ToString(),
                        Imagescul = row["Imagescul"].ToString(),
                        SubName = row["SubName"].ToString(),
                        SubChineseName = row["SubChineseName"].ToString(),
                        Total = Convert.ToDouble(row["Total"].ToString()),
                    };
                    list.Add(markByCul);
                }

            }
            return list.ToList();
        }
    }
}
