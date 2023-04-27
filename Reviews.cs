using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class Reviews
    {
        public string customerName;
        public string customerEmail;
        public string rating;
        public string review;
        private bool tempIsDeleted = false;
        private static int count;

        public Reviews(){

        }

        public Reviews(string customerName, string customerEmail,string rating, string review, bool tempIsDeleted){
            this.customerName = customerName;
            this.customerEmail = customerEmail;
            this.rating = rating;
            this.review = review;

        }

        //Accessors and Mutators
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
        public void SetRating(string rating){
            this.rating = rating;
        }
        public string GetRating(){
            return rating;
        }
        public void SetReview(string review){
            this.review = review;
        }
        public string GetReview(){
            return review;
        }
        public static void SetCount(int count){
            Reviews.count = count;
        }

        static public void IncCount(){
            Reviews.count++;
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

        // this is what is sent to the user
        public override string ToString(){
            return $"{customerName} gave TRAIN LIKE A CHAMPION {rating} stars! \nThey stated: \t{review}";
        }
        // this is what is sent to the file
        public string ToFile(){
            return $"{customerName}#{customerEmail}#{rating}#{review}#{tempIsDeleted}";
        }
    }
}