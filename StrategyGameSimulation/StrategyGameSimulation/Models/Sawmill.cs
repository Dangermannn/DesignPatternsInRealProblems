using StrategyGameSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Models
{
    [Serializable]
    public class Sawmill : BuildingBase
    {
        private const string NAME = "Tartak"; // Sawmill
        private const int INCOME = 500;
        private const int PRICE = 3000;

        public override bool IsPossible(List<BuildingBase> buildings) => true;
        public override int GetIncome() => INCOME;

        public override string GetName() => NAME;

        public override int GetPrice() => PRICE;

        public override BuildingBase CreateBuilding() => new Sawmill();
    }
}
