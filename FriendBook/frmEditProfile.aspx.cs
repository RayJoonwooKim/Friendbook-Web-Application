using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace FriendBook
{
    public partial class frmEditProfile : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        static int refU;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                lblMsg.Text = "<a href='frmUI.aspx'>Go Back to Main</a>";
                refU = Convert.ToInt16(Session["refU"]);
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb;Persist Security Info=True");
                myCon.Open();
                LoadProfile();
                LoadCity();
            }
        }
        private void LoadCity()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Cities", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            cboCity.DataTextField = "City";
            cboCity.DataValueField = "City";
            cboCity.DataSource = rd;
            cboCity.DataBind();
        }
        private void LoadProfile()
        {
            txtPasswordRe.Text = "";
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Users WHERE refUser = @refU", myCon);
            myCmd.Parameters.AddWithValue("refU", refU);
            OleDbDataReader rd = myCmd.ExecuteReader();
            while (rd.Read())
            {
                txtUsername.Text = rd["UserName"].ToString();
                txtPassword.Text = rd["Password"].ToString();
                txtFirstName.Text = rd["FirstName"].ToString();
                txtLastName.Text = rd["LastName"].ToString();
                txtGender.Text = rd["Gender"].ToString();
                txtRace.Text = rd["Race"].ToString();
                txtAge.Text = rd["Age"].ToString();
                cboCity.Text = rd["City"].ToString();
                txtLanguage.Text = rd["Language"].ToString();
            }
        }
        
        private void UpdateProfile()
        {
            try
            {
                string sql = "UPDATE Users SET [Password]=@pw, Age=@age, City=@city WHERE refUser=@refU";
                OleDbCommand myCmd = new OleDbCommand(sql, myCon);  
                //Make sure to put the parameters in order
                myCmd.Parameters.AddWithValue("pw", txtPasswordRe.Text);
                myCmd.Parameters.AddWithValue("age", Convert.ToInt32(txtAge.Text));
                myCmd.Parameters.AddWithValue("city", cboCity.Text);
                myCmd.Parameters.AddWithValue("refU", refU);
                int query = myCmd.ExecuteNonQuery();
                if (query > 0)
                {
                    lblError.Text = "Updated Successfully!";
                }
                else
                {
                    lblError.Text = "Update Failed!";
                }
            }
            catch (OleDbException ex)
            {
                lblError.Text = ex.Message.ToString();
               
            }
            
            

            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateProfile();
            
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            LoadProfile();
        }
    }
}