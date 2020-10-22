using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class TestA
    {
        public void GeneratorA() // This simulation runs only once (in main)
        {
            double capacity = 100.0 / 1000;    //  arbitrary values

            List<Virus> virusList = new List<Virus>();
            for (int i = 0; i < 100; i++)
            {
                virusList.Add(new Virus(0.03, 0.1, capacity));
            }
            Patient p = new Patient(virusList, 1000);


            /*  
             *  
             *  printing First required function
             *  
             */

            Console.WriteLine(p.UpdateNoMedicine(capacity));
        }



    }
}
