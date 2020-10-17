using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class Virus
    {
        public double detachProb { get; set; }
        public double multiProb { get; set; }

        private bool survived;

        private bool multiplied;

        public double capacity { get; set; }

        public Virus(double detachProb, double multiProb,double capacity)
        {
            this.capacity = capacity;
            this.detachProb = detachProb;
            this.multiProb = multiProb;
            Random rand = new Random();
            double r = rand.NextDouble();
            this.survived = (r > detachProb);
            this.multiplied = (MultiplyChance(capacity,r) && this.survived);
        }

        public bool isSurvived()
        {
            return survived;
        }
        public bool isMultiplied()
        {
            return multiplied;
        }

        public bool MultiplyChance(double capacity, double r)
        {
            if (r > ((1 - capacity) * this.multiProb))
            {
                return false;
            }
            else
            {
                return true;
            }
        }






    }
}
