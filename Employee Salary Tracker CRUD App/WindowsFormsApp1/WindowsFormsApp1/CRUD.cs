using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public class CRUD
    {
        public static bool ESG(string sql, SqlCommand command)
        {
            if (Database.con.State == System.Data.ConnectionState.Closed)
            {
                Database.con.Open();
            }

            command.Connection = Database.con;
            command.CommandText = sql;
            command.ExecuteNonQuery();

            try
            {
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                Database.con.Close();
            }
        }
        public static DataTable List(string sql)
        {
            DataTable tbl = new DataTable();
            SqlDataAdapter adtr = new SqlDataAdapter(sql, Database.con);
            adtr.Fill(tbl);
            return tbl;
        }
    }
}