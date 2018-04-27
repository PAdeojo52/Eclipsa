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
    public partial class AddWorkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


       protected void WorkoutAddButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString();

                WorkoutBLL bll = new WorkoutBLL(connectionString);

                WorkoutViewModel workout = new WorkoutViewModel();
               

                workout.Mac = Workout.Text;


                workout.Make = Step1Box.Text;
                workout.Model = Sets1.Text;
                workout.IsCheckedOut = "False";

                workout.TraineeID = 0;


                Random rnd = new Random();
                workout.WorkoutID = rnd.Next(0, 3000);
              



                bll.AddWorkout(workout);

                Response.Redirect("~/Workout.aspx");




            }

        }
    }
}