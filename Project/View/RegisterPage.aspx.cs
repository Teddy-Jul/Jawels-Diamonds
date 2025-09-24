using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using Project.Utilities;
using Project.Controller;
using System.Drawing;
Set - Content.gitignore ".vs/`nbin/`nobj/`n*.user`n*.suo"
namespace Project.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        UserController UserController = new UserController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int startYear = 1900;
                int endYear = DateTime.Now.Year;
                for (int year = startYear; year <= endYear; year++)
                {
                    ddlYear.Items.Add(new ListItem(year.ToString(), year.ToString()));
                }
                ddlYear.SelectedValue = DateTime.Now.Year.ToString();
            }
        }
        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = int.Parse(ddlYear.SelectedValue);
            calDOB.VisibleDate = new DateTime(selectedYear, calDOB.VisibleDate.Month, 1);
        }

        protected void calDOB_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            ddlYear.SelectedValue = e.NewDate.Year.ToString();
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string gender = rbMale.Checked ? "Male" : rbFemale.Checked ? "Female" : "";
            if (calDOB.SelectedDate == DateTime.MinValue)
            {
                Validation.ForeColor = Color.Red;
                Validation.Text = "Date of Birth is required.";
                return;
            }
            DateTime dob = calDOB.SelectedDate;
            Response<MsUser> response = UserController.ValidateRegister(txtEmail.Text, txtUsername.Text, txtPassword.Text, txtConfirmPassword.Text, gender, dob);
            if (response.statusCode == 200)
            {
                Validation.ForeColor = Color.Green;
                Validation.Text = response.message;
                Response.Redirect("LoginPage.aspx");
            }
            else
            {
                Validation.ForeColor = Color.Red;
                Validation.Text = response.message; 
            }
        }
    }
}