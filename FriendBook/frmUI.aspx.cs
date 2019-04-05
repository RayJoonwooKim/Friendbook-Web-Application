using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
namespace FriendBook
{
    public partial class frmUI : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        static OleDbDataReader userInfo;
        static OleDbDataReader searchResults;
        static OleDbCommand cmdSearch;
        static int refU;
        static string un;
        static string sql;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                refU = Convert.ToInt32(Session["refU"]);
                un = Session["un"].ToString();
                lblGreet.Text = "Welcome, " + un + "!";
                lblViewMessage.Text = "<a href='frmInbox.aspx'>Inbox</a>";
                lblEditProfile.Text = "<a href='frmEditProfile.aspx'>Profile</a>";
                myCon = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb;Persist Security Info=True");
                myCon.Open();

                //Login User Info
                OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Users WHERE RefUser=@refU", myCon);
                myCmd.Parameters.AddWithValue("refU", refU);
                userInfo = myCmd.ExecuteReader();

                //Load Search Criteria
                LoadGender();
                LoadCity();
                LoadLanguage();
                LoadRace();

                panSend.Visible = false;
                btnSend.Visible = false;
                lblSearchResults.Visible = false;

            }
            

        }
        private void LoadGender()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT GenderType FROM Gender", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            radGender.DataTextField = "GenderType";
            radGender.DataValueField = "GenderType";
            radGender.DataSource = rd;
            radGender.DataBind();
        }
        private void LoadCity()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT City FROM Cities ORDER BY City", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            cboCity.DataTextField = "City";
            cboCity.DataValueField = "City";
            cboCity.DataSource = rd;
            cboCity.DataBind();
            cboCity.Items.Insert(0, new ListItem("=Select a city=", "0"));
        }
        private void LoadLanguage()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT [Language] FROM Languages ORDER BY [Language]", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            chkLanguage.DataTextField = "Language";
            chkLanguage.DataValueField = "Language";
            chkLanguage.DataSource = rd;
            chkLanguage.DataBind();
        }
        private void LoadRace()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT Race FROM Race ORDER BY Race", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            cboRace.DataTextField = "Race";
            cboRace.DataValueField = "Race";
            cboRace.DataSource = rd;
            cboRace.DataBind();
            cboRace.Items.Insert(0, new ListItem("=Select an ethnicity=", "0"));
        }
        private OleDbDataReader SearchUser()
        {
           
            sql = "SELECT UserName AS [Username], FirstName AS [First Name], LastName AS [Last Name], Gender, Race, Age, City, [Language] FROM Users WHERE refUser <> @refU AND ";
            
            string gender = radGender.SelectedValue.ToString();
            string race = cboRace.SelectedValue.ToString();
            string city = cboCity.SelectedValue.ToString();
            
            string language = "";
            bool isLangSelected = false;
            cmdSearch = new OleDbCommand();
            cmdSearch.Parameters.AddWithValue("refU", refU);
            foreach (ListItem item in radGender.Items)
            {
                if (item.Selected)
                {
                    sql += "Gender=@gender AND ";
                    cmdSearch.Parameters.AddWithValue("gender", gender);
                }
            }
            if (cboRace.SelectedIndex != 0)
            {
                foreach (ListItem item in cboRace.Items)
                {
                    if (item.Selected)
                    {
                        sql += "Race=@race AND ";
                        cmdSearch.Parameters.AddWithValue("race", race);
                    }
                }
            }
            
            if (txtFrom.Text != "" && txtTo.Text != "")
            {
                sql += "(Age BETWEEN @age_from AND @age_to) AND ";
                cmdSearch.Parameters.AddWithValue("age_from", Convert.ToInt16(txtFrom.Text));
                cmdSearch.Parameters.AddWithValue("age_to", Convert.ToInt16(txtTo.Text));
            }
            if (cboCity.SelectedIndex != 0)
            {
                foreach (ListItem item in cboCity.Items)
                {
                    if (item.Selected)
                    {
                        sql += "City=@city AND ";
                        cmdSearch.Parameters.AddWithValue("city", city);
                    }
                }
            }
            
            foreach (ListItem item in chkLanguage.Items)
            {
                if (item.Selected)
                {
                    language += item.Value.ToString() + ",";
                    isLangSelected = true;
                    
                }
            }
            if (isLangSelected)
            {
                language = language.Substring(0, language.Length - 1);
                sql += "([Language]=@language)";
                cmdSearch.Parameters.AddWithValue("language", language);
            }
            if (sql.Substring(sql.Length-4)=="AND ")
            {
                sql = sql.Substring(0, sql.Length - 4);
            }
            
            cmdSearch.CommandText = sql;
            cmdSearch.Connection = myCon;
            searchResults = cmdSearch.ExecuteReader();

            return searchResults;
            


        }
        private void DisplayCheckBox()
        {
            chkUserList.DataTextField = "UserName";
            chkUserList.DataValueField = "UserName";
            chkUserList.DataSource = SearchUser();
            chkUserList.DataBind();
           
        }
            
        protected void btnTest_Click(object sender, EventArgs e)
        {
            panSend.Visible = true;
            btnSend.Visible = true;
            searchResults = SearchUser();
            
            if (searchResults!=null)
            {
                lblSearchResults.Visible = false;
                gridResults.DataSource = SearchUser();
                gridResults.DataBind();
                DisplayCheckBox();
            }
            else
            {
                lblSearchResults.Visible = true;
                lblSearchResults.Text = "People Not Found!";
            }
            
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            string receiver = "";
            foreach (ListItem item in chkUserList.Items)
            {
                if (item.Selected)
                {
                    receiver += "'" + item.ToString() + "',";
                }
            }
            receiver = receiver.Substring(0, receiver.Length - 1);
            Session["receiver"] = receiver;
            
            Response.Redirect("frmWrite.aspx");
        }
    }
}