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

	public partial class Usersignup : System.Web.UI.Page
	{
		string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
			if (checkmemberexist())
			{
				Response.Write("<script>alert('UserId already Exists');</script>");
			}
			else
			{
				signupnewmember();
			}
        }

		bool checkmemberexist()
		{
			try
			{
				SqlConnection con = new SqlConnection(strcon);
				if(con.State==System.Data.ConnectionState.Closed)
				{
					con.Open();
				}
				SqlCommand cmd = new SqlCommand("SELECT * from member_master_tbl where member_id='"+TextBox9.Text.Trim()+"';", con);
				SqlDataAdapter da = new SqlDataAdapter(cmd);
				DataTable dt = new DataTable();
				da.Fill(dt);
				if(dt.Rows.Count >= 1) {
					return true;
				}
				else
				{
					return false;
				}
			}
			catch(Exception ex)
			{
				Response.Write(ex.ToString());
			}
			return false;
		}
		void signupnewmember()
		{
			try
			{
				SqlConnection con = new SqlConnection(strcon);
				if (con.State == System.Data.ConnectionState.Closed)
				{
					con.Open();
				}
				SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl(full_name,dob,contact_no,email,state,city,pincode,full_address,member_id,password,account_status) values(@full_name,@dob,@contact_no,@email,@state,@city,@pincode,@full_address,@member_id,@password,@account_status)", con);
				cmd.Parameters.AddWithValue("@full_name", TextBox3.Text.Trim());
				cmd.Parameters.AddWithValue("@dob", TextBox4.Text.Trim());
				cmd.Parameters.AddWithValue("@contact_no", TextBox1.Text.Trim());
				cmd.Parameters.AddWithValue("email", TextBox2.Text.Trim());
				cmd.Parameters.AddWithValue("@state", TextBox5.Text.Trim());
				cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
				cmd.Parameters.AddWithValue("@pincode", TextBox7.Text.Trim());
				cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
				cmd.Parameters.AddWithValue("@member_id", TextBox9.Text.Trim());
				cmd.Parameters.AddWithValue("@password", TextBox10.Text.Trim());
				cmd.Parameters.AddWithValue("@account_status", "pending");

				cmd.ExecuteNonQuery();
				con.Close();
				Response.Write("<script>alert('Sign up Successful. Go to User Login page');</script>");
			}
			catch (Exception ex)
			{
				Response.Write("<script>alert('" + ex.Message + "');</script>");
			}
		}
    }
}