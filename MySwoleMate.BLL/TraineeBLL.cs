using Eclipsa.DAL;
using Eclipsa.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eclipsa.BLL
{
    public class TraineeBLL
    {
        private TraineeDAL data;

        public TraineeBLL(string connectionString)
        {
            data = new TraineeDAL(connectionString);
        }

       
        public List<TraineeViewModel> GetAllTrainees()
        {
           
            List<TraineeViewModel> trainees = data.GetTrainees();
            foreach(var item in trainees)
            {
               
                item.DisplayHeight = HeightDisplay(item.Height);
                item.CellNbr = PhoneDisplay(item.CellNbr);
                
            }
            return trainees;
        }

        public TraineeViewModel GetTraineeById(int id)
        {
            return data.GetTraineeById(id);
        }

        public int EditTrainee(TraineeViewModel edit)
        {

            return data.EditTrainee(edit);
        }

        public int AddTrainee(TraineeViewModel add)
        {
            return data.AddTrainee(add);
        }

        public int DeleteTrainee(int id)
        {
            return data.DeleteTrainee(id);
        }


        public int AddWorkoutID(TraineeViewModel id )
        {
            return data.AddWorkoutID(id );
        }

        public int RemoveWorkoutID(TraineeViewModel id )
        {
            return data.RemoveWorkoutID(id);
        }

        
        public string HeightDisplay(int height)
        {
            int fraction = height % 12;
            int whole = height / 12;
            string heightDisplay = whole + "'" + fraction ;
            
            return heightDisplay;
        }
        public string HeightDisplay(string height)
        {
            int shiftHeight = Convert.ToInt32(height);
            int fraction = shiftHeight % 12;
            int whole = shiftHeight / 12;
            string heightDisplay = whole + "'" + fraction;
            return heightDisplay;
        }


        public string PhoneDisplay(string val)
        {
            String First = val.Insert(3, "-");
            String Second = First.Insert(7, "-");

            return Second;

        }
    }
}
