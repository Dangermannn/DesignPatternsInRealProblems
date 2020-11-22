using PopulationRegister.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PopulationRegister.Iterators
{
    public class PeopleIterator<T> : IEnumerator
    {
        private int _index = -1;
        private List<T> _items;

        public PeopleIterator(List<T> items)
        {
            _items = items;
        }
        public object Current => _items[_index];

        public bool MoveNext()
        {
            ++_index;
            if (_index < _items.Count)
                return true;
            return false;
        }

        public void Reset()
        {
            _index = -1;
        }
    }
}
