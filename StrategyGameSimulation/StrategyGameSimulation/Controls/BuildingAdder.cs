using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using StrategyGameSimulation.Interfaces;
using StrategyGameSimulation.CustomEvents;

namespace StrategyGameSimulation.Controls
{
    public partial class BuildingAdder : UserControl
    {
        public BuildingBase Building { get; set; }
        public event EventHandler<AddingBuildingEventArgs> AddingBuildingCustomEvent;
        public BuildingAdder(BuildingBase building)
        {
            InitializeComponent();
            Building = building;
            this.buildingName.Text = building.GetName();
            this.buildingIncome.Text = building.GetIncome().ToString();
            this.buildingPrice.Text = building.GetPrice().ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddingBuildingCustomEvent?.Invoke(sender, new AddingBuildingEventArgs(Building));
        }
    }
}
