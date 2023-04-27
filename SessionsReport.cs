using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class SessionsReport
    {
        public Sessions [] sessions;

        public SessionsReport(Sessions[] sessions){
            this.sessions = sessions;
        }

        public void PrintAllSessions(Sessions [] sessions){
            for(int i = 0; i <Sessions.GetCount(); i++){
                if(sessions[i].GetDelete() == false ){
                    System.Console.WriteLine(sessions[i].ToString());
                }
             }
        }
    }
}