using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
	public partial class Site1 : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (Session["role"].Equals(""))
				{
					LinkButton1.Visible = true;//userlogin
					LinkButton2.Visible = true;//signup

					LinkButton3.Visible = false;//logout
					LinkButton7.Visible = false;//userprofile

					LinkButton6.Visible = true;//admin login

					LinkButton11.Visible = false;//author mang
					LinkButton12.Visible = false;//pub manag
					LinkButton8.Visible = false;//book inv
					LinkButton9.Visible = false;//book issu
					LinkButton10.Visible = false;//Member manag
				}
				else if (Session["role"].Equals("user"))
				{
					LinkButton3.Visible = true;//logout
					LinkButton7.Visible = true;//userprofile
					LinkButton7.Text = "Hello" + Session["username"].ToString();

					LinkButton1.Visible = false;//userlogin
					LinkButton2.Visible = false;//signup

					LinkButton6.Visible = false;//admin login
					LinkButton11.Visible = false;//author mang
					LinkButton12.Visible = false;//pub manag
					LinkButton8.Visible = false;//book inv
					LinkButton9.Visible = false;//book issu
					LinkButton10.Visible = false;//Member manag

				}
				else if (Session["role"].Equals("admin"))
				{
					LinkButton11.Visible = true;//author mang
					LinkButton12.Visible = true;//pub manag
					LinkButton8.Visible = true;//book inv
					LinkButton9.Visible = true;//book issu
					LinkButton10.Visible = true;//Member manag
					LinkButton7.Visible = true;//userprofile
					LinkButton7.Text = "Hello Admin";
					LinkButton3.Visible = true;//logout

					LinkButton1.Visible = false;//userlogin
					LinkButton2.Visible = false;//signup
					
					
					LinkButton6.Visible = false;//admin login
				}
			}
			catch (Exception ex){
				Console.WriteLine(ex.ToString());
			}
		}

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
			Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminauthormanagement.aspx");
        }

		protected void LinkButton12_Click(object sender, EventArgs e)
		{
			Response.Redirect("adminpublishermanagement.aspx");
		}

		protected void LinkButton8_Click(object sender, EventArgs e)
		{
			Response.Redirect("adminbookinventory.aspx");
		}

		protected void LinkButton9_Click(object sender, EventArgs e)
		{
			Response.Redirect("adminbookissuing.aspx");
		}

		protected void LinkButton10_Click(object sender, EventArgs e)
		{
			Response.Redirect("adminmembermanagement.aspx");
		}
		protected void LinkButton14_Click(object sender, EventArgs e)
		{
			Response.Redirect("viewbooks.aspx");
		}
		protected void LinkButton15_Click(object sender, EventArgs e)
		{
			Response.Redirect("Userlogin.aspx");
		}
		protected void LinkButton13_Click(object sender, EventArgs e)
		{
			Response.Redirect("Usersignup.aspx");
		}
		protected void LinkButton16_Click(object sender, EventArgs e)
		{
			Response.Redirect("Userprofile.aspx");
		}
		protected void LinkButton17_Click(object sender, EventArgs e)
		{
			Session["username"] = "";
			Session["Fullname"] = "";
			Session["Role"] = "";
			Session["Status"] = "";
			Response.Redirect("Homepage.aspx");

			LinkButton1.Visible = true;//userlogin
			LinkButton2.Visible = true;//signup

			LinkButton3.Visible = false;//logout
			LinkButton7.Visible = false;//userprofile

			LinkButton6.Visible = true;//admin login

			LinkButton11.Visible = false;//author mang
			LinkButton12.Visible = false;//pub manag
			LinkButton8.Visible = false;//book inv
			LinkButton9.Visible = false;//book issu
			LinkButton10.Visible = false;//Member manag

		}

	}
}