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

        public Virus(double detachProb, double multiProb)
        {
            this.detachProb = detachProb;
            this.multiProb = multiProb;
            Random rand = new Random();
            double r = rand.NextDouble();
            if (r > detachProb)
            {
                this.survived = true;
            }
            else
            {
                this.survived = false;
            }
            r = rand.NextDouble();
            if (r < multiProb && this.survived == true)
            {
                this.multiplied = true;
            }
            else
            {
                this.multiplied = false;
            }
        }

        public bool GetSurvived()
        {
            return survived;
        }
        public bool GetMultiplied()
        {
            return multiplied;
        }

        public bool MultiplyChance(double capacity)
        {
            Random rand = new Random();
            double r = rand.NextDouble();

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
