using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class ReviewFile
    {
        public Reviews[] reviews;

        public ReviewFile(Reviews[] reviews)
        {
            this.reviews = reviews;
            GetAllReviews();
        }


        // retrieves all the reviews in the review file
        public void GetAllReviews(){
            Reviews.SetCount(0);
            StreamReader inFile = new StreamReader("reviews.txt");
            string input = inFile.ReadLine();
            while(input != null && input != ""){
                string [] temp = input.Split('#');
                bool tempIsDeleted = bool.Parse(temp[4]);
                reviews[Reviews.GetCount()] = new Reviews(temp[0], temp[1], temp[2], temp[3],tempIsDeleted);
                Reviews.IncCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }

        // allows the operator to create a trainer
        public void AddReviews(){
            Reviews myReviews = new Reviews();
            System.Console.WriteLine("Please enter customer name: ");
            myReviews.SetCustomerName((Console.ReadLine()));
            System.Console.WriteLine("Please enter new customer email: ");
            myReviews.SetCustomerEmail(Console.ReadLine());
            System.Console.WriteLine("Please rate TRAIN LIKE A CHAMPION out of 5 stars!: ");
            myReviews.SetRating(Console.ReadLine());
            System.Console.WriteLine("Please leave us a review!");
            myReviews.SetReview(Console.ReadLine());
        
            reviews[Reviews.GetCount()] = myReviews;
            System.Console.WriteLine(Reviews.GetCount());
            Reviews.IncCount();
            Save();
        }

        // saves back into the trainer file
        public void Save(){
            StreamWriter outFile = new StreamWriter("reviews.txt");
            for(int i = 0; i < Reviews.GetCount(); i++){
                outFile.WriteLine(reviews[i].ToFile());
            }
            outFile.Close();

        }

    // finds the customer name and checks to see if what was typed into the console was correct

       public int Find(string searchVal){
            System.Console.WriteLine(Reviews.GetCount());
            for(int i = 0; i < Reviews.GetCount(); i++){
                if(reviews[i].GetCustomerName() == searchVal)
                {
                    return i;
                }
            }

            return -1;
        }

        //updates the review information in the file 

        public void UpdateReviews(){
            System.Console.WriteLine("What is the customer name review you would like to update?");
            string searchVal = (Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1)
            {
                System.Console.WriteLine("Please enter the updated customer name: ");
                reviews[foundIndex].SetCustomerName(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated email: ");
                reviews[foundIndex].SetCustomerEmail(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated rating: ");
                reviews[foundIndex].SetRating(Console.ReadLine());
                System.Console.WriteLine("Please enter the updated review: ");
                reviews[foundIndex].SetReview(Console.ReadLine());

                Save();
            }
            else
            {
                System.Console.WriteLine("The customer name is invalid :(");
            }
        }
        
        //creates a soft delete in the file
        public void Delete(){
            System.Console.WriteLine("What is the name of the customer review you would like to delete?");
            string searchVal = (Console.ReadLine());
            int foundIndex = Find(searchVal);

            if(foundIndex != -1){
                reviews[foundIndex].Delete();
                Save();
            }
            else{
                System.Console.WriteLine("The customer name is invalid :(");
            }
        }
    }
}