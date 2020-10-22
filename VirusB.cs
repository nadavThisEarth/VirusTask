using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class VirusB : Virus
    {
        public bool immunity { get; set; } // represents immunity to a certain medicine
        public double mutate { get; set; } // represents probability to develop/lose ability of mutation

        public VirusB(bool immunity, double mutate, double detachProb, double multiProb, double capacity) : base(detachProb, multiProb, capacity)
        {
            this.immunity = immunity;
            this.capacity = capacity;      // this section is identical to parent class (VIRUS)
            this.detachProb = detachProb;
            this.multiProb = multiProb;
            this.mutate = mutate;
            Random rand = new Random();
            double r = rand.NextDouble();
            this.survived = (r > detachProb);
            // following section is different (considers immunity)
            r = rand.NextDouble();
            if (r < mutate)
            {
                this.immunity = !this.immunity;
            }

            if (this.immunity == false) //  in case virus particle ISN'T immune
            {
                this.multiplied = false;
            }
            else // in case virus particle IS immune
            {
                r = rand.NextDouble();
                this.multiplied = (MultiplyChance(capacity, r) && this.survived);
            }



        }
    }
}
