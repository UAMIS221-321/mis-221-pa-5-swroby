using mis_221_pa_5_swroby;

// main
Home();
 

 //methods

 //home- should be prompted after every action and if the user types in the wrong number for an input
static void Home(){
    System.Console.WriteLine("███████████████████████████████████████████████████████████████");
    System.Console.WriteLine("█─▄─▄─█▄─▄▄▀██▀▄─██▄─▄█▄─▀█▄─▄███▄─▄███▄─▄█▄─█─▄█▄─▄▄─████▀▄─██"); 
    System.Console.WriteLine("███─████─▄─▄██─▀─███─███─█▄▀─█████─██▀██─███─▄▀███─▄█▀████─▀─██");
    System.Console.WriteLine("▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▀▄▄▀▀▀▄▄▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀▀▀▄▄▀▄▄▀");
    System.Console.WriteLine("███████████████████████████████████████████████████████████████");
    System.Console.WriteLine("████████─▄▄▄─█─█─██▀▄─██▄─▀█▀─▄█▄─▄▄─█▄─▄█─▄▄─█▄─▀█▄─▄█████████");
    System.Console.WriteLine("████████─███▀█─▄─██─▀─███─█▄█─███─▄▄▄██─██─██─██─█▄▀─██████████");
    System.Console.WriteLine("███████▀▄▄▄▄▄▀▄▀▄▀▄▄▀▄▄▀▄▄▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▀▄▄▄▄▀▄▄▄▀▀▄▄▀████████");
    System.Console.WriteLine("███████████████████████████████████████████████████████████████");

    System.Console.WriteLine("Welcome to TRAIN LIKE A CHAMPION!");
    System.Console.WriteLine("You can never lose if you are a winner!");
    System.Console.WriteLine("We are an award winning studio that combines \nthe art of dance with techiques based in pilates.");
    System.Console.WriteLine("");
    System.Console.WriteLine("Please select from our menu below to get started!");
    System.Console.WriteLine("");
    System.Console.WriteLine("Are you are customer or a studio manager?");
    System.Console.WriteLine("Select 1 for Customer.");
    System.Console.WriteLine("Select 2 for Studio Manager.");
    
    int input = int.Parse(Console.ReadLine());

    switch(input){
        case 1:                                                   // if user selects 1
            CustomerMenu();
            Home();
        break;
        case 2:                                                     // if user selects 2
            ManagerMenu();
            Home();
        break;
        default:                                                   // if user does not make a valid selection, they will go back to main menu
            System.Console.WriteLine("Invalid option. Please choose a valid option.");
            Home();               
        break;
    }
}

static void ManagerMenu(){
    // this is where I listed all my different classes and their objects so I could retrieve methods and info from their respective class.
        Listing[] listing = new Listing[100];
        ListingFile listFile = new ListingFile(listing);
        ListingReport listReport = new ListingReport(listing);
        Sessions[] sessions = new Sessions[100];
        Trainer[] trainer = new Trainer[100];
        TrainerFile trainerFile = new TrainerFile(trainer);
        TrainerReport trainerReport = new TrainerReport(trainer);
        SessionsFile file = new SessionsFile(sessions, listFile, listReport, trainerFile, trainerReport);
        SessionsReport report = new SessionsReport(sessions);
        Reviews[] reviews = new Reviews[100];
        ReviewReport reviewReport = new ReviewReport(reviews);

        file.GetAllSessions(); //populate array
        System.Console.WriteLine("");
        System.Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████");
        System.Console.WriteLine("█─▄▄▄▄█─▄─▄─█▄─██─▄█▄─▄▄▀█▄─▄█─▄▄─███▄─▀█▀─▄██▀▄─██▄─▀█▄─▄██▀▄─██─▄▄▄▄█▄─▄▄─█▄─▄▄▀█─▄▄▄▄█");
        System.Console.WriteLine("█▄▄▄▄─███─████─██─███─██─██─██─██─████─█▄█─███─▀─███─█▄▀─███─▀─██─██▄─██─▄█▀██─▄─▄█▄▄▄▄─█");
        System.Console.WriteLine("▀▄▄▄▄▄▀▀▄▄▄▀▀▀▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▀▄▄▄▄▀▀▀▄▄▄▀▄▄▄▀▄▄▀▄▄▀▄▄▄▀▀▄▄▀▄▄▀▄▄▀▄▄▄▄▄████▀▄▄▄▄▄▀▄▄▀▄▄▀▄▀");
        System.Console.WriteLine("█████████████████████████████████████████████████████████████████████████████████████████");
        System.Console.WriteLine("");
        Console.WriteLine("1. Manage Trainer Data ");
        Console.WriteLine("2. Manage Listing Data ");
        Console.WriteLine("3. Manage Customer Booking Data ");
        Console.WriteLine("4. Run Reports ");
        Console.WriteLine("5. Exit Program ");

        int input = int.Parse(Console.ReadLine());

        switch(input){
            case 1:                                      // if user selects 1 they can manage trainer data
                ManageTrainerData();
            break;
            case 2:
                ManageListingData();                    // if user selects 2 they can manage listing data
            break;
            case 3:
                ManageCustomerBookingData(listing, listFile,listReport,sessions, trainer,trainerFile,trainerReport,file,report);              // if they choose three they can manage the bookings
            break;
            case 4:
                RunReports(listing, listFile,listReport, sessions, trainer,trainerFile,trainerReport,file,report, reviewReport);              // if they choose four they can run a report
            break;
            case 5:
                Environment.Exit(0);                                 // lets the user exit the program
            break;
            default:
                System.Console.WriteLine("Invalid option. Please choose a valid option.");                        // if the user does not select a valid option they will be reprompted with the main menu
                ManagerMenu();
            break;
        }  
    }

