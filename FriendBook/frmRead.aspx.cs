using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace FriendBook
{
    public partial class frmRead : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            myCon = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb; Persist Security Info = True");
            myCon.Open();
            int refM = Convert.ToInt16(Request.QueryString["refM"]);
            string refU = Request.QueryString["refU"];
            
            OleDbCommand myCmd = new OleDbCommand("SELECT Title, Message, CreatedDate FROM Messages WHERE RefMessage=@refM", myCon);
            myCmd.Parameters.AddWithValue("refM", refM);
            OleDbDataReader rd = myCmd.ExecuteReader();
            while (rd.Read())
            {
                lblTitle.Text = rd["Title"].ToString();
                lblMessage.Text = rd["Message"].ToString();
                lblFrom.Text = refU;
                lblDate.Text = rd["CreatedDate"].ToString();
            }


        }
    }
}