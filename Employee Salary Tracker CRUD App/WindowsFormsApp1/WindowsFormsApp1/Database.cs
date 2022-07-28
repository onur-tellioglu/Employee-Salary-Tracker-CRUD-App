using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    class Database
    {
        public static SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=DBsirket;Integrated Security=True");
    }
}