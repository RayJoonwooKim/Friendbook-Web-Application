using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace FriendBook
{
    public partial class frmLogin : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb;Persist Security Info=True");
                myCon.Open();

                lblSignin.Text = "<a href='frmSignUp.aspx'>Don't have an account?</a>";

            }
            

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            
            
        }
        
        
        protected void btnSignin_Click(object sender, EventArgs e)
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Users WHERE UserName=@un AND Password=@pw", myCon);
            myCmd.Parameters.AddWithValue("un", txtUsername.Text);
            myCmd.Parameters.AddWithValue("pw", txtPassword.Text);
            OleDbDataReader rd = myCmd.ExecuteReader();

            if (rd != null)
            {
                while (rd.Read())
                {
                    Session["refU"] = rd["refUser"];
                    Session["un"] = rd["UserName"];
                    Response.Redirect("frmUI.aspx");

                }

            }
            lblLoginFail.Text = "Username or password is wrong!";
            
        }
    }
}