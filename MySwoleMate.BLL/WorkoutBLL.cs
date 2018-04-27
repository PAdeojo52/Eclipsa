using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eclipsa.DAL;
using Eclipsa.Models;

namespace Eclipsa.BLL
{
   public  class WorkoutBLL
    {


        
        private WorkoutDAL data;

       
        public WorkoutBLL(string connectionString)
        {
            data = new WorkoutDAL(connectionString);
        }

       
        public List<WorkoutViewModel> GetAllWorkouts()
        {
            List<WorkoutViewModel> workout = data.GetWorkout();
            
            return workout;
        }

      
        public WorkoutViewModel GetWorkoutById(int id)
        {
            return data.GetWorkoutById(id);
        }

       
        public int EditWorkout(WorkoutViewModel edit)
        {
            return data.EditWorkout(edit);
        }

        
        public int AddWorkout(WorkoutViewModel add)
        {
            return data.AddWorkout(add);
        }

        
        public int DeleteWorkout(int id)
        {
            return data.DeleteWorkout(id);
        }

        
    }


}

