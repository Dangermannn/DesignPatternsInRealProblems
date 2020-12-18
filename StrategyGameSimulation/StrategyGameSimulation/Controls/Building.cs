using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using StrategyGameSimulation.Interfaces;

namespace StrategyGameSimulation.Controls
{
    public partial class Building : UserControl
    {
        public Building(BuildingBase building)
        {
            InitializeComponent();
            buildingName.Text = building.GetName();
            buildingIncome.Text = building.GetIncome().ToString();
        }
    }
}
