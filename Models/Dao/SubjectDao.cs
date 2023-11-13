using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Dao
{
    public class SubjectDao
    {
        MyDatabase _myDatabase;
        public SubjectDao()
        {
            _myDatabase = new MyDatabase();
        }

        public async Task<List<Subject>> GetAll()
        {
            DataTable dataTable = new DataTable();
            List<Subject> list = new List<Subject>();
            dataTable = await _myDatabase.GetDataTable("PSP_Subject_Select", CommandType.StoredProcedure, null);
            if (dataTable.Rows.Count > 0)
            {
                Subject subject;
                foreach (DataRow row in dataTable.Rows)
                {
                    subject = new Subject()
                    {
                        SubID = Convert.ToInt32(row["SubID"].ToString()),
                        SubName = row["SubName"].ToString(),
                        SubChineseName = row["SubChineseName"].ToString(),
                    };
                    list.Add(subject);
                }

            }
            return list.ToList();
        }

        public async Task<Subject> GetByID(int id)
        {
            DataTable dataTable = new DataTable();
            Subject subject = null;
            dataTable = await _myDatabase.GetDataTable("PSP_Subject_SelectByID", CommandType.StoredProcedure, new SqlParameter("@SubID", id));
            if (dataTable.Rows.Count > 0)
            {

                foreach (DataRow row in dataTable.Rows)
                {
                    subject = new Subject()
                    {
                        SubID = Convert.ToInt32(row["SubID"].ToString()),
                        SubName = row["SubName"].ToString(),
                        SubChineseName = row["SubChineseName"].ToString(),
                    };

                }

            }
            return subject;
        }
    }
}
