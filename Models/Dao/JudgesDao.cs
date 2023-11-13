using Models.EF;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Net;
using System.Numerics;

namespace Models.Dao
{
    public class JudgesDao
    {
        MyDatabase _myDatabase;
        public JudgesDao()
        {
            _myDatabase = new MyDatabase();
        }

        public async Task<List<Judges>> GetAll(int judgeID)
        {
            DataTable dataTable = new DataTable();
            List<Judges> list = new List<Judges>();
            dataTable = await _myDatabase.GetDataTable("PSP_Judge_Select", CommandType.StoredProcedure, new SqlParameter("@JudgeID", judgeID));
            if (dataTable.Rows.Count > 0)
            {
                Judges judges;
                foreach (DataRow row in dataTable.Rows)
                {
                    //JubgeID, Title, JubgeName, Phone, Address, Images, IsDelete
                    judges = new Judges()
                    {
                        JubgeID = Convert.ToInt32(row["JubgeID"].ToString()),
                        JubgeName = row["JubgeName"].ToString(),
                        Title = row["Title"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString(),
                        Images = row["Images"].ToString(),

                    };
                    list.Add(judges);
                }

            }
            return list.ToList();
        }

        public async Task<Judges> GetJubgeByID(int judgeID)
        {
            DataTable dataTable = new DataTable();
            Judges judges = null;
            dataTable = await _myDatabase.GetDataTable("PSP_Judge_Select", CommandType.StoredProcedure, new SqlParameter("@JudgeID", judgeID));
            if (dataTable.Rows.Count > 0)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    //JubgeID, Title, JubgeName, Phone, Address, Images, IsDelete
                    judges = new Judges()
                    {
                        JubgeID = Convert.ToInt32(row["JubgeID"].ToString()),
                        JubgeName = row["JubgeName"].ToString(),
                        Title = row["Title"].ToString(),
                        Phone = row["Phone"].ToString(),
                        Address = row["Address"].ToString(),
                        Images = row["Images"].ToString(),
                    };
                }
            }
            return judges;
        }
    }
}
