using UnityEngine;

namespace AutoSet.Demo
{
    public class TestGet : MonoBehaviour
    {
        [SerializeField]private SO _so;
        [SerializeField]private Type _type;
        
        private void Start()
        {
            Data data = _so.GetData(_type);
            Debug.Log($"dataId{data.Id}, dataName{data.Name}");
            Instantiate(data.Prefab);
        }
    }
}
