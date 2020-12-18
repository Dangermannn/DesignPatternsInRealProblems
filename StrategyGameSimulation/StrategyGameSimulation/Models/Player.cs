using StrategyGameSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Models
{
    [Serializable]
    public class Player
    {
        public int Gold { get; set; }
        
        public int OverallIncome { get; set; }

        public List<BuildingBase> Buildings { get; set; }

        public Player(int gold)
        {
            Gold = gold;
            OverallIncome = 0;
            Buildings = new List<BuildingBase>();
        }

        public void AddBuilding(BuildingBase building)
        {
            if (Gold < building.GetPrice())
                throw new Exception("Niy mŏsz za dość postrzodkōw!"); //Insufficient funds!
            Buildings.Add(building);
            OverallIncome += building.GetIncome();
            Gold -= building.GetPrice();
        }
    }
}
