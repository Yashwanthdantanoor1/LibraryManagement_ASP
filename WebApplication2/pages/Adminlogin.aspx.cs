using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.pages
{
	public partial class Adminlogin : System.Web.UI.Page
	{
		string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		protected void Button1_Click(object sender, EventArgs e)
		{

			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed)
			{
				con.Open();
			}
			SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl WHERE username='"+TextBox1.Text.Trim()+"' AND password='"+TextBox2.Text.Trim()+"';", con);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					Session["username"] = dr.GetValue(0).ToString();
					Session["Fullname"] = dr.GetValue(2).ToString();
					Session["role"] = "admin";
				
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