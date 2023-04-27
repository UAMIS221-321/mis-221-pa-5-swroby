using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class ReviewReport
    {
        Reviews [] reviews;

        public ReviewReport(Reviews[] reviews){
            this.reviews = reviews;
        }

        public void PrintAllReviews(){
            for(int i = 0; i <Reviews.GetCount(); i++){
                if(reviews[i].GetDelete() == false ){
                    System.Console.WriteLine(reviews[i].ToString());
                }
            }
        }
    }
}