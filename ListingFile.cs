using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class ListingFile
    {
        public Listing[] listing;

        public ListingFile(Listing[] listing)
        {
            this.listing = listing;
            GetAllListing();
        }

        // retrieves all the listings in the listing file
        public void GetAllListing(){
            Listing.SetCount(0);
            StreamReader inFile = new StreamReader("listing.txt");
            string input = inFile.ReadLine();
            while(input != null && input != ""){
                string [] temp = input.Split('#');
                int tempId = int.Parse(temp[0]);
                DateOnly sessionsDate = DateOnly.Parse(temp[3]);
                double cost = double.Parse(temp[5]);
                bool tempIsDeleted = bool.Parse(temp[7]);
                listing[Listing.GetCount()] = new Listing(tempId, temp[1], temp[2], sessionsDate,temp[4],cost,temp[6], tempIsDeleted);
                Listing.IncCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }

        // allows the operator to create a trainer
        public void AddListing(){
            Listing myListing = new Listing();
            System.Console.WriteLine("Please enter the new listing ID: ");
            myListing.SetListingID(int.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter listing style: ");
            myListing.SetListingStyle(Console.ReadLine());
            System.Console.WriteLine("Please enter trainer name: ");
            myListing.SetTrainerName(Console.ReadLine());
            System.Console.WriteLine("Please enter listing date: ");
            myListing.SetDate(DateOnly.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter lising time: ");
            myListing.SetTime(Console.ReadLine());
            System.Console.WriteLine("Please enter lising price: ");
            myListing.SetCost(double.Parse(Console.ReadLine()));
            System.Console.WriteLine("Please enter lising availability: ");
            myListing.SetAvailability(Console.ReadLine());
            
            listing[Listing.GetCount()] = myListing;
            System.Console.WriteLine(Listing.GetCount());
            Listing.IncCount();
            Save();
        }


        // saves back into the trainer file
        public void Save(){
            StreamWriter outFile = new StreamWriter("listing.txt");

            for(int i = 0; i < Listing.GetCount(); i++){
                outFile.WriteLine(listing[i].ToFile());
            }

            outFile.Close();

        }

        // finds the listing id and checks to see if what was typed into the console was correct

       public int Find(int searchVal){
            System.Console.WriteLine(Listing.GetCount());
            for(int i = 0; i < Listing.GetCount(); i++){
                if(listing[i].GetListingID() == searchVal){
                    return i;
                }
            }

            return -1;
        }

        // finds the listing id as an int and checks to see if what was typed into the console was correct

        public int ListingFind(int searchVal){
            System.Console.WriteLine(Trainer.GetCount());
            for(int i = 0; i < Trainer.GetCount(); i++){
                if(listing[i].GetListingID() == searchVal){
                    return i;
                }
            }

            return -1;
        }

        //updates the listing information in the file 
        public void UpdateListing(){
            System.Console.WriteLine("What is the ID of the Trainer you would like to update?");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                System.Console.WriteLine("Please enter the updated listing style: ");
                listing[foundIndex].SetListingStyle(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated trainer name: ");
                listing[foundIndex].SetTrainerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated date: ");
                listing[foundIndex].SetDate(DateOnly.Parse(Console.ReadLine()));
                System.Console.WriteLine("Please enter the updated time: ");
                listing[foundIndex].SetTime(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated availability: ");
                listing[foundIndex].SetAvailability(Console.ReadLine());

                Save();
            }
            else{
                System.Console.WriteLine("The Listing ID is invalid :(");
            }
        }
        public void ViewAvailableListings(){
            System.Console.WriteLine("Availabile Listings: \n");
            for(int i = 0 ; i < Listing.GetCount(); i++ ){ 
                if(listing[i].GetAvailability() == "open" ){
                    System.Console.WriteLine($"Listing ID: {listing[i].GetListingID()}");
                    System.Console.WriteLine($"Trainer: {listing[i].GetTrainerName()}");
                    System.Console.WriteLine($"Date: {listing[i].GetDate()}");
                    System.Console.WriteLine($"Time: {listing[i].GetTime()}");
                    System.Console.WriteLine(" ");
                }
            }
        }
    

        //creates a soft delete in the file
        public void Delete(){
            System.Console.WriteLine("What is the ID of the Listing you would like to delete");
            int searchVal = int.Parse(Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                listing[foundIndex].Delete();
                Save();
            }  
            else{
                System.Console.WriteLine("The Listing ID is invalid :(");
            }
        }
    }
}