using System;
using UnityEngine;

namespace AutoSet.Demo
{
    [Serializable]
    public class Data
    {
        [SerializeField] private int _id;
        public int Id => _id;
        [SerializeField] private string _name;
        public string Name => _name;
        [SerializeField] private GameObject _prefab;
        public GameObject Prefab => _prefab;
        
        public Data(int id, string name, GameObject prefab)
        {
            _id = id;
            _name = name;
            _prefab = prefab;
        }
    }
}
