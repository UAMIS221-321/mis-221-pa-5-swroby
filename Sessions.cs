using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class Sessions
    {

        public int sessionID;
        public int trainerID;
        public string trainerName;
        public DateOnly sessionDate;
        public string customerName;
        public string customerEmail;
        public string status;
        private bool tempIsDeleted;
        private static int count;
        public Sessions(){

        }
        // overloaded constructor

        public Sessions(int sessionID, int trainerID,string trainerName,DateOnly sessionsDate, string customerName, string customerEmail, string status, bool tempIsDeleted){
            this.sessionID = sessionID;
            this.trainerID= trainerID;
            this.trainerName = trainerName;
            this.sessionDate = sessionsDate;
            this.customerName= customerName;
            this.customerEmail= customerEmail;
            this.status = status;
        }

        //Accessors and Mutators
        public void SetSessionID(int sessionID){
            this.sessionID = sessionID;
        }
        public int GetSessionID(){
            return sessionID;
        }
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
       
        public void SetSessionDate(DateOnly sessionDate){
            this.sessionDate = sessionDate;
        }
        public DateOnly GetSessionDate(){
            return sessionDate;
        }
        
        public void SetCustomerName(string customerName){
            this.customerName = customerName;
        }
        public string GetCustomerName(){
            return customerName;
        }
        public void SetCustomerEmail(string customerEmail){
            this.customerEmail = customerEmail;
        }
        public string GetCustomerEmail(){
            return customerEmail;
        }
        public void SetStatus(string status){
            this.status = status;
        }
        public string GetStatus(){
            return status;
        }
        public static void SetCount(int count){
            Sessions.count = count;
        }

        static public void IncCount(){
            Sessions.count++;
        }

        public static int GetCount(){
            return count;
        }
        public void SetDelete(bool tempIsDeleted){
            this.tempIsDeleted = tempIsDeleted;
        }
        public bool GetDelete(){
            return tempIsDeleted;
        }

        public void Delete(){
            tempIsDeleted = !tempIsDeleted;
        }

        // this is what is shown to the user
        public override string ToString(){
            return $"\t{sessionID}\t{trainerID}\t{trainerName}\t{sessionDate}\t{customerName}\t{customerEmail}\t{status}\t{tempIsDeleted}";
        }
        // this is what is printed in the file
        public string ToFile(){
            return $"#{sessionID}#{trainerID}#{trainerName}#{sessionDate}#{customerName}#{customerEmail}#{status}#{tempIsDeleted}";
        }
        // this is what is shown to the user
        public string HistoricalString()
        {
            return $"\t{customerName}\t{sessionDate}";
        }
    }
}
