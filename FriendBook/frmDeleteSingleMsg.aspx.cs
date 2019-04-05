using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace FriendBook
{
    public partial class frmDeleteSingleMsg : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                lblLink.Text = "<a href='frmInbox.aspx'>Go Back to Inbox</a>";
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb;Persist Security Info=True");
                myCon.Open();
                OleDbCommand myCmd = new OleDbCommand("DELETE FROM Messages WHERE RefMessage =@refM", myCon);
                myCmd.Parameters.AddWithValue("refM", Convert.ToInt16(Request.QueryString["refM"]));

                int query = myCmd.ExecuteNonQuery();

                if (query>0)
                {
                    lblMsg.Text = "Message was deleted successfully!";
                }
            }
            
        }
    }
}