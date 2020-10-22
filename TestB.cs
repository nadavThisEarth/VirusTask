using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class TestB
    {
        /// <summary>
        /// shows difference between run WITH and WITHOUT medicine <br/> 
        /// (same amount of runs per each)
        /// </summary>
        public void Sim1()
        {
            //  arbitrary initial values
            double detachProb = 0.03;
            double multiProb = 0.1;
            double mutate = 0.005;
            bool m1 = false;
            bool flag = false; // threshold - turns true when capacity is greater than or equal to 1
            Patient p = PatientIni(100, 1000, detachProb, multiProb);

            for (int i = 0; i < 150; i++) // 150 runs without medicine
            {
                if (p.capacity >= 1.0 && flag == false)
                {
                    flag = true;
                    Console.WriteLine("\n\n******* VIRUS HAS COMPLETELY OVERTAKEN THE TISSUE *******\n\n");
                }
                Console.WriteLine(p.UpdateNoMedicine(p.capacity));

            }


            Console.WriteLine("\n\n------**********----------------------------------------------\n"   //seperator message between 2 sections of experiment
                + "------------------- end of NO MEDICINE run" +
                "--------------------\n" +
                "------**********----------------------------------------------\n\n");
            p.virusListB = ConvertToChild(p.virusList, m1, mutate);

            for (int i = 0; i < 150; i++) //150 runs WITH MEDICINE
            {
                if (p.capacity >= 1.0 && flag == false)
                {
                    flag = true;
                    Console.WriteLine("\n\n******* VIRUS HAS COMPLETELY OVERTAKEN THE TISSUE *******\n\n");
                }
                Console.WriteLine(p.UpdateWithMedicine(p.capacity, m1, mutate));
            }


        }
            /// <summary>
            /// shows impact of  "momentary" injections of medicine
            /// </summary>
        public void Sim2()
        {
            //  arbitrary initial values
            double detachProb = 0.03;
            double multiProb = 0.1;
            double mutate = 0.005;
            bool m1 = false;
            bool flag = false; // threshold - turns true when capacity is greater than or equal to 1
            Patient p = PatientIni(100, 1000, detachProb, multiProb);

            for (int i = 0; i < 350; i++) // looping 350 iterations - (more than enough to realize experiments' trend)
            {
               
                if (p.capacity >= 1.0 && flag == false)
                {
                    flag = true;
                    Console.WriteLine("\n\n******* VIRUS HAS COMPLETELY OVERTAKEN THE TISSUE *******\n\n");
                }
                if (i == 0 || i == 75 || i == 150 || i == 300)
                {
                    p.virusListB = ConvertToChild(p.virusList, m1, mutate);
                    Console.WriteLine(p.UpdateWithMedicine(p.capacity, m1, mutate));
                    p.virusList = ConvertToParent(p.virusListB);
                }
                else
                {
                    Console.WriteLine(p.UpdateNoMedicine(p.capacity));

                }

            }

        }

        /// <summary>
        /// shows impact of different medicines on patient
        /// </summary>
        public void Sim3()
        {
            //  arbitrary initial values
            double detachProb = 0.03;
            double multiProb = 0.1;
            double mutate = 0.005;
            bool m1 = false;
            bool m2 = true;
            bool m3 = true;
            bool flag = false; // threshold - turns true when capacity is greater than or equal to 1
            Patient p = PatientIni(100, 1000, detachProb, multiProb);
            p.virusListB = ConvertToChild(p.virusList, m1, mutate);
            for (int i = 0; i < 150; i++)
            {
                if (p.capacity >= 1.0 && flag == false)
                {
                    flag = true;
                    Console.WriteLine("\n\n******* VIRUS HAS COMPLETELY OVERTAKEN THE TISSUE *******\n\n");
                }

                if (i >=50 && i<=100)
                {
                    p.virusList = ConvertToParent(p.virusListB);
                    p.virusListB = ConvertToChild(p.virusList, m2, mutate);
                    Console.WriteLine("\nMEDICINE M2\n");
                    Console.WriteLine(p.UpdateWithMedicine(p.capacity, m2, mutate));
                }
                else if (i > 100 && i<150)
                {
                    p.virusList = ConvertToParent(p.virusListB);
                    p.virusListB = ConvertToChild(p.virusList, m3, mutate);
                    Console.WriteLine("\nMEDICINE M3\n");
                    Console.WriteLine(p.UpdateWithMedicine(p.capacity, m3, mutate));
                }
                else
                {
                    Console.WriteLine("\nMEDICINE M1\n");
                    Console.WriteLine(p.UpdateWithMedicine(p.capacity, m1, mutate));
                }
                

            }



        }

        /*
         *********  AUXILLARY METHODS **************
         */



        /// <summary>
        /// initializes a patient according to given properties
        /// </summary>
        /// <param name="virus_num"></param>
        /// <param name="cell_num"></param>
        /// <returns>patient object</returns>
        public Patient PatientIni(int virus_num, int cell_num, double detachProb, double multiProb)
        {
            double capacity = (double)virus_num / cell_num;    //  arbitrary initial values
            List<Virus> virusList = new List<Virus>(); // initializing virus with 100 cells
            for (int i = 0; i < virus_num; i++)
            {
                virusList.Add(new Virus(detachProb, multiProb, capacity)); //setting properties for the virus cells
            }
            Patient p = new Patient(virusList, cell_num); // initializing patient
            return p;
        }



        public List<VirusB> ConvertToChild(List<Virus> virusList, bool immunity, double mutate)
        {
            List<VirusB> virusListB = new List<VirusB>();
            foreach (Virus virus in virusList)
            {
                virusListB.Add(new VirusB(immunity, mutate, virus.detachProb, virus.multiProb, virus.capacity));
            }
            return virusListB;

        }

        public List<Virus> ConvertToParent(List<VirusB> virusListB)
        {
            List<Virus> virusList = new List<Virus>();
            foreach (VirusB virusB in virusListB)
            {
                virusList.Add(new Virus(virusB.detachProb, virusB.multiProb, virusB.capacity));
            }
            return virusList;
        }



    }
}
