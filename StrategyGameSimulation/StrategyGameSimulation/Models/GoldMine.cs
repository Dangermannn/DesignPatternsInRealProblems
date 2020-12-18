using StrategyGameSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Models
{
    [Serializable]
    public class GoldMine : BuildingBase
    {
        private const string NAME = "Gruba złotŏ"; // Gold mine
        private const int INCOME = 100;
        private const int PRICE = 5000;

        public override bool IsPossible(List<BuildingBase> buildings)
        {
            bool isSawmill = false;
            bool isStonePit = false;
            bool isWoodcuttersHut = false;
            foreach(var building in buildings)
            {
                if (building is Sawmill)
                    isSawmill = true;
                else if (building is StonePit)
                    isStonePit = true;
                else if (building is WoodcuttersHut)
                    isWoodcuttersHut = true;

                if (isSawmill && isStonePit && isWoodcuttersHut)
                    return true;
            }
            return false;
        }

        public override int GetIncome() => INCOME;

        public override string GetName() => NAME;

        public override int GetPrice() => PRICE;

        public override BuildingBase CreateBuilding() => new GoldMine();
    }
}
