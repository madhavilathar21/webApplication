 using System;
using System.Collections.Generic;
//using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
	
     public SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|Database1.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework");
		
    public Boolean  ins_up_del(string query)

    {
        SqlCommand cmd = new SqlCommand(query, con);
        try
        {
            con.Open();
            cmd.ExecuteNonQuery();
            return true;
        }

        catch(Exception ex)
        {
            return false;
        }

    }
    public DataSet selectData(string query)
    {
        SqlDataAdapter adp = new SqlDataAdapter(query, con);
        DataSet ds = new DataSet();
        try
        {
            adp.Fill(ds);
            return ds;
        }
        catch (Exception ex)
        {
            return null;
        }
    }
		// TODO: Add constructor logic here
		//
	
}
