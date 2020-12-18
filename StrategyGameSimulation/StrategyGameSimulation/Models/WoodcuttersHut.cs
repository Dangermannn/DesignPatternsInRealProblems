using StrategyGameSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Models
{
    [Serializable]
    public class WoodcuttersHut : BuildingBase
    {
        private const string NAME = "Chatka siōngŏrza"; // Woodcutter's Hut
        private const int INCOME = 300;
        private const int PRICE = 1500;

        public override bool IsPossible(List<BuildingBase> buildings) => true;

        public override int GetIncome() => INCOME;

        public override string GetName() => NAME;

        public override int GetPrice() => PRICE;

        public override BuildingBase CreateBuilding() => new WoodcuttersHut();
    }
}
