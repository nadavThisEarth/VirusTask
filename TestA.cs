using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class TestA
    {
        public void GeneratorA()
        {
            double capacity = 100.0 / 1000;    //  arbitrary values

            List<Virus> virusList = new List<Virus>();
            for (int i = 0; i < 100; i++)
            {
                virusList.Add(new Virus(0.03, 0.1));
            }
            Patient p = new Patient(virusList, 1000);


            /*  
             *  
             *  printing First required function
             *  
             */

            Console.WriteLine(p.UpdateNoMedicine(capacity));

            capacity = p.virusList.Count / (double)p.numOfCells; // updating capacity according to last run results
            /*  
             *  
             *  printing SECOND required function
             *  
             */
            if (p.virusList[0].MultiplyChance(capacity))
            {
                Console.WriteLine("Virus has multiplied");
            }
            else
            {
                Console.WriteLine("virus hasn't multiplied");
            }

        }



    }
}
