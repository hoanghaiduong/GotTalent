using System.Data;
using System.Data.SqlClient;

namespace Models
{
    public class MyDatabase
    {
        private SqlConnection cnn = null;//Đối tượng kết nối
        private SqlCommand cmd = null;//Đối tượng thực thi câu lệnh
        private SqlDataAdapter da = null;//Đối tượng thực thi DataAdapter
        private SqlDataReader dataReader;//Đối tượng đọc dữ liệu theo dạng luồng

        private readonly string _connectionString;//Chuỗi kết nối
        /// <summary>
        /// Phương thức lấy đối tượng kết nối
        /// </summary>
        /// <returns>Trả về đối tượng kết nối</returns>
        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
        /// <summary>
        /// Hàm tạo của đối tượng MyDatabase
        /// </summary>
        /// <param name="connectionString">Chuỗi kết nối</param>
        public MyDatabase(string connectionString)
        {
            _connectionString = connectionString;
            cnn = new SqlConnection(_connectionString);
        }
        public MyDatabase()
        {
            _connectionString = "server=118.69.126.49;database=data_ExamManagement;uid=sa;pwd=cntt@2023";
            cnn = new SqlConnection(_connectionString);
        }
        /// <summary>
        /// Phương thức check kết nối
        /// </summary>
        /// <returns></returns>
        public async Task<bool> CheckConnect()
        {
            try
            {
                await cnn.OpenAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            return false;
        }
        /// <summary>
        /// Phương thức thực hiện truy vấn trả về đối tượng DataTable
        /// </summary>
        /// <param name="sql">Thủ tục sql viết trong Sql Server</param>
        /// <param name="commandType">Kiểu câu lệnh</param>
        /// <param name="parameters">Danh sách tham số</param>
        /// <returns>Dữ liệu theo dạng bảng</returns>
        public async Task<DataTable> GetDataTable(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                if (cnn.State != ConnectionState.Open)
                {
                    await cnn.CloseAsync();
                }
                await cnn.OpenAsync();

                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                cnn.Close();
            }
            return dt;
        }
        /// <summary>
        /// Phương thức thực thi các câu lệnh Insert, Update, Delete
        /// </summary>
        /// <param name="sql">Tên thủ tục</param>
        /// <param name="commandType">Kiểu câu lệnh Chọn là Store Procedure</param>
        /// <param name="parameters">Danh sách tham số cảu Thủ tục</param>
        /// <returns>Trả về số lượng dòng thực hiện được</returns>
        public async Task<int> MyExcuteNonQuery(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            int result = 0;
            try
            {
                if (cnn.State != ConnectionState.Open)
                {
                    await cnn.CloseAsync();
                }
                await cnn.OpenAsync();

                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                result = await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }
        /// <summary>
        /// Phương thức thực thi các câu lệnh Select trả về 1 giá trị duy nhất
        /// </summary>
        /// <param name="sql">Tên thủ tục</param>
        /// <param name="commandType">Kiểu câu lệnh Chọn là Store Procedure</param>
        /// <param name="parameters">Danh sách tham số cảu Thủ tục</param>
        /// <returns>Đối tượng được trả về</returns>
        public async Task<object?> MyExcuteScalar(string sql, CommandType commandType, params SqlParameter[] parameters)
        {
            object? result = null;
            try
            {
                if (cnn.State != ConnectionState.Open)
                {
                    await cnn.CloseAsync();
                }
                await cnn.OpenAsync();

                cmd = new SqlCommand();
                cmd.Connection = cnn;
                cmd.CommandText = sql;
                cmd.CommandType = commandType;
                if (parameters != null)
                {
                    foreach (var item in parameters)
                    {
                        cmd.Parameters.Add(item);
                    }
                }
                result = await cmd.ExecuteScalarAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error {ex.Message}");
            }
            finally
            {
                cnn.Close();
            }
            return result;
        }


    }
}