using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.IO;
using System.Text;
namespace FriendBook
{
    public partial class frmSignUp : System.Web.UI.Page
    {
        static OleDbConnection myCon;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                myCon = new OleDbConnection("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = C:\\Users\\Joonwoo\\source\\repos\\FriendBook\\FriendBook\\App_Data\\dbFriendbook.mdb; Persist Security Info = True");
                myCon.Open();

                FillLanguage();
                FillCity();
                FillRace();
            }
            
        }
        
        private void FillLanguage()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Languages ORDER BY [Language]", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            chkLang.DataTextField = "Language";
            chkLang.DataValueField = "Language";
            chkLang.DataSource = rd;
            chkLang.DataBind();
            
        }
        private void FillCity()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Cities ORDER BY City", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            while (rd.Read())
            {
                cboCity.DataTextField = "City";
                cboCity.DataValueField = "City";
                cboCity.DataSource = rd;
                cboCity.DataBind();
                cboCity.Items.Insert(0, new ListItem("=Select a city=", "0"));
            }
        }
        private void FillRace()
        {
            OleDbCommand myCmd = new OleDbCommand("SELECT * FROM Race ORDER BY Race", myCon);
            OleDbDataReader rd = myCmd.ExecuteReader();
            while (rd.Read())
            {
                cboRace.DataTextField = "Race";
                cboRace.DataValueField = "Race";
                cboRace.DataSource = rd;
                cboRace.DataBind();
                cboRace.Items.Insert(0, new ListItem("=Select an ethnicity=", "0"));
            }
        }
        private string GetLanguage()
        {
            string lang = "";
            foreach (ListItem item in chkLang.Items)
            {
                if (item.Selected==true)
                {
                    lang += item.Value + ",";
                }
            }
            lang = lang.Substring(0, lang.Length - 1);
            return lang;
        }
        private void SignUp()
        {
            OleDbCommand validate = new OleDbCommand("SELECT UserName FROM Users WHERE UserName = @un", myCon);
            validate.Parameters.AddWithValue("un", txtUsername.Text);
            OleDbDataReader rd = validate.ExecuteReader();
            if (!rd.Read())
            {
                OleDbCommand myCmd = new OleDbCommand("INSERT INTO [Users] (UserName, [Password], FirstName, LastName, Gender, Race, Age, City, [Language]) VALUES (@un, @pw, @fn, @ln, @gen, @race, @age, @city, @lang)", myCon);
                myCmd.Parameters.AddWithValue("un", txtUsername.Text);
                myCmd.Parameters.AddWithValue("pw", txtPassword.Text);
                myCmd.Parameters.AddWithValue("fn", txtFirstName.Text);
                myCmd.Parameters.AddWithValue("ln", txtLastName.Text);
                myCmd.Parameters.AddWithValue("gen", radGroupGender.SelectedItem.ToString());
                myCmd.Parameters.AddWithValue("race", cboRace.SelectedItem.ToString());
                myCmd.Parameters.AddWithValue("age", Convert.ToInt32(txtAge.Text));
                myCmd.Parameters.AddWithValue("city", cboCity.SelectedItem.ToString());
                myCmd.Parameters.AddWithValue("lang", GetLanguage());
                int query = myCmd.ExecuteNonQuery();
                Response.Redirect("frmSignupVerify.aspx");
            }
            else
            {
                lblMsg.Text = "User already exists!";
            }
            

        }

        protected void btnSignup_Click(object sender, EventArgs e)
        {
            SignUp();
        }
    }
}