using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Interfaces
{
    [Serializable]
    public abstract class BuildingBase
    {
        public BuildingBase GetBuilding(List<BuildingBase> buildings)
        {
            try
            {
                if (IsPossible(buildings))
                    return CreateBuilding();
                throw new Exception("Potrzebujesz kamieniołomu, chatki siōngŏrza i tartaku coby stworzić tyn budōnek!");
            }
            catch(Exception e)
            {
                throw e;
            }
        }
        public abstract string GetName();
        public abstract int GetIncome();
        public abstract int GetPrice();
        public abstract bool IsPossible(List<BuildingBase> buildings);
        public abstract BuildingBase CreateBuilding();
    }
}
