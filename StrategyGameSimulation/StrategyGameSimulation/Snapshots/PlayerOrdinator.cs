using StrategyGameSimulation.Models;
using StrategyGameSimulation.ExtensionMethods;

namespace StrategyGameSimulation.Snapshots
{
    public class PlayerOrdinator
    {
        private Player _player;

        public void SetState(Player player) => _player = player;

        public Player GetState() => _player;

        public PlayerMemento SaveStateToMemento() => new PlayerMemento(_player.DeepCopy());

        public void GetStateFromMemento(PlayerMemento memento) => _player = memento.GetState();
    }
}