static void CustomerMenu(){
    // this is where I listed all my different classes and their objects so I could retrieve methods and info from their respective class.
    Listing[] listing = new Listing[100];
    ListingFile listFile = new ListingFile(listing);
    ListingReport listReport = new ListingReport(listing);
    Sessions[] sessions = new Sessions[100];
    Trainer[] trainer = new Trainer[100];
    TrainerFile trainerFile = new TrainerFile(trainer);
    TrainerReport trainerReport = new TrainerReport(trainer);
    SessionsFile file = new SessionsFile(sessions, listFile, listReport, trainerFile, trainerReport);
    SessionsReport report = new SessionsReport(sessions);

    System.Console.WriteLine("█████████████████████████████████████████████████████████");
    System.Console.WriteLine("█─▄▄▄─█▄─██─▄█─▄▄▄▄█─▄─▄─█─▄▄─█▄─▀█▀─▄█▄─▄▄─█▄─▄▄▀█─▄▄▄▄█");
    System.Console.WriteLine("█─███▀██─██─██▄▄▄▄─███─███─██─██─█▄█─███─▄█▀██─▄─▄█▄▄▄▄─█");
    System.Console.WriteLine("▀▄▄▄▄▄▀▀▄▄▄▄▀▀▄▄▄▄▄▀▀▄▄▄▀▀▄▄▄▄▀▄▄▄▀▄▄▄▀▄▄▄▄▄▀▄▄▀▄▄▀▄▄▄▄▄▀");
    System.Console.WriteLine("█████████████████████████████████████████████████████████");
    System.Console.WriteLine("");
    Console.WriteLine("1. Book a Session");
    Console.WriteLine("2. Why TRAIN LIKE A CHAMPION ?");
    Console.WriteLine("3. Leave a review!");
    Console.WriteLine("4. Exit Program ");
    
    int input = int.Parse(Console.ReadLine());

        switch(input){
            case 1:
                ManageCustomerBookingData(listing, listFile,listReport,sessions, trainer,trainerFile,trainerReport,file,report);   // the operator can manage the bookking data
            break;
            case 2:
                Why();                               // if they select two they can see the company's mission statement
            break;
            case 3:
                Review();                            // they select 3 the user can leave a review
            break;
            case 4:
                Environment.Exit(0);                 // exits program
            break;
            default:
                System.Console.WriteLine("Invalid option. Please choose a valid option.");                // they will be repromted with the menu if they do not select a valid option
                CustomerMenu();
            break;
        }  
}

