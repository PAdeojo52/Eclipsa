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
    public partial class EditWorkout : System.Web.UI.Page
    {
        WorkoutBLL bll = new WorkoutBLL(ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WorkoutViewModel workout = bll.GetWorkoutById(Convert.ToInt32(Request.QueryString["WorkoutID"]));
             
               
            }
            
        }

        protected void WorkoutEditButton_Click(object sender, EventArgs e)
        {
            if(Page.IsValid)
            {
                WorkoutViewModel workout = new WorkoutViewModel();

                workout.WorkoutID = Convert.ToInt32(Request.QueryString["WorkoutID"]);


                workout.Mac = Workout.Text;


                workout.Make = Step1Box.Text;
                workout.Model = Sets1.Text;


               

               




              
                bll.EditWorkout(workout);
                Response.Redirect("~/Workout.aspx");

            }

        }
    }
}