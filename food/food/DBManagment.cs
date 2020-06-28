using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace food
{
            

   public  class DBManagment
    {
       string ConStr;
       public DBManagment()
        {

            ConStr = "Data Source=Localhost;Initial Catalog=FoodDB; Integrated Security=True";
        }
       public void Updatetable(string Updatestr)
       {
           SqlConnection scon = new SqlConnection(ConStr);
           SqlCommand objcommand = new SqlCommand(Updatestr, scon);
           scon.Open();
           objcommand.ExecuteNonQuery();
           scon.Close();
       }

       public string Selecttotable(string Selectstr, string tablecolumnname)
       {
           SqlConnection scon = new SqlConnection(ConStr);
           scon.Open();
           SqlDataAdapter objadapter = new SqlDataAdapter(Selectstr, scon);
           DataSet objds = new DataSet();
           objadapter.Fill(objds);
           string result = "";


           if (objds.Tables.Count > 0)
           {
               result = objds.Tables[0].Rows[0][tablecolumnname].ToString();

           }


           scon.Close();
           return result;
       }


       public void Inserttable(string Inserttable)
       {
           SqlConnection scon = new SqlConnection(ConStr);
           SqlCommand objcommand = new SqlCommand(Inserttable, scon);
           scon.Open();
           objcommand.ExecuteNonQuery();
           scon.Close();
       }


       public string SelectHasRows(string Selectstr)
       {
           string result = "";
           SqlConnection scon = new SqlConnection(ConStr);
           SqlCommand objcommand = new SqlCommand(Selectstr, scon);

           scon.Open();

           SqlDataReader objdatareader = objcommand.ExecuteReader();
           if (objdatareader.HasRows != false)
           {
               result = "ok";
           }
           scon.Close();

           return result;
       }


       //public void ShoeInGrid(GridView gv, string SelectStr)
       //{
       //    SqlConnection scon = new SqlConnection(ConStr);
       //    scon.Open();
       //    SqlDataAdapter sda = new SqlDataAdapter(SelectStr, scon);
       //    DataSet ds = new DataSet();
       //    sda.Fill(ds);
       //    gv.DataSource = ds;
       //    gv.DataBind();
       //    scon.Close();
       //}

       public void Deleterowtable(string selectdeletestr)
       {
           SqlConnection scon = new SqlConnection(ConStr);
           SqlCommand objcommand = new SqlCommand(selectdeletestr, scon);
           scon.Open();
           objcommand.ExecuteNonQuery();
           scon.Close();
       }
    }

}
