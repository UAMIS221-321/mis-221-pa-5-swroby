using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class Listing
    {
        public int listingID;
        private string listingStyle;
        private string trainerName;
        private DateOnly date;
        private string time;
        private double cost;
        private string availability;
        private static int count;
        private bool tempIsDeleted = false;
        // no arg constructor

        public Listing(){

        }
        // overloaded constructor

        public Listing(int listingID, string listingStyle, string trainerName, DateOnly date, string time, double cost, string availability, bool tempIsDeleted){
            this.listingID = listingID;
            this.listingStyle = listingStyle;
            this.trainerName = trainerName;
            this.date = date;
            this.time = time;
            this.cost = cost;
            this.availability = availability;

        }
        //Accessors and Mutators
        public int GetListingID(){
            return listingID;
        }
        public void SetListingID(int listingID){
            this.listingID = listingID;
        }
        public int GetLisitngStyle(){
            return listingID;
        }
        public void SetListingStyle(string listingStyle){
            this.listingStyle = listingStyle;
        }
        public string GetTrainerName(){
            return trainerName;
        }
        public void SetTrainerName(string trainerName){
            this.trainerName = trainerName;
        }
        public DateOnly GetDate(){
            return date;
        }
        public void SetDate(DateOnly date){
            this.date = date;
        }
        public string GetTime(){
            return time;
        }
        public void SetTime(string time){
            this.time = time;
        }
        public double GetCost(){
            return cost;
        }
        public void SetCost(double cost){
            this.cost = cost;
        }
        public string GetAvailability(){
            return availability;
        }
        public void SetAvailability(string availability){
            this.availability = availability;
        }

        static public void SetCount(int count){
            Listing.count = count;
        }

        static public void IncCount(){
            Listing.count++;
        }
        static public void DecCount(){
            Listing.count--;
        }

        static public int GetCount(){
            return Listing.count;
        }
        public void SetDelete(bool tempIsDeleted){
            this.tempIsDeleted = tempIsDeleted;
        }
        public bool GetDelete(){
            return tempIsDeleted;
        }

        // this is what is shown to the user
        public override string ToString(){
            return $"The class you have listed is {listingID} {listingStyle}.\n It is being instructed by {trainerName} on {date} at {time} and is priced at {cost}";
        }

        // this is what is written in the file
        public string ToFile(){
            return $"{listingID}#{listingStyle}#{trainerName}#{date}#{time}#{cost}#{availability}#{tempIsDeleted}";
        }
        public void Delete(){
            tempIsDeleted = !tempIsDeleted;
        }

    }
}