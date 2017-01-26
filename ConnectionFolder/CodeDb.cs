using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;



namespace CrudCore.ConnectionFolder
{
    public class CodeDb
    {  
       protected static SqlConnection con;
        
        public static SqlConnection Open(string connection ="Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=testpets;Integrated Security=True;Pooling=False")
        {
            
            con = new SqlConnection(connection);
            try
            {
                if (con.State != ConnectionState.Open)
                {
                    con.Open();

                }
                return con;
            }
            catch (SqlException ex)
            {
                return null;

            }
        }
        public static bool Close()
        {
            try
            {
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
