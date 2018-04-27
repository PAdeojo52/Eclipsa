using Eclipsa.BLL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eclipsa
{
    public partial class Trainees : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MySwoleMateConnectionString"].ToString();
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }
        protected void TraineeList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int traineeID = Convert.ToInt32(TraineeList.DataKeys[e.RowIndex].Value.ToString());
            TraineeBLL bll = new TraineeBLL(connectionString);
            bll.DeleteTrainee(traineeID);
            BindData();
        }

        private void BindData()
        {
            TraineeBLL trainee = new TraineeBLL(connectionString);
            TraineeList.DataSource = trainee.GetAllTrainees();
            TraineeList.DataBind();
        }
    }
}