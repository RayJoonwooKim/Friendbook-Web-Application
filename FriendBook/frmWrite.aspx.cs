using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace FriendBook
{
    public partial class frmWrite : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        static int receiver;
        static string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb;Persist Security Info=True");
                myCon.Open();
                username = Session["receiver"].ToString();

                txtTo.Text = username;
                
            }
            
            
        }
        private void SendMessage()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT refUser FROM Users WHERE UserName IN (" + username + ")", myCon);
            
            OleDbDataReader rd = myCmd.ExecuteReader();

            string title = txtTitle.Text;
            string msg = txtMessage.Text;
            int sender = Convert.ToInt16(Session["refU"]);
     
            string sql = "";
            
            while (rd.Read())
            {
                sql += "INSERT INTO Messages (Title, Message, Sender, Receiver) VALUES (@title, @msg, @sender, " + rd["refUser"].ToString() + ");";
            }
            
            
            OleDbCommand myCmd2 = new OleDbCommand(sql, myCon);
            myCmd2.Parameters.AddWithValue("title", title);
            myCmd2.Parameters.AddWithValue("msg", msg);
            myCmd2.Parameters.AddWithValue("sender", sender);
            
            int queryID = myCmd2.ExecuteNonQuery();

            Response.Redirect("frmWriteVerify.aspx");
            //string confirm = "Message sent successfully!";
            //ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + confirm + "');", true);
            //Response.Redirect(Request.UrlReferrer.ToString());
        }
        
        protected void btnSend_Click(object sender, EventArgs e)
        {
            
            SendMessage();
        }
    }
}