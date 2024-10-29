using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace AutoSet
{
    /// <summary>
    /// シリアライズ可能な辞書型
    /// </summary>
    /// <typeparam name="TKey"> キー </typeparam>
    /// <typeparam name="TValue"> 値 </typeparam>
    [Serializable]
    public class SerializableDictionary<TKey, TValue>
    {
        [FormerlySerializedAs("_datas")] [SerializeField]
        protected Data[] _Datas;
    
        private Dictionary<TKey, TValue> _dataDic = null;
        public Dictionary<TKey, TValue> DataDic
        {
            get
            {
                if(_isEmpty)
                {
                    ToDictionary();
                }
    
                return _dataDic;
            }
        }
    
        private bool _isEmpty => _dataDic is null;
    
        private void ToDictionary()
        {
            _dataDic = new();
    
            foreach (var data in _Datas)
            {
                var key = data.Key;
    
                if(!_dataDic.ContainsKey(key))
                {
                    _dataDic.Add(key, data.Value);
                }
            }
        }
    
        [Serializable]
        protected class Data
        {
            [SerializeField]
            private TKey _key;
            public TKey Key => _key;
            [SerializeField]
            private TValue _value;
            public TValue Value => _value;
            
            public Data(TKey key, TValue value)
            {
                _key = key;
                _value = value;
            }
        }
    }
}
