using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mis_221_pa_5_swroby
{
    public class TrainerReport
    {
        Trainer [] trainer;

        public TrainerReport(Trainer[] trainer){
            this.trainer = trainer;
        }

        public void PrintAllTrainers(){
            for(int i = 0; i <Trainer.GetCount(); i++){
                if(trainer[i].GetDelete() == false ){
                    System.Console.WriteLine(trainer[i].ToString());
                }
            }
        }
    }
}