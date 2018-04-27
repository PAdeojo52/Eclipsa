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
    public partial class ViewWorkout : System.Web.UI.Page
    {

        TraineeBLL bll = new TraineeBLL(ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString());

        string connectionString = ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString();
        Dictionary<int, string> workoutplan = new Dictionary<int, string>();

        protected void Page_Load(object sender, EventArgs e)
        {

           

             if (!IsPostBack)
            {

                WorkoutBLL workout = new WorkoutBLL(connectionString);

                foreach (var item in workout.GetAllWorkouts())
                {

                    if (item.IsCheckedOut.Equals("True"))
                    {
                        workoutplan.Add(item.WorkoutID, item.Model);
                    }


                }
                WorkoutID.DataSource = workoutplan;
                WorkoutID.DataValueField = "Key";
                WorkoutID.DataTextField = "Value";



                BindData();

                WorkoutID.Items.Insert(0, "<------Please Select Equipment----->");

            }
        }



        protected void RemoveButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {


                string connectionString = ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString();
                TraineeBLL bll = new TraineeBLL(connectionString);
                TraineeViewModel trainee = bll.GetTraineeById(Convert.ToInt32(Request.QueryString["TraineeID"]));
                trainee.TraineeID = Convert.ToInt32(Request.QueryString["TraineeID"]);
                trainee.WorkoutID = Convert.ToInt32(WorkoutID.SelectedItem.Value);

                bll.RemoveWorkoutID(trainee);
                Response.Redirect("~/Trainees.aspx");


            }
        }



        private void BindData()
        {
            WorkoutID.DataBind();
        }












    }
}