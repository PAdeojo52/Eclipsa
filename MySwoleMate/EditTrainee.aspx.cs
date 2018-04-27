using Eclipsa.BLL;
using Eclipsa.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eclipsa
{
    public partial class EditTrainee : System.Web.UI.Page
    {
       
        TraineeBLL bll = new TraineeBLL(ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString());
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
             
                TraineeViewModel trainee = bll.GetTraineeById(Convert.ToInt32(Request.QueryString["TraineeID"]));
               
                FirstName.Text = trainee.FirstName;
                LastName.Text = trainee.LastName;
                Email.Text = trainee.Email;
                Height.Text = trainee.Height.ToString();
                Weight.Text = trainee.Weight.ToString();
                CellNbr.Text = trainee.CellNbr;
                Gender.SelectedValue = trainee.Gender;
                Age.Text = trainee.Age.ToString();
            }
        }

        protected void TraineeEditButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                TraineeViewModel trainee = new TraineeViewModel();
                trainee.TraineeID = Convert.ToInt32(Request.QueryString["TraineeID"]);
                trainee.FirstName = FirstName.Text;
                trainee.LastName = LastName.Text;
                trainee.Email = Email.Text;
                trainee.Height = Convert.ToInt32(Height.Text);
                trainee.Weight = Convert.ToInt32(Weight.Text);
                trainee.CellNbr = CellNbr.Text;
                trainee.Gender = Gender.SelectedValue;
                trainee.Age = Convert.ToInt32(Age.Text);
                bll.EditTrainee(trainee);
                Response.Redirect("~/Trainees.aspx");
            }
        }
    }
}