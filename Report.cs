using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class Report
    {
        public Sessions[] sessions;
        public Listing [] listing;
        public ListingFile listFile;
        public ListingReport listReport;
        public TrainerFile trainerFile;
        public TrainerReport trainerReport;
        public SessionsReport sessionsReport;
        public Reviews [] reviews;
        public ReviewReport reviewReport;
        public Report( Sessions[] sessions,Listing[] listing, ListingFile listFile, ListingReport listReport, TrainerFile trainerFile, TrainerReport trainerReport, SessionsReport sessionsReport, ReviewReport reviewReport)
        {
            this.sessions = sessions;
            this.listing = listing;
            this.listFile = listFile;
            this.listReport = listReport;
            this.trainerFile= trainerFile;
            this.trainerReport = trainerReport;
            this.sessionsReport = sessionsReport;
            this.reviewReport = reviewReport;
        }
       
        public void IndividalCustomerReport(){
            System.Console.WriteLine("Enter customer email address:");
            string customerEmail = Console.ReadLine();
            StreamWriter outfile;
            System.Console.WriteLine("Would you like to save this report?");
            string userInput = Console.ReadLine().ToUpper();
            string fileName = "";
            if(userInput== "YES"){
                System.Console.WriteLine("What would you like to name the file?");
                fileName = Console.ReadLine();
                outfile = new StreamWriter(fileName);
            }
            int count = 0;

            for(int i=0; i<Sessions.GetCount();  i++){
                if(sessions[i].GetCustomerEmail() == customerEmail){
                    System.Console.WriteLine(sessions[i]);
                    count ++;
                    if(userInput == "YES"){
                        outfile = new StreamWriter(fileName, true);
                        outfile.WriteLine(sessions[i]);
                        outfile.Close();
                    }
                }
            }
            System.Console.WriteLine($"The customer participated in {count} sessions.");
        }

        public void HistoricalCustomerReport(){
            string currentCustomer = sessions[0].GetCustomerName();
            int count = 0;
            StreamWriter outfile;
            for(int i = 0; i < Sessions.GetCount(); i++){
                if(sessions[i].GetCustomerName() == currentCustomer){
                    count++;
                }
                else{
                    ProcessBreak(ref currentCustomer, ref count, sessions[i]);
                }
                System.Console.WriteLine(sessions[i].HistoricalString());
            }
            ProcessBreak(currentCustomer, count);
            System.Console.WriteLine("Would you like to save to a file?");
            string userInput = Console.ReadLine().ToUpper();
            string fileName = "";
            if(userInput== "YES"){
                System.Console.WriteLine("What would you like to name the file?");
                fileName = Console.ReadLine();
                outfile = new StreamWriter(fileName);
                for(int i = 0; i < Sessions.GetCount(); i++){
                    if(sessions[i].GetCustomerName() == currentCustomer){
                        count++;
                    }
                    else{
                        ProcessBreak(ref currentCustomer, ref count, sessions[i]);
                    }
                    outfile.WriteLine(sessions[i].HistoricalString());
                }
                outfile.Close();
            }
        }

        public void ProcessBreak(ref string currentCustomer, ref int count, Sessions newSessions){
            System.Console.WriteLine($"{currentCustomer} had {count} sessions");
            currentCustomer = newSessions.GetCustomerName();
            count = 1;
        }

        public void ProcessBreak(string currentCustomer, int count){
            System.Console.WriteLine($"{currentCustomer} had {count} sessions");
         }
     

        public void CustomerSort(){
            for(int i =0; i <Sessions.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j < Sessions.GetCount(); j++){
                    if(sessions[i].GetCustomerName().CompareTo(sessions[min].GetCustomerName())<0){
                        min = j;
                    }
                    if(min != i){
                        Swap(min, i);
                    }
                }
            }
        }
        public void DateSort(){
            for(int i =0; i <Sessions.GetCount()-1; i++){
                int min = i;
                for(int j = i+1; j < Sessions.GetCount(); j++){
                    if(sessions[i].GetSessionDate().CompareTo(sessions[min].GetSessionDate())<0){
                        min = j;
                    }
                    if(min != i){
                        Swap(min, i);
                    }
                }
            }
        }

        public void Swap(int x, int y){
            Sessions temp = sessions[x];
            sessions[x]= sessions[y];
            sessions[y]= temp;
        }


       

      
            
    public void HistoricalRevenueReport() {
        System.Console.WriteLine("Only report I could not figure out! Sorry to disappoint!!!");
        //         listingCheck = listFile.ListingFind(searchVal);



        //         if(sessions[i].GetSessionDate().Year == currYear) {
        //             countYear++;
        //             yearRevenue += listing[i].GetCost();

        //             if(sessions[i].GetSessionDate().Month == currMonth) {
        //                 monthRevenue+= listing[i].GetCost();
        //                 countMonth++;
        //             }
        //             else {
        //                 ProcessBreakMonth(ref currMonth, ref monthRevenue, i, ref countMonth);
        //             }
        //         }
        //         else {
        //             ProcessBreakYear(ref currYear, ref yearRevenue, i, ref countYear);
        //         }
        //         ProcessBreakMonth(ref currMonth, ref monthRevenue, 0, ref countMonth);
        //         ProcessBreakYear(ref currYear, ref yearRevenue, 0, ref countYear);
        //     }
        // }

        // System.Console.WriteLine("Would you like to save the report?");
        // string userInput = Console.ReadLine().ToUpper();

        // if(userInput =="YES"){
        //     System.Console.WriteLine("What would you like to name the file the report will be saved in?");
        //     string fileName = Console.ReadLine();
        //     StreamWriter outFile = new StreamWriter(fileName);
        //     outFile.WriteLine(ProcessBreakMonth);
        //     outFile.WriteLine(ProcessBreakYear);
        // }
            }

    public string ProcessBreakMonth(ref int currMonth, ref double monthRevenue, int i, ref int countMonth){
        System.Console.WriteLine($"{currMonth}'s revenue was {monthRevenue}");
        System.Console.WriteLine(countMonth);
        string message = $"{currMonth}'s revenue was {monthRevenue}";
        currMonth = sessions[i].GetSessionDate().Month;
        monthRevenue = listing[i].GetCost();
        return message;
    }
    public string ProcessBreakYear(ref int currYear, ref double yearRevenue,int i, ref int countYear){
        System.Console.WriteLine($"{currYear}'s revenue was {yearRevenue}");
        System.Console.WriteLine(countYear);
        string message = $"{currYear}'s revenue was {currYear}";
        currYear = sessions[i].GetSessionDate().Month;
        yearRevenue = listing[i].GetCost();
        return message;

    }

        public void CustomerReviewReport(){
            System.Console.WriteLine("Enter customer email address:");
            string customerEmail = Console.ReadLine();
            StreamWriter outfile;
            System.Console.WriteLine("Would you like to save this report?");
            string userInput = Console.ReadLine().ToUpper();
            string fileName = "";
            if(userInput== "YES"){
                System.Console.WriteLine("What would you like to name the file?");
                fileName = Console.ReadLine();
                outfile = new StreamWriter(fileName);
            }
            int count = 0;

            for(int i=0; i<Reviews.GetCount();  i++){
                if(reviews[i].GetCustomerEmail() == customerEmail){
                    System.Console.WriteLine(reviews[i]);
                    count ++;
                    if(userInput == "YES"){
                        outfile = new StreamWriter(fileName, true);
                        outfile.WriteLine(reviews[i]);
                        outfile.Close();
                    }
                }
            }
            System.Console.WriteLine($"The customer reviewed {count} sessions.");
        }
    }
}