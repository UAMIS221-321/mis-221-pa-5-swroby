using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class SessionsFile
    {
        public Sessions[] sessions;
        public ListingFile listFile;
        public ListingReport listReport;
        public TrainerFile trainerFile;
        public TrainerReport trainerReport;
        public SessionsFile(Sessions[] sessions, ListingFile listFile, ListingReport listReport, TrainerFile trainerFile, TrainerReport trainerReport)
        {
            this.sessions = sessions;
            this.listFile = listFile;
            this.listReport = listReport;
            this.trainerFile= trainerFile;
            this.trainerReport = trainerReport;
        }
        
        // retrieves all the sessions in the transactions file
        public void GetAllSessions(){
            Sessions.SetCount(0);
            StreamReader inFile = new StreamReader("transactions.txt");
            string input = inFile.ReadLine();
            while(input != null && input != ""){
                string [] temp = input.Split('#');
                int tempId = int.Parse(temp[0]);
                DateOnly sessionsDate = DateOnly.Parse(temp[3]);
                bool tempIsDeleted = bool.Parse(temp[7]);
                sessions[Sessions.GetCount()] = new Sessions(tempId, int.Parse(temp[1]), temp[2], sessionsDate,temp[4],temp[5], temp[6], tempIsDeleted);
                Sessions.IncCount();
                input = inFile.ReadLine();
            }
            inFile.Close();
        }
       
       // allows the operator to book a session
       public void BookSession(){
            Sessions newSessions = new Sessions();
            
            listReport.PrintAllListings();

            System.Console.WriteLine("What is the ID of the session you would like to book?");
            int sessionPick = int.Parse(Console.ReadLine());

            newSessions.SetSessionID(sessionPick);
            System.Console.WriteLine("Please enter your name: ");
            newSessions.SetCustomerName(Console.ReadLine());
            System.Console.WriteLine("Please enter your email address: ");
            newSessions.SetCustomerEmail(Console.ReadLine());
            
            Listing listingToBook = listFile.listing[listFile.Find(sessionPick)];
            newSessions.SetSessionDate(listingToBook.GetDate());
            newSessions.SetTrainerName(listingToBook.GetTrainerName());
            string trainerName = listingToBook.GetTrainerName();

            Trainer trainerInBooking = trainerFile.trainer[trainerFile.Find(trainerName)];
            newSessions.SetTrainerID(trainerInBooking.GetTrainerID());
            newSessions.SetStatus("booked");

            sessions[Sessions.GetCount()] = newSessions;
            Sessions.IncCount();
            Save();


       }

    // saves back into the trainer file
        public void Save(){
            StreamWriter outFile = new StreamWriter("transactions.txt");

            for(int i = 0; i < Sessions.GetCount(); i++){
                outFile.WriteLine(sessions[i].ToFile());
            }

            outFile.Close();

        }

        //updates the session information in the file 
        public void UpdateSessionStatus(){
            Sessions newSessions = new Sessions();
            System.Console.WriteLine("Enter the ID of your session");
            int session = int.Parse(Console.ReadLine());

            System.Console.WriteLine("Would you like to cancel your session?");
            string userInput = Console.ReadLine().ToUpper();
            if( userInput == "YES"){
                newSessions.SetStatus("Canceled");
            }
            System.Console.WriteLine("Did you complete your session?");
            string otherInput = Console.ReadLine().ToUpper();
            if(otherInput =="YES"){
                newSessions.SetStatus("Completed");
            }
            Save();
        }
    
    }
}
     
