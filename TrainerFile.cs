using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class TrainerFile
    {
        public Trainer[] trainer;

        public TrainerFile(Trainer[] trainer)
        {
            this.trainer = trainer;
            GetAllTrainers();
        }

        // retrieves all the trainers in the trainer file
        public void GetAllTrainers(){
            Trainer.SetCount(0);
            StreamReader inFile = new StreamReader("trainers.txt");
            string input = inFile.ReadLine();
            while(input != null && input != ""){
                string [] temp = input.Split('#');
                int tempId = int.Parse(temp[0]);
                bool tempIsDeleted = bool.Parse(temp[4]);
                trainer[Trainer.GetCount()] = new Trainer(tempId, temp[1], temp[2], temp[3], tempIsDeleted);
                Trainer.IncCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }

        // allows the operator to create a trainer
        public void AddTrainer(){
            Trainer myTrainer = new Trainer();
            System.Console.WriteLine("Please enter trainer ID: ");
            myTrainer.SetTrainerID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter new trainer name: ");
            myTrainer.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter mailing address: ");
            myTrainer.SetTrainerAddress(Console.ReadLine());
            System.Console.WriteLine("Please enter email address: ");
            myTrainer.SetTrainerEmail(Console.ReadLine());
        
            trainer[Trainer.GetCount()] = myTrainer;
            System.Console.WriteLine(Trainer.GetCount());
            Trainer.IncCount();
            Save();
        }

        // saves back into the trainer file
        public void Save(){
            StreamWriter outFile = new StreamWriter("trainers.txt");
            for(int i = 0; i < Trainer.GetCount(); i++){
                outFile.WriteLine(trainer[i].ToFile());
            }
            outFile.Close();

        }

        // finds the trainer name and checks to see if what was typed into the console was correct
       public int Find(string searchVal){
            System.Console.WriteLine(Trainer.GetCount());
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainer[i].GetTrainerName() == searchVal)
                {
                    return i;
                }
            }

            return -1;
        }

        // finds the trainer id and checks to see if what was typed into the console was correct
        public int TrainerFind(int searchVal){
            System.Console.WriteLine(Trainer.GetCount());
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(trainer[i].GetTrainerID() == searchVal){
                    return i;
                }
            }

            return -1;
        }
        //updates the trainer information in the file 

        public void UpdateTrainer(){
            System.Console.WriteLine("What is the ID of the Trainer you would like to update?");
            int searchVal = int.Parse((Console.ReadLine()));
            int foundIndex = TrainerFind(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the updated Trainer name: ");
                trainer[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated mailing address: ");
                trainer[foundIndex].SetTrainerAddress(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated email: ");
                trainer[foundIndex].SetTrainerEmail(Console.ReadLine());

                Save();
            }
            else
            {
                System.Console.WriteLine("The Trainer ID is invalid :(");
            }
        }


        //creates a soft delete in the file
        public void Delete(){
            System.Console.WriteLine("What is the ID of the Trainer you would like to delete");
            int searchVal = int.Parse((Console.ReadLine()));
            int foundIndex = TrainerFind(searchVal);

            if(foundIndex != -1){
                trainer[foundIndex].Delete();
                Save();
            }
            else{
                System.Console.WriteLine("The Trainer ID is invalid :(");
            }
        }

    }
}