using Eclipsa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipsa.DAL
{
    public class TraineeDAL
    {
        private string _connectionString;
        public TraineeDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<TraineeViewModel> GetTrainees()
        {
            string sqlQuery = "SELECT * FROM Trainee";

            List<TraineeViewModel> trainees = new List<TraineeViewModel>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        TraineeViewModel temp = new TraineeViewModel()
                        {
                            TraineeID = Convert.ToInt32(reader["TraineeID"]),
                            NineNumber = reader["NineNumber"].ToString(),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            Height = Convert.ToInt32(reader["Height"]),
                            Weight = Convert.ToInt32(reader["Weight"]),
                            CellNbr = reader["CellNbr"].ToString(),
                            Gender = reader["Gender"].ToString(),
                            Age = Convert.ToInt32(reader["Age"]),
                        };
                        trainees.Add(temp);
                    }
                }
            }
            return trainees;
        }

        public TraineeViewModel GetTraineeById(int id)
        {
            TraineeViewModel trainee = new TraineeViewModel();
            string sqlQuery = "Select * from Trainee where TraineeId=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        trainee.TraineeID = Convert.ToInt32(reader["TraineeID"]);
                        trainee.FirstName = reader["FirstName"].ToString();
                        trainee.LastName = reader["LastName"].ToString();
                        trainee.Email = reader["Email"].ToString();
                        trainee.Height = Convert.ToInt32(reader["Height"]);
                        trainee.Weight = Convert.ToInt32(reader["Weight"]);
                        trainee.CellNbr = reader["CellNbr"].ToString();
                        trainee.Gender = reader["Gender"].ToString();
                        trainee.Age = Convert.ToInt32(reader["Age"]);
                    }
                }
            }
            return trainee;
        }

        public int EditTrainee(TraineeViewModel edit)
        {
            string sqlQuery = "Update Trainee Set FirstName=@FirstName, LastName=@LastName, " +
                "Email=@Email, Height=@Height, Weight=@Weight, CellNbr=@CellNbr, Gender=@Gender, " +
                "Age=@Age Where TraineeID=@ID";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = edit.TraineeID;
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = edit.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = edit.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = edit.Email;
                cmd.Parameters.Add("@Height", SqlDbType.Int).Value = edit.Height;
                cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = edit.Weight;
                cmd.Parameters.Add("@CellNbr", SqlDbType.VarChar).Value = edit.CellNbr;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = edit.Gender;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = edit.Age;
                return cmd.ExecuteNonQuery();
            }
        }

        public int AddTrainee(TraineeViewModel add)
        {
            string sqlQuery = "INSERT into Trainee (FirstName, LastName, Email, Height, " +
                "Weight, CellNbr, Gender, Age) VALUES (@FirstName, @LastName, @Email, @Height, " +
                "@Weight, @CellNbr, @Gender, @Age)";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@FirstName", SqlDbType.VarChar).Value = add.FirstName;
                cmd.Parameters.Add("@LastName", SqlDbType.VarChar).Value = add.LastName;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = add.Email;
                cmd.Parameters.Add("@Height", SqlDbType.Int).Value = add.Height;
                cmd.Parameters.Add("@Weight", SqlDbType.Int).Value = add.Weight;
                cmd.Parameters.Add("@CellNbr", SqlDbType.VarChar).Value = add.CellNbr;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = add.Gender;
                cmd.Parameters.Add("@Age", SqlDbType.Int).Value = add.Age;
                return cmd.ExecuteNonQuery();
            }
        }


        public int CheckedOut(WorkoutViewModel ID)
        {



            string sqlQuery =

            "UPDATE Equipment " +
            "SET ISCheckedOut = @ISCheckedOut where WorkoutID=@ID ";


            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID.WorkoutID;

                cmd.Parameters.Add("@IsCheckedOut", SqlDbType.VarChar).Value = ID.IsCheckedOut;
              

                return cmd.ExecuteNonQuery();
            }

        }
        public int AddWorkoutID(TraineeViewModel ID )
        {



            string sqlQuery = "Update  Trainee Set WorkoutID = @WorkoutID Where TraineeID=@ID ";
           
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID.TraineeID;

              
                cmd.Parameters.AddWithValue("@WorkoutID", SqlDbType.Int).Value = ID.WorkoutID;


              





                WorkoutViewModel temp = new WorkoutViewModel();

                temp.WorkoutID = ID.WorkoutID;
             
                temp.IsCheckedOut = "True";


              

                CheckedOut(temp);
                return cmd.ExecuteNonQuery();
            }
           
           
        }


        public int CheckedIn(WorkoutViewModel ID)
        {



            string sqlQuery ="UPDATE Equipment " +
            "SET ISCheckedOut = @ISCheckedOut where WorkoutID=@ID ";


            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID.WorkoutID;

                cmd.Parameters.Add("@IsCheckedOut", SqlDbType.VarChar).Value = ID.IsCheckedOut;
                return cmd.ExecuteNonQuery();
            }

        }


        public int RemoveWorkoutID(TraineeViewModel ID)
        {

            string sqlQuery = "Update Trainee Set WorkoutID = @WorkoutID Where TraineeID=@ID ";

            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {

                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID.TraineeID;

                Console.WriteLine(ID.WorkoutID);
                cmd.Parameters.AddWithValue("@WorkoutID", SqlDbType.Int).Value = ID.WorkoutID;



                WorkoutViewModel temp = new WorkoutViewModel();

                temp.WorkoutID = ID.WorkoutID;
                temp.IsCheckedOut = "False";
                CheckedIn(temp);

                return cmd.ExecuteNonQuery();
                



            }

        }

           
            public int DeleteTrainee(int id)
        {
            string sqlQuery = "DELETE from Trainee Where TraineeID=@ID";
            using (SqlConnection con = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(sqlQuery, con))
            {
                con.Open();
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                return cmd.ExecuteNonQuery();
            }
        }
    }
}
