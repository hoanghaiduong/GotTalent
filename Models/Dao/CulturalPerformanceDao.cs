using Models.EF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class CulturalPerformanceDao
    {
        MyDatabase _myDatabase;
        public CulturalPerformanceDao()
        {
            _myDatabase = new MyDatabase();
        }

        public async Task<List<CulturalPerformance>> GetAlls(int id)
        {
            DataTable dataTable = new DataTable();
            List<CulturalPerformance> list = new List<CulturalPerformance>();
            dataTable = await _myDatabase.GetDataTable("PSP_CulturalPerformance_Select", CommandType.StoredProcedure, new SqlParameter("@CulID", id));
            if (dataTable.Rows.Count > 0)
            {
                CulturalPerformance culturalPerformance;
                foreach (DataRow row in dataTable.Rows)
                {
                    culturalPerformance = new CulturalPerformance()
                    {
                        CulID = Convert.ToInt32(row["CulID"].ToString()),
                        CulName = row["CulName"].ToString(),
                        CulChineseName = row["CulChineseName"].ToString(),
                        SchoolName = row["SchoolName"].ToString(),
                        SchoolID = Convert.ToInt32(row["SchoolID"].ToString()),
                        Description = row["Description"].ToString(),
                        SubID = Convert.ToInt32(row["SubID"].ToString()),
                        Images = row["Images"].ToString()
                    };
                    list.Add(culturalPerformance);
                }

            }
            return list.ToList();
        }

        public async Task<CulturalPerformance> GetAllByID(int id)
        {
            DataTable dataTable = new DataTable();
            CulturalPerformance culturalPerformance = null;
            dataTable = await _myDatabase.GetDataTable("PSP_CulturalPerformance_Select", CommandType.StoredProcedure, new SqlParameter("@CulID", id));
            if (dataTable.Rows.Count > 0)
            {

                foreach (DataRow row in dataTable.Rows)
                {
                    culturalPerformance = new CulturalPerformance()
                    {
                        CulID = Convert.ToInt32(row["CulID"].ToString()),
                        CulName = row["CulName"].ToString(),
                        CulChineseName = row["CulChineseName"].ToString(),
                        SchoolName = row["SchoolName"].ToString(),
                        SchoolID = Convert.ToInt32(row["SchoolID"].ToString()),
                        Description = row["Description"].ToString(),
                        SubID = Convert.ToInt32(row["SubID"].ToString()),
                        Images = row["Images"].ToString()
                    };

                }

            }
            return culturalPerformance;
        }
    }
}
