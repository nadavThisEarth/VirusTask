using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class Virus
    {
        //members
        public double detachProb { get; set; }
        public double multiProb { get; set; }
        protected bool survived;
        protected bool multiplied;
        public double capacity { get; set; }

        //ctor
        public Virus(double detachProb, double multiProb, double capacity)
        {
            this.capacity = capacity;
            this.detachProb = detachProb;
            this.multiProb = multiProb;
            Random rand = new Random();
            double r = rand.NextDouble();
            this.survived = (r > detachProb);
            this.multiplied = (MultiplyChance(capacity, r) && this.survived);
        }

        public bool isSurvived()
        {
            return survived;
        }
        public bool isMultiplied()
        {
            return multiplied;
        }
        /// <summary>
        /// Computes the chance of single virus cell  multiplication <br/> 
        /// according to a formula that involves given statistic probability <br/> 
        /// AND virus capacity in human tissue
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="r"></param>
        /// <returns>whether virus cell multiplied or not</returns>
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
