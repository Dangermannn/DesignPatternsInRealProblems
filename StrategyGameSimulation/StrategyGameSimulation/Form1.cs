using StrategyGameSimulation.Controls;
using StrategyGameSimulation.CustomEvents;
using StrategyGameSimulation.Interfaces;
using StrategyGameSimulation.Models;
using StrategyGameSimulation.Snapshots;
using System;
using System.Windows.Forms;

namespace StrategyGameSimulation
{
    public partial class Form1 : Form
    {
        private const int INCOME_TIMER = 5000;
        private Player _player;

        private PlayerOrdinator _playerOrdinator;
        private PlayerCaretaker _playerCaretaker;

        public Form1()
        {
            InitializeFields();
            InitializeComponent();
            InitializeMainWindow();
            InitializeBuildingAdder();
            InitializeTimer();
        }

        private void InitializeFields()
        {
            _player = new Player(2000);
            _playerOrdinator = new PlayerOrdinator();
            _playerCaretaker = new PlayerCaretaker();
        }

        private void InitializeTimer()
        {
            mainTimer.Interval = INCOME_TIMER;
            mainTimer.Tick += new EventHandler(UpdateGold);

            mainTimer.Enabled = true;
        }
        private void InitializeMainWindow()
        {
            currentGoldValue.Text = _player.Gold.ToString();
            overallIncomeValue.Text = _player.OverallIncome.ToString();
        }

        private void InitializeBuildingAdder()
        {
            var goldMine = new BuildingAdder(new GoldMine());
            var mint = new BuildingAdder(new Mint());
            var sawmill = new BuildingAdder(new Sawmill());
            var stonePit = new BuildingAdder(new StonePit());
            var woodcutter = new BuildingAdder(new WoodcuttersHut());

            goldMine.AddingBuildingCustomEvent += new EventHandler<AddingBuildingEventArgs>(AddBuildingCustomEvent);
            mint.AddingBuildingCustomEvent += new EventHandler<AddingBuildingEventArgs>(AddBuildingCustomEvent);
            sawmill.AddingBuildingCustomEvent += new EventHandler<AddingBuildingEventArgs>(AddBuildingCustomEvent);
            stonePit.AddingBuildingCustomEvent += new EventHandler<AddingBuildingEventArgs>(AddBuildingCustomEvent);
            woodcutter.AddingBuildingCustomEvent += new EventHandler<AddingBuildingEventArgs>(AddBuildingCustomEvent);

            availableBuildingsPanel.Controls.Add(goldMine);
            availableBuildingsPanel.Controls.Add(mint);
            availableBuildingsPanel.Controls.Add(sawmill);
            availableBuildingsPanel.Controls.Add(stonePit);
            availableBuildingsPanel.Controls.Add(woodcutter);
        }

        private void CreateBuilding(BuildingBase building)
        {
            try
            {
                _playerOrdinator.SetState(_player);
                _playerCaretaker.AddMemento(_playerOrdinator.SaveStateToMemento());
                _player.AddBuilding(building);
                playerBuildings.Controls.Add(new Building(building));
            }catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        } 

        private void AddBuildingCustomEvent(object sender, AddingBuildingEventArgs e)
        {
            try
            {
                CreateBuilding(e.Building.GetBuilding(_player.Buildings));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            currentGoldValue.Text = _player.Gold.ToString();
            overallIncomeValue.Text = _player.OverallIncome.ToString();
        }

        private void UpdateGold(object sender, EventArgs e)
        {
            _player.Gold += _player.OverallIncome;
            currentGoldValue.Text = _player.Gold.ToString();
        }

        private void RecoverToState()
        {
            try
            {
                _playerOrdinator.GetStateFromMemento(_playerCaretaker.GetMemento());
                _player = _playerOrdinator.GetState();

                InitializeMainWindow();

                playerBuildings.Controls.Clear();
                foreach (var building in _player.Buildings)
                    playerBuildings.Controls.Add(new Building(building));
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            RecoverToState();
        }
    }
}
