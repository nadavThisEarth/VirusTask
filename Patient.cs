using System;
using System.Collections.Generic;
using System.Text;

namespace VirusTask
{
    class Patient
    {
        public List<Virus> virusList { get; set; }
        public int numOfCells { get; set; }

        public Patient(List<Virus> virusList, int numOfCells)
        {
            this.virusList = virusList;
            this.numOfCells = numOfCells;
        }
        public string UpdateNoMedicine(double capacity)
        {
            List<Virus> newBorns = new List<Virus>();
            string result = "";

            for (int i = virusList.Count - 1; i > -1; i--)
            {
                if (virusList[i].GetMultiplied())
                {
                    result += $"virus with id {i} SURVIVED AND MULTIPLIED\n";
                    newBorns.Add(new Virus(virusList[i].detachProb, virusList[i].multiProb));
                }
                else if (virusList[i].GetSurvived() == false)
                {
                    result += $"virus with id {i} DIDN'T SURVIVE\n";
                    virusList.RemoveAt(i);   // updating the virus list (removing the dead particles)
                }
                else
                {
                    result += $"virus with id {i} survived WITHOUT MULTIPLYING\n";
                }
            }

            virusList.AddRange(newBorns); // updating the virus list (adding the newborns)

            return result;
        }


    }
}
