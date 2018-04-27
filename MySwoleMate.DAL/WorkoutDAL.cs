using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipsa.Models;

namespace Eclipsa.DAL
{
    public class WorkoutDAL
    {
        private string _connectionString;
        public WorkoutDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

      
        public List<WorkoutViewModel> GetWorkout()
        {
            string sqlQuery = "SELECT*FROM Equipment;";

            List<WorkoutViewModel> workout = new List<WorkoutViewModel>();

           
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        WorkoutViewModel temp = new WorkoutViewModel()
                        {
                            WorkoutID = Convert.ToInt32(reader["WorkoutID"]),

                            Mac = reader["MAC"].ToString(),

                            Make = reader["Make"].ToString(),


                            Model = reader["Model"].ToString(),



                            IsCheckedOut = reader["ISCheckedOut"].ToString(),





                            TraineeID = Convert.ToInt32(reader["TraineeID"])




                         


                        };
                        workout.Add(temp);
                    }
                }
            }
            return workout;
        }


        public int AddWorkout(WorkoutViewModel add)
        {
           
            string sqlQuery =
                "INSERT into Equipment (WorkoutID , MAC, Make, Model, " +
                "IsCheckedOut, TraineeID" +
                 ") VALUES (@WorkoutID , @MAC, @Make, @Model, " +
                "@IsCheckedOut,  @TraineeID ) " ;
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();

                cmd.Parameters.Add("@WorkoutID", SqlDbType.VarChar).Value = add.WorkoutID;

                cmd.Parameters.Add("@MAC", SqlDbType.VarChar).Value = add.Mac;

                cmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = add.Make;



                cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = add.Model;




                cmd.Parameters.Add("@IsCheckedOut", SqlDbType.VarChar).Value = add.IsCheckedOut;

                cmd.Parameters.Add("@TraineeID", SqlDbType.VarChar).Value = add.TraineeID;










                return cmd.ExecuteNonQuery();
            }
        }





        public int DeleteWorkout(int id)
        {
            string sqlQuery = "DELETE from Equipment Where WorkoutID=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                return cmd.ExecuteNonQuery();
            }
        }




        public int EditWorkout(WorkoutViewModel edit)
        {
            string sqlQuery = "Update Equipment Set Mac = @MAC , Make=@Make ,Model=@Model " +
               
                "Where WorkoutID=@WorkoutID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                 cmd.Parameters.Add("@WorkoutID", SqlDbType.VarChar).Value = edit.WorkoutID;




                cmd.Parameters.Add("@MAC", SqlDbType.VarChar).Value = edit.Mac;
                cmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = edit.Make;
                cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = edit.Model;
               
                return cmd.ExecuteNonQuery();
            }
        }





        public WorkoutViewModel GetWorkoutById(int id)
        {
            WorkoutViewModel workout = new WorkoutViewModel();
            string sqlQuery = "SELECT * FROM Equipment WHERE WorkoutID=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {

                        workout.WorkoutID = Convert.ToInt32(reader["WorkoutID"]);


                        workout.Mac = reader["MAC"].ToString();


                        workout.Make = reader["Make"].ToString();


                        workout.Model = reader["Model"].ToString();


                        workout.IsCheckedOut = reader["IsCheckedOut"].ToString();



                    }
                }
                return workout;
            }















        }
    }


   
}
