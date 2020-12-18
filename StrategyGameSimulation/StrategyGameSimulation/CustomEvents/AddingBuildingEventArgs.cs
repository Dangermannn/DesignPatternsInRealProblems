using StrategyGameSimulation.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.CustomEvents
{
    public class AddingBuildingEventArgs : EventArgs
    {
        public BuildingBase Building { get; set; }

        public AddingBuildingEventArgs(BuildingBase building) : base()
        {
            Building = building;
        }
    }
}