static void Why(){
    System.Console.WriteLine("At TRAIN LIKE A CHAMPION, we believe that dance and the arts are essential to a healthy, ");
    System.Console.WriteLine("vibrant community. Our mission is to provide a safe and supportive environment where");
    System.Console.WriteLine("people of all ages and backgrounds can come together to express themselves through ");
    System.Console.WriteLine("movement, music, and artistry.");
    System.Console.WriteLine("");
    System.Console.WriteLine("We believe that dance is not just a form of entertainment, but a powerful tool for personal");
    System.Console.WriteLine("growth and development. Through dance, you can improve your physical fitness, increase ");
    System.Console.WriteLine("your flexibility and coordination, and tone your body like a champion. But beyond that, dance ");
    System.Console.WriteLine("can also help you build confidence, develop your creativity, and connect with others in ");
    System.Console.WriteLine("meaningful ways.");
    System.Console.WriteLine("");
    System.Console.WriteLine("Our passionate team of instructors is dedicated to helping you achieve your dance goals, ");
    System.Console.WriteLine("whether you are a beginner or a seasoned pro. We offer a wide range of classes and");
    System.Console.WriteLine("workshops in various styles, including ballet, hip hop, contemporary, and more, so you can ");
    System.Console.WriteLine("find the perfect fit for your interests and abilities.");
    System.Console.WriteLine("");
    System.Console.WriteLine("So if you are looking for a fun and challenging way to stay fit, express yourself, and connect ");
    System.Console.WriteLine("with a community of like-minded individuals, come train like a champion at our dance studio. ");
    System.Console.WriteLine("We can't wait to see what you can achieve!");
    System.Console.WriteLine("");

}

static void Review(){
    Reviews[] reviews = new Reviews[100];
    ReviewFile reviewFile = new ReviewFile(reviews);
    ReviewReport reviewReport = new ReviewReport(reviews);

    System.Console.WriteLine("Please review our studio and give us any feedback!");         // review section sub menu
    System.Console.WriteLine("");
    Console.WriteLine("Select an option:");
    Console.WriteLine("1. Add Review ");
    Console.WriteLine("2. Edit Review ");
    Console.WriteLine("3. Delete Review ");
    Console.WriteLine("4. Exit ");

    int input = int.Parse(Console.ReadLine());

    switch(input){
        case 1:                                                                         // user can add review
            System.Console.WriteLine("Let's add a review to our file!");
            reviewReport.PrintAllReviews();
            reviewFile.AddReviews();
            reviewReport.PrintAllReviews();
        break;
        case 2:                                                                         // user can edit a review
            System.Console.WriteLine("Let's edit review information!");
            reviewReport.PrintAllReviews();
            reviewFile.UpdateReviews();
            reviewReport.PrintAllReviews();
        break;
        case 3:                                                                         // user can delete a review
            System.Console.WriteLine("Let's delete a review!");
            reviewReport.PrintAllReviews();
            reviewFile.Delete();
            reviewReport.PrintAllReviews();
        break;
        case 4:                                                                       // user can exit the program
            reviewFile.Save();
            Environment.Exit(0);
        break;
        default:
            System.Console.WriteLine("Invalid option. Please choose a valid option.");   // user is repromted with the review menu if they do not select a valid option
            Review();
        break;
        }   
    

}
static void ManageTrainerData(){
    Trainer[] trainer = new Trainer[100];
    TrainerFile file = new TrainerFile(trainer);
    TrainerReport report = new TrainerReport(trainer);

    Console.WriteLine("Please select an option:");                                        //Trainer data sub menu
    Console.WriteLine("1. Add Trainer ");
    Console.WriteLine("2. Edit Trainer Information ");
    Console.WriteLine("3. Delete Trainer Profile ");
    Console.WriteLine("4. Exit ");

    int input = int.Parse(Console.ReadLine());

    switch(input){
        case 1:                                                                         // user can add a trainer
            System.Console.WriteLine("Let's add a trainer to our file!");                
            report.PrintAllTrainers();
            file.AddTrainer();
            report.PrintAllTrainers();
        break;
        case 2:                                                                         // user can edit a trainer
            System.Console.WriteLine("Let's edit a trainer's information!");
            report.PrintAllTrainers();
            file.UpdateTrainer();
            report.PrintAllTrainers();
        break;
        case 3:                                                                        // user can delete a trainer
            System.Console.WriteLine("Let's delete a trainer profile!");
            report.PrintAllTrainers();
            file.Delete();
            report.PrintAllTrainers();
        break;
        case 4:                                                                         // user can exit the program
            file.Save();
            Environment.Exit(0);
        break;
        default:
            System.Console.WriteLine("Invalid option. Please choose a valid option.");    //if the input is invalid, the user will be reprompted with the sub menu
            ManageTrainerData();
        break;
        }   
}

