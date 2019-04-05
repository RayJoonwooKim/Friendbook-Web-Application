using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

namespace FriendBook
{
    public partial class frmInbox : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        static int refU;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                refU = Convert.ToInt16(Session["refU"]);
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb;Persist Security Info=True");
                myCon.Open();
                litInbox.Text = refU.ToString();


                OleDbDataReader rd = GetMessages();

                litInbox.Text = "<table width='600'>" +
                                       "<tr>" +  
                                         "<td>Message #</td>" +
                                         "<td>Sender</td>" +
                                         "<td>Title</td>" +
                                         
                                          "<td>Date</td>" +
                                          "<td>Actions</td>" +
                                     "</tr>";

                while (rd.Read())
                {

                    litInbox.Text += "<tr>";
                    litInbox.Text += "<td>" + rd["RefMessage"].ToString() + "</td>";
                    litInbox.Text += "<td>" + rd["UserName"].ToString() + "</td>";
                    litInbox.Text += "<td>" + rd["Title"].ToString() + "</td>";
                    
                    litInbox.Text += "<td>" + rd["CreatedDate"].ToString() + "</td>";
                    litInbox.Text += "<td><a href='frmRead.aspx?refM=" + rd["RefMessage"].ToString() + "&refU=" + rd["UserName"].ToString() + "'>Read</a>" + "  " +
                                          "<a href='frmDeleteSingleMsg.aspx?refM=" + rd["RefMessage"].ToString() + "&refU=" + rd["UserName"].ToString() + "'>Delete</a>" +
                                    "</td>";
                    litInbox.Text += "</tr>";

                }
                litInbox.Text += "</table>";

                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Messages WHERE Receiver = @refU", myCon);
                myCmd.Parameters.AddWithValue("refU", refU);
                OleDbDataReader rd2 = myCmd.ExecuteReader();

                chkDeleteMsg.DataTextField = "RefMessage";
                chkDeleteMsg.DataValueField = "RefMessage";
                chkDeleteMsg.DataSource = rd2;
                chkDeleteMsg.DataBind();
                



            }

            
        }

        private OleDbDataReader GetMessages()
        {
            //Message Info
            OleDbCommand myCmd = new OleDbCommand("SELECT Users.refUser, Users.UserName, Messages.RefMessage, Messages.Title, Messages.Message, Messages.CreatedDate, Messages.Sender, Messages.Receiver FROM Messages, Users WHERE Receiver = @refU AND Users.refUser = Messages.Sender", myCon);
            myCmd.Parameters.AddWithValue("refU", refU);
            OleDbDataReader rd = myCmd.ExecuteReader();
            return rd;
        }
        private void DisplayDelete(OleDbDataReader rd)
        {
            chkDeleteMsg.DataTextField = "RefMessage";
            chkDeleteMsg.DataValueField = "RefMessage";
            chkDeleteMsg.DataSource = rd;
            chkDeleteMsg.DataBind();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM Messages WHERE RefMessage IN (";
            foreach (ListItem item in chkDeleteMsg.Items)
            {
                if (item.Selected)
                {
                    sql += item.Value + ",";
                }
            }
            sql = sql.Substring(0, sql.Length - 1);
            sql += ")";
            OleDbCommand myCmd = new OleDbCommand(sql, myCon);
            int query = myCmd.ExecuteNonQuery();
            if (query > 0)
            {
                Response.Redirect("frmDelete.aspx");
            }

        }
    }
}