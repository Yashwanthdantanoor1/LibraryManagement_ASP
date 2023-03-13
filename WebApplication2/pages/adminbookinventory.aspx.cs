using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;

namespace WebApplication2.pages
{
	public partial class adminbookinventory : System.Web.UI.Page
	{
		string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
		static string global_filepath;
		static int global_actual_stock, global_current_stock, global_issued_book;
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				fillauthorpublishervalues();
			}
			GridView1.DataBind();

		}
		// add
		protected void Button1_Click(object sender, EventArgs e)
		{
			if (bookexists())
			{
				Response.Write("<script>alert('book exists')</script>");
			}
			else
			{
				addnewbook();
				GridView1.DataBind();
			}
		}

		//GO button
		protected void Button4_Click(object sender, EventArgs e)
		{
			getbookbyid();
		}
		//update
		protected void Button3_Click(object sender, EventArgs e)
		{
			updatebookbyid();
		}
		//delete
		protected void Button2_Click(object sender, EventArgs e)
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				SqlCommand cmd2 = new SqlCommand("DELETE FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
				cmd2.ExecuteNonQuery();
				con.Close();
				Response.Write("<script>alert('Deleted Successfully')</script>");
				clearform();
				GridView1.DataBind();
			}
			else
			{
				Response.Write("<script>alert('No data present with that ID')</script>");
				clearform();
			}
		}

		//user defined functions

		void updatebookbyid()
		{
			int actual_stock = Convert.ToInt32(TextBox4.Text.Trim());
			int current_stock = Convert.ToInt32(TextBox5.Text.Trim());
			if(global_actual_stock == actual_stock)
			{

			}
			else
			{
				if (actual_stock < global_issued_book)
				{
					Response.Write("<script>alert('Actual stock cannot be less than the issued books');</script>");
					return;
				}
				else
				{
					current_stock = actual_stock-global_issued_book;
					TextBox5.Text = "" + current_stock;
				}
			}

			string genres = "";
			foreach (int i in ListBox1.GetSelectedIndices())
			{
				genres = genres + ListBox1.Items[i] + ",";
			}
			genres = genres.Remove(genres.Length - 1);
			string filepath = "~/books/books.png";
			string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
			if(filename == "" || filename == null) { filepath = global_filepath; }
			else
			{
				FileUpload1.SaveAs(Server.MapPath("books/" + filename));
				filepath = "books/" + filename;
			};
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				SqlCommand cmd2 = new SqlCommand("UPDATE book_master_tbl SET book_name = @book_name,genre=@genre,author_name=@author_name,publisher_name=@publisher_name,publish_date=@publish_date,language=@language,edition=@edition,book_cost=@book_cost,no_of_pages=@no_of_pages,book_description=@book_description,actual_stock=@actual_stock,current_stock=@current_stock,book_img_link=@book_img_link WHERE book_id='" + TextBox1.Text.Trim() + "';", con);
				cmd2.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
				cmd2.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
				cmd2.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
				cmd2.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
				cmd2.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
				cmd2.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
				cmd2.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
				cmd2.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
				cmd2.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
				cmd2.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
				cmd2.Parameters.AddWithValue("@genre", genres);
				cmd2.Parameters.AddWithValue("@current_stock", current_stock.ToString());
				cmd2.Parameters.AddWithValue("@book_img_link", filepath);


				cmd2.ExecuteNonQuery();
				con.Close();
				Response.Write("<script>alert('Updated Successfully')</script>");
				clearform();
				GridView1.DataBind();
			}
			else
			{
				Response.Write("<script>alert('No data present with that ID')</script>");
				clearform();
			}
		}

		void getbookbyid()
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim()+"';", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				TextBox2.Text = dt.Rows[0]["book_name"].ToString();
				DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString();
				DropDownList2.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
				DropDownList3.SelectedValue = dt.Rows[0]["author_name"].ToString();
				TextBox3.Text = dt.Rows[0]["publish_date"].ToString();
				string[] genre= dt.Rows[0]["genre"].ToString().Trim().Split(',');
				ListBox1.ClearSelection();
				for(int i = 0; i < genre.Length; i++)
				{
					for(int j = 0; j < ListBox1.Items.Count; j++)
					{
						if (ListBox1.Items[j].ToString() == genre[i])
						{
							ListBox1.Items[j].Selected = true;
						}
					}
				}

				TextBox9.Text = dt.Rows[0]["edition"].ToString();
				TextBox10.Text = dt.Rows[0]["book_cost"].ToString().Trim();
				TextBox11.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
				TextBox4.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
				TextBox5.Text = dt.Rows[0]["current_stock"].ToString().Trim();
				TextBox7.Text = ""+(Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString())- Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
				TextBox6.Text = dt.Rows[0]["book_description"].ToString();

				global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
				global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
				global_issued_book = global_actual_stock - global_current_stock;
				global_filepath = dt.Rows[0]["book_img_link"].ToString();


			}
			else
			{
				Response.Write("<script>alert('No data present with that ID')</script>");
				clearform();
			}
			
		}



		void fillauthorpublishervalues()
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT author_name FROM author_master_tbl;", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			DropDownList3.DataSource = dt;
			DropDownList3.DataValueField = "author_name";
			DropDownList3.DataBind();

			cmd = new SqlCommand("SELECT publisher_name FROM publisher_master_tbl;", con);
			da = new SqlDataAdapter(cmd);
			DataTable dt2 = new DataTable();
			da.Fill(dt2);
			DropDownList2.DataSource = dt2;
			DropDownList2.DataValueField = "publisher_name";
			DropDownList2.DataBind();
		}



		bool bookexists()
		{
			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed) { con.Open(); }
			SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' OR book_name ='" + TextBox2.Text.Trim() + "' ;", con);
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataTable dt = new DataTable();
			da.Fill(dt);
			if (dt.Rows.Count >= 1)
			{
				return true;
			}
			else
			{
				return false;
			}
		}



		void addnewbook()
		{
			string genres = "";
			foreach(int i in ListBox1.GetSelectedIndices())
			{
				genres = genres + ListBox1.Items[i]+",";
			}
			genres= genres.Remove(genres.Length-1);

			string filepath = "~/books/books.png";
			string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
			FileUpload1.SaveAs(Server.MapPath("books/" + filename));
			filepath = "books/" + filename;

			SqlConnection con = new SqlConnection(strcon);
			if (con.State == System.Data.ConnectionState.Closed)
			{
				con.Open();
			}
			SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,genre,author_name,publisher_name,publish_date,language,edition,book_cost,no_of_pages,book_description,actual_stock,current_stock,book_img_link) values(@book_id,@book_name,@genre,@author_name,@publisher_name,@publish_date,@language,@edition,@book_cost,@no_of_pages,@book_description,@actual_stock,@current_stock,@book_img_link)", con);
			cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
			cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
			cmd.Parameters.AddWithValue("@genre", genres);//
			cmd.Parameters.AddWithValue("@author_name", DropDownList3.SelectedItem.Value);
			cmd.Parameters.AddWithValue("@publisher_name", DropDownList2.SelectedItem.Value);
			cmd.Parameters.AddWithValue("@publish_date", TextBox3.Text.Trim());
			cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
			cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
			cmd.Parameters.AddWithValue("@book_cost", TextBox10.Text.Trim());
			cmd.Parameters.AddWithValue("@no_of_pages", TextBox11.Text.Trim());
			cmd.Parameters.AddWithValue("@book_description", TextBox6.Text.Trim());
			cmd.Parameters.AddWithValue("@actual_stock", TextBox4.Text.Trim());
			cmd.Parameters.AddWithValue("@current_stock", TextBox5.Text.Trim());
			cmd.Parameters.AddWithValue("@book_img_link", filepath);

			cmd.ExecuteNonQuery();
			con.Close();
			clearform();
			Response.Write("<script>alert('updated book into inventory');</script>");
		}

		void clearform()
		{
			TextBox1.Text = "";
			TextBox2.Text = "";
			TextBox3.Text = "";
			TextBox4.Text = "";
			TextBox5.Text = "";
			TextBox6.Text = "";
			TextBox7.Text = "";
			TextBox9.Text = "";
			TextBox10.Text = "";
			TextBox11.Text = "";
			DropDownList1.ClearSelection();
			DropDownList2.ClearSelection();
			DropDownList3.ClearSelection();
		}
	}
}