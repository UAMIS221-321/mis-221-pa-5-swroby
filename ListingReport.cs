using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class ListingReport
    {
        Listing [] listing;

        public ListingReport(Listing[] listing){
            this.listing = listing;
        }

        public void PrintAllListings(){
            for(int i = 0; i <Listing.GetCount(); i++){
                if(listing[i].GetDelete() == false ){
                    System.Console.WriteLine(listing[i].ToString());
                }
            }
        }
        
    }
}