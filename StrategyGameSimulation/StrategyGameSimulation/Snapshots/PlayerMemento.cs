using StrategyGameSimulation.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Snapshots
{
    public class PlayerMemento
    {
        private readonly Player _player;

        public PlayerMemento(Player player) => _player = player;

        public Player GetState() => _player;
    }
}
