using UnityEngine;

namespace AutoSet.Demo
{
    [CreateAssetMenu(fileName = "DemoSO", menuName = "ScriptableObjects/DemoSO")]
    public class SO : AutoSetDataSO<Type, Data, AutoSetDictionary<Type, Data>>
    {
        
    }
}
