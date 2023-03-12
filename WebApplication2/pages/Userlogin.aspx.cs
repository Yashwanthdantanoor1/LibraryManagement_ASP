using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.pages
{
	public partial class Userlogin : System.Web.UI.Page
	{
		string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button3_Click(object sender, EventArgs e)
        {
			Response.Redirect("Usersignup.aspx");
			
        }

		protected void Button1_Click(object sender, EventArgs e)
		{
			
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed)
			{
				con.Open();
			}
			SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "';", con);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Session["username"] = dr.GetValue(8).ToString();
					Session["Fullname"] = dr.GetValue(0).ToString();
					Session["Role"] = "user";
					Session["Status"] = dr.GetValue(10).ToString();
				}
				Response.Redirect("Homepage.aspx");
			}
			else
			{
				Response.Write("<script>alert('Invalid UserID or password');</script>");
			}
		}
	}
}