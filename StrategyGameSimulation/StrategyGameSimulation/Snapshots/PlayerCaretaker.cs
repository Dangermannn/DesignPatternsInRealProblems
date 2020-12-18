using System;
using System.Collections.Generic;
using System.Text;

namespace StrategyGameSimulation.Snapshots
{
    public class PlayerCaretaker
    {
        private Stack<PlayerMemento> _mementos = new Stack<PlayerMemento>();

        public void AddMemento(PlayerMemento memento) => _mementos.Push(memento);

        public PlayerMemento GetMemento()
        {
            if (_mementos.Count == 0)
                throw new Exception("Niy mŏ pōnktu do prziwrōcyniŏ!");
            return _mementos.Pop();
        }
    }
}
