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
    public class CriteraDao
    {
        MyDatabase _myDatabase;
        public CriteraDao()
        {
            _myDatabase = new MyDatabase();
        }

        public async Task<List<Criteria>> GetCriteriaBySubject(int subID)
        {
            DataTable dataTable = new DataTable();
            List<Criteria> list = new List<Criteria>();
            dataTable = await _myDatabase.GetDataTable("PSP_Critera_SelectBySubjects", CommandType.StoredProcedure, new SqlParameter("@SubID", subID));
            if (dataTable.Rows.Count > 0)
            {
                Criteria criteria;
                foreach (DataRow row in dataTable.Rows)
                {
                    criteria = new Criteria()
                    {
                        CriteriaID = Convert.ToInt32(row["CriteriaID"].ToString()),
                        CriteriaName = row["CriteriaName"].ToString(),
                        CriteriaChineseName = row["CriteriaChineseName"].ToString(),
                        MaxMark = Convert.ToDouble(row["MaxMark"].ToString()),
                        SubID = Convert.ToInt32(row["SubID"].ToString()),

                    };
                    list.Add(criteria);


                }

            }
            return list.ToList();
        }


    }
}
