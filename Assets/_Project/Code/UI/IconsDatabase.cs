using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.UI
{
    [Serializable]
    public struct IconsDatabase
    {
        [SerializeField]
        private List<Icon> _list;

        private Dictionary<string, Sprite> _icons;

        public Sprite this[string key]
        {
            get
            {
                TryFill();

                return _icons[key];
            }
        }

        public bool TryGetValue(string key, out Sprite value)
        {
            TryFill();

            return _icons.TryGetValue(key, out value);
        }

        private void TryFill()
        {
            if (_icons == null)
            {
                _icons = new Dictionary<string, Sprite>(_list.Capacity);

                for (int i = 0; i < _list.Count; i++)
                {
                    var element = _list[i];
                    _icons[element.key] = element.sprite;
                }
            }
        }

        [Serializable]
        public struct Icon
        {
            public string key;
            public Sprite sprite;
        }
    }
}