using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication7
{
    public partial class changepassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string name = "";
            SqlConnection con = new SqlConnection("uid=sa;password=123;database=scarLife;server=VDILEWVPNTH516");
            con.Open();
            SqlCommand cmd = new SqlCommand("select Password from AdminLogin where UserName='" + TextBox1.Text + "' ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            if (ds.Tables[0].Rows.Count > 0)
            {
                name = ds.Tables[0].Rows[0][0].ToString();
            }



            if (TextBox2.Text == name && TextBox3.Text == TextBox4.Text)
            {
                SqlCommand cmd1 = new SqlCommand("Update AdminLogin set password='" + TextBox3.Text + "' where UserName='" + TextBox1.Text + "' ", con);
                int i = cmd1.ExecuteNonQuery();
                Label6.Text = "Updated " + TextBox1.Text + " Sucessfully";
            }
            else if (TextBox2.Text != name)
            {
                Label6.Text = "Previous Password Is Wrong!. Try Again";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("afterlogin.aspx");
        }
    }
}