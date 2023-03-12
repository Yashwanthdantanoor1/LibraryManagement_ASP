using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.pages
{
	public partial class adminauthormanagement : System.Web.UI.Page
	{
		string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void Button2_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='"+TextBox3.Text.Trim()+"' AND author_name='"+TextBox4.Text.Trim()+"';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if(dt.Rows.Count>=1)
			{
				Response.Write("<script>alert('author id already exists');</script>");
			}
			else
			{
				adduser();	
			}
		}
		void adduser()
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id,author_name) VALUES(@author_id,@author_name)", con);
			cmd.Parameters.AddWithValue("@author_id", TextBox3.Text.Trim());
			cmd.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
			cmd.ExecuteNonQuery();
			con.Close();
			Response.Write("<script>alert('successfully added to the data base')</script>");
			clearform();
			GridView1.DataBind();
		}


		protected void Button3_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count>=1)
			{
				SqlCommand cmd2 = new SqlCommand("UPDATE author_master_tbl SET author_name = @author_name WHERE author_id='" + TextBox3.Text.Trim() + "';", con);
				cmd2.Parameters.AddWithValue("@author_name", TextBox4.Text.Trim());
				cmd2.ExecuteNonQuery();
				con.Close();
				Response.Write("<script>alert('Updated Successfully')</script>");
				clearform();
				GridView1.DataBind();
			}
			else
			{
				Response.Write("<script>alert('No data present with that ID')</script>");
		}
	}

		protected void Button4_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				SqlCommand cmd2 = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "';", con);
				cmd2.ExecuteNonQuery();
				con.Close();
				Response.Write("<script>alert('Deleted Successfully')</script>");
				clearform();
				GridView1.DataBind();
			}
			else
			{
				Response.Write("<script>alert('No data present with that ID')</script>");
			}
		}
		void clearform()
		{
			TextBox3.Text = "";
			TextBox4.Text = "";
		}

        protected void Button1_Click(object sender, EventArgs e)
        {
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM author_master_tbl WHERE author_id='" + TextBox3.Text.Trim() + "';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				TextBox4.Text = dt.Rows[0][1].ToString();
			}
			else
			{
				Response.Write("<script>alert('No data present with that ID')</script>");
			}
		}

	}
}