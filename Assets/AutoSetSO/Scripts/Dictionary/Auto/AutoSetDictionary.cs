using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoSet
{
    /// <summary>
    /// インスペクターからボタンを押してデータをセットする時に使うDictionary
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class AutoSetDictionary<TKey, TValue> : SerializableDictionary<TKey, TValue>
        where TKey : Enum
    {
        /// <summary>
        /// <para>配列を上書きしてデータをセット</para>
        /// <para>キーは初期状態を飛ばした一番上から順に設定</para>
        /// <para>値は配列の初めから順に設定</para>
        /// <para>値の配列がenumの上限を超えたら、その先は追加されない</para>
        /// <para>キーが重複している場合、値を追加せず飛ばす</para>
        /// </summary>
        /// <param name="values">辞書の値に登録するデータ</param>
        public void SetData(TValue[] values)
        {
            _Datas = new Data[values.Length];
            int validEnumLength = Enum.GetValues(typeof(TKey)).Length-1;
            var usedKeys = new HashSet<TKey>();
            
            for (int i = 0; i < values.Length; i++)
            {
                if(i >= validEnumLength)
                {
                    break;
                }
                
                var key = (TKey)Enum.ToObject(typeof(TKey), i+1);

                if (usedKeys.Contains(key))
                {
                    Debug.LogError($"{key}:{values[i]} is already used.");
                    continue;
                }
                
                usedKeys.Add(key);
                AddData(i, key, values[i]);
            }
        }
        
        protected virtual void AddData(int index, TKey key, TValue value)
        {
            _Datas[index] = new Data(key, value);
        }
    }
}
