using StrategyGameSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Models
{
    [Serializable]
    public class StonePit : BuildingBase
    {
        private const string NAME = "Kamieniołom"; // Stone pit
        private const int INCOME = 200;
        private const int PRICE = 500;

        public override bool IsPossible(List<BuildingBase> buildings) => true;

        public override int GetIncome() => INCOME;

        public override string GetName() => NAME;

        public override int GetPrice() => PRICE;

        public override BuildingBase CreateBuilding() => new StonePit();
    }
}
