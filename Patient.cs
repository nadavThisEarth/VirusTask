using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VirusTask
{
    class Patient
    {
        //members
        public List<Virus> virusList { get; set; }
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
                    newBorns.Add(new Virus(virusList[i].detachProb, virusList[i].multiProb, 1.0));
                }
                else if (virusList[i].isSurvived() == false)
                {
                    dead++;
                    virusList.RemoveAt(i);   // updating the virus list (removing the dead particles)
                }
                else
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

            return $"After experiment , there are {virusList.Count} virus cells\nSurvived AND MUTIPLIED: {multi}\nSurvived WITHOUT MULTIPLYING: {surv}\nDied: {dead}\n";


        }

    }
}
