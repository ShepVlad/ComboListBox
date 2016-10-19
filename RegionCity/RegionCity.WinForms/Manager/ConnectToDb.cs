using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;


namespace RegionCity.WinForms.Manager
{
    public class ConnectToDb
    {
       
        public static bool IsConnect(string login, string password)
        {

            string ConString = ConfigurationManager
                .ConnectionStrings["RegionContext"]
                .ConnectionString;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(ConString);
            sb.UserID= login;
            sb.Password = password;
            SqlConnection connect = new SqlConnection(sb.ToString());
            bool result = true;
            try
            {
                connect.Open();
            }
            catch 
            {
                result = false;
                throw;
            }
            finally
            {
                connect.Close();
            }
            return result;
        }
        public static string GetConnectionString(string login, string password)
        {
            string ConString = ConfigurationManager
                   .ConnectionStrings["RegionContext"]
                   .ConnectionString;
            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(ConString);
            sb.UserID = login;
            sb.Password = password;
            return sb.ConnectionString;
        }
    }
}