static void ManageListingData(){
    Listing[] listing = new Listing[100];
    ListingFile file = new ListingFile(listing);
    ListingReport report = new ListingReport(listing);

    Console.WriteLine("Please select an option:");                                       // listing data sub menu
    Console.WriteLine("1. Add Listing ");
    Console.WriteLine("2. Edit Listing ");
    Console.WriteLine("3. Delete Listing ");
    Console.WriteLine("4. Exit ");

    int input = int.Parse(Console.ReadLine());

    switch(input){
        case 1:                                                                           // add a listing
            System.Console.WriteLine("Let's add a listing to our file!");
            report.PrintAllListings();
            file.AddListing();
            report.PrintAllListings();
        break;
        case 2:
            System.Console.WriteLine("Let's edit a listing!");                            //edit a listing
            report.PrintAllListings();
            file.UpdateListing();
            report.PrintAllListings();
        break;
        case 3:                                                                            // delete a listing
            System.Console.WriteLine("Let's delete a listing!");
            report.PrintAllListings();
            file.Delete();
            report.PrintAllListings();
        break;
        case 4:                                                                          // the user can exit the program
            file.Save();
            Environment.Exit(0);
        break;
        default:
            System.Console.WriteLine("Invalid option. Please choose a valid option.");        // the user will be reprompted with the sub menu if their input is invalid
            ManageListingData();
        break;
        }   
}



static void ManageCustomerBookingData(Listing[] listing, ListingFile listFile,ListingReport listReport,Sessions[] sessions, Trainer[] trainer,TrainerFile trainerFile,TrainerReport trainerReport,SessionsFile file,SessionsReport report ){
    listFile.GetAllListing();

    Console.WriteLine("Please select an option:");
    Console.WriteLine("1. View available training sessions");
    Console.WriteLine("2. Book a session");
    Console.WriteLine("3. Update Sessions Attendence");
    Console.WriteLine("4. Exit");

    int input = int.Parse(Console.ReadLine());

    switch(input){
        case 1:                                                                     // user can view listings to book
            listFile.ViewAvailableListings();
        break;
        case 2:                                                                     // user can book a session
            file.BookSession();
        break;
        case 3:                                                                     // user can update their session status
            file.UpdateSessionStatus();
        break;
        case 4:                                                                     // user can exit the program
            file.Save(); 
            Environment.Exit(0);
        break;
        default:
            System.Console.WriteLine("Invalid option. Please choose a valid option.");                                       // user is reprompted with the menu
            ManageCustomerBookingData(listing, listFile,listReport,sessions, trainer,trainerFile,trainerReport,file,report);
        break;
        }   
}  

static void RunReports(Listing[] listing, ListingFile listFile,ListingReport listReport,Sessions[] sessions, Trainer[] trainer,TrainerFile trainerFile,TrainerReport trainerReport,SessionsFile file, SessionsReport report, ReviewReport reviewReport){
    Report runReport = new Report(sessions,listing, listFile,  listReport, trainerFile, trainerReport, report, reviewReport);
    Console.WriteLine("Please select an option:");                                      // report sub menu
    Console.WriteLine("1. Individual Customer Sessions");
    Console.WriteLine("2. Historical Customer Sessions");
    Console.WriteLine("3. Historical Revenue Report");
    Console.WriteLine("4. Review Report");
    Console.WriteLine("5. Exit");

    int input = int.Parse(Console.ReadLine());

    switch(input){
        case 1:                                                                         // user can run this to see the individual report
            runReport.IndividalCustomerReport();
        break;
        case 2:                                                                          // user can see historical customer report
            file.GetAllSessions();
            runReport.CustomerSort();
            runReport.HistoricalCustomerReport();
        break;
        case 3:                                                                           // user can see the historical revenue report
            runReport.HistoricalRevenueReport();
        break;
        case 4:                                                                         // customers can see the reviews
            runReport.CustomerReviewReport();
        break;
        case 5:
            Environment.Exit(0);                                                          // allows the user to exit the program
        break;
        default:
            System.Console.WriteLine("Invalid option. Please choose a valid option.");   // if input is invalid the menu will be reprompted for them to choose again
            RunReports(listing, listFile,listReport, sessions, trainer,trainerFile,trainerReport,file,report, reviewReport);
        break;
    }   

}