using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class Trainer
    {
        public int trainerID;
        private string trainerName;
        private string address;
        private string email;
        static public int count;
        private bool tempIsDeleted = false;
        
        // no arg constructor

        public Trainer(){

        }
        // overloaded constructor

        public Trainer(int trainerID, string trainerName, string address, string email, bool tempIsDeleted){
            this.trainerID = trainerID;
            this.trainerName = trainerName;
            this.address = address;
            this.email = email;
        }

        //Accessors and Mutators
        public void SetTrainerID(int trainerID){
            this.trainerID = trainerID;
        }
        public int GetTrainerID(){
            return trainerID;
        }
    
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public string GetTrainerName(){
            return trainerName;
        }
       
        public void SetTrainerAddress(string address){
            this.address = address;
        }
        public string GetTrainerAddress(){
            return address;
        }
        
        public void SetTrainerEmail(string email){
            this.email = email;
        }
        public string GetTrainerEmail(){
            return email;
        }
        public void SetDelete(bool tempIsDeleted){
            this.tempIsDeleted = tempIsDeleted;
        }
        public bool GetDelete(){
            return tempIsDeleted;
        }

        static public void SetCount(int count){
            Trainer.count = count;
        }

        static public void IncCount(){
            count++;
        }
        static public void DecCount(){
            count--;
        }

        public static int GetCount(){
            return count;
        }

        // this is what is shown to the user
        public override string ToString(){
            return $"The trainer ID is {trainerID}.\n The trainer name is {trainerName}.\n Their mailing address is {address}.\n You can contact them at {email}.\n ";
        }

        // this is what is sent to the file
        public string ToFile(){
            return $"{trainerID}#{trainerName}#{address}#{email}#{tempIsDeleted}";
        }
        public void Delete(){
            tempIsDeleted = !tempIsDeleted;
        }
    }
}