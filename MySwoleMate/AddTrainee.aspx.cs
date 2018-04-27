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
    public partial class AddTrainee : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TraineeAddButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString();
                TraineeBLL bll = new TraineeBLL(connectionString);
                TraineeViewModel trainee = new TraineeViewModel();
                trainee.NineNumber = NineNumber.Text;
                trainee.FirstName = FirstName.Text;
                trainee.LastName = LastName.Text;
                trainee.Email = Email.Text;
                trainee.Height = Convert.ToInt32(Height.Text);
                trainee.Weight = Convert.ToInt32(Weight.Text);
                trainee.CellNbr = CellNbr.Text;
                trainee.Gender = Gender.SelectedValue;
                trainee.Age = Convert.ToInt32(Age.Text);
                bll.AddTrainee(trainee);
                Response.Redirect("~/Trainees.aspx");
            }
        }
    }
}