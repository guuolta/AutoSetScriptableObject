using UnityEditor;
using UnityEngine;
using UnityEngine.Pool;

namespace AutoSet.Demo
{
    [CustomEditor(typeof(SO))]
    public class AutoSetDataSOEditor : AutoSetDataSOEditor<Type, Data, GameObject, AutoSetDictionary<Type, Data>, SO>
    {
        protected override void SetData(GameObject[] files)
        {
            int length = files.Length;
            Data[] datas = new Data[length];

            for (int i = 0; i < length; i++)
            {
                datas[i] = new Data(i, files[i].name, files[i]);
            }
            
            _Target.SetData(datas);
        }
    }
}
