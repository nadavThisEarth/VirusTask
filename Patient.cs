using System;
using System.Collections.Generic;

namespace VirusTask
{
    class Patient
    {
        //members
        public List<Virus> virusList { get; set; }
        public List<VirusB> virusListB { get; set; }
        public int numOfCells { get; set; }

        public double capacity { get; set; }

        //ctor
        public Patient(List<Virus> virusList, int numOfCells)
        {
            this.virusList = virusList;
            this.numOfCells = numOfCells;
            this.capacity = virusList.Count / (double)numOfCells;
            foreach (Virus virus in virusList)
            {
                virus.capacity = capacity;

            }
        }
        /// <summary>
        /// updates the number of virus-infected cells in patient WITHOUT MEDICINE
        /// <param name="capacity"></param>
        /// <returns>Numerical DATA of survived/dead/multiplied virus cells</returns>
        public string UpdateNoMedicine(double capacity)
        {
            List<Virus> newBorns = new List<Virus>();
            int dead = 0;
            int surv = 0;
            int multi = 0;

            for (int i = virusList.Count - 1; i > -1; i--)
            {
                if (virusList[i].isMultiplied())
                {
                    multi++;
                    newBorns.Add(new Virus(virusList[i].detachProb, virusList[i].multiProb, capacity));
                }
                else if (virusList[i].isSurvived() == false)
                {
                    dead++;
                    virusList.RemoveAt(i);   // updating the virus list (removing the dead particles)
                }
                else if(virusList[i].isSurvived() == true && virusList[i].isMultiplied() == false)//in case survived WITHOUT multiplying
                {
                    surv++;
                }
            }
            virusList.AddRange(newBorns); //adding the newborns to virus list
            foreach (Virus virus in virusList)
            {
                virus.capacity = virusList.Count / (double)numOfCells; //updating capacity in each Virus cell CLASS
            }
            this.capacity = virusList.Count / (double)numOfCells;//updating capacity in Patient CLASS

            return $"After experiment (WITHOUT MEDICINE) , there are {virusList.Count} virus cells\nSurvived AND MUTIPLIED: {multi}\nSurvived WITHOUT MULTIPLYING: {surv}\nDied: {dead}\n";
        }

        /// <summary>
        /// updates the number of virus-infected cells in patient WITH MEDICINE
        /// </summary>
        /// <param name="capacity"></param>
        /// <param name="immunity"></param>
        /// <param name="mutate"></param>
        /// <returns>Numerical DATA of survived/dead/multiplied virus cells</returns>
        public string UpdateWithMedicine(double capacity, bool immunity, double mutate) {
            List<VirusB> newBorns = new List<VirusB>();
            int dead = 0;
            int surv = 0;
            int multi = 0;

            for (int i = virusListB.Count - 1; i > -1; i--)
            {
                if (virusListB[i].isMultiplied())
                {
                    multi++;
                    newBorns.Add(new VirusB(immunity, mutate, virusListB[i].detachProb, virusListB[i].multiProb, capacity));
                }
                else if (virusListB[i].isSurvived() == false)
                {
                    dead++;
                    virusListB.RemoveAt(i);   // updating the virus list (removing the dead particles)
                }
                else if (virusListB[i].isSurvived() == true && virusListB[i].isMultiplied() == false) //in case survived WITHOUT multiplying
                {
                    surv++;
                }
            }
            virusListB.AddRange(newBorns); //adding the newborns to virus list
            foreach (VirusB virusb in virusListB)
            {
                virusb.capacity = virusListB.Count / (double)numOfCells; //updating capacity in each Virus cell CLASS
            }
            this.capacity = virusListB.Count / (double)numOfCells;//updating capacity in Patient CLASS

            return $"After experiment (WITH MEDICINE) , there are {virusListB.Count} virus cells\nSurvived AND MUTIPLIED: {multi}\nSurvived WITHOUT MULTIPLYING: {surv}\nDied: {dead}\n";


        }
      
    }
}
