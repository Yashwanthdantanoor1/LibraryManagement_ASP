using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2.pages
{
	public partial class adminmembermanagement : System.Web.UI.Page
	{
		string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{
			GridView1.DataBind();
		}
		//Go Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "';", con);
			SqlDataReader dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					TextBox4.Text = dr.GetValue(0).ToString();
					TextBox1.Text = dr.GetValue(1).ToString();
					TextBox7.Text = dr.GetValue(10).ToString();
					TextBox6.Text = dr.GetValue(2).ToString();
					TextBox2.Text = dr.GetValue(3).ToString();
					TextBox8.Text = dr.GetValue(4).ToString();
					TextBox9.Text = dr.GetValue(5).ToString();
					TextBox10.Text = dr.GetValue(6).ToString();
					TextBox5.Text = dr.GetValue(7).ToString();

				}
			}
		}
		//check
		protected void LinkButton1_Click(object sender, EventArgs e)
		{
			updatestatus("Active");
		}
		//pause
		protected void LinkButton2_Click(object sender, EventArgs e)
		{
			updatestatus("Pending");
		}
		//cancel
		protected void LinkButton3_Click(object sender, EventArgs e)
		{
			updatestatus("Deactive");
		}

		void updatestatus(string status)
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='" + status + "' WHERE member_id='"+TextBox3.Text.Trim()+"';", con);
			cmd.ExecuteNonQuery();
			con.Close();
			Response.Write("<script>alert('Status Updated')</script>");
			GridView1.DataBind();
		}



		protected void Button3_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				SqlCommand cmd2 = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='" + TextBox3.Text.Trim() + "';", con);
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
	}
}