using System;
using System.Collections.Generic;
using UnityEngine;

namespace AutoSet
{
    public class AutoSetDataSO<TKey, TValue, TDic> : ScriptableObject
        where TKey : Enum
        where TDic : AutoSetDictionary<TKey, TValue>, new()
    {
        
        [Header("取得するファイルが入ったフォルダのパス(最後の/は不要)"), SerializeField]
        private string _folderPath = "Assets/";
        public string FolderPath => _folderPath;
        [Header("Enumファイルを保存するフォルダのパス(最後の/は不要)"), SerializeField]
        private string _enumPath = "Assets/";
        public string ENUM_PATH => _enumPath;
        
        [Header("Enumの名前空間(絶対に何か入力する)"), SerializeField]
        private string _enumNameSpace = "";
        public string ENUM_NAME_SPACE => _enumNameSpace;
        [Header("Enumファイル名"), SerializeField]
        private string _enumFileName = "";
        public string ENUM_FILE_NAME => _enumFileName;
        
        [Header("拡張子(「*.拡張子」の形で記述)"), SerializeField]
        private string[] _fileExtension;
        public string[] FILE_EXTENTIONS => _fileExtension;
        
        [Header("取り除くフォルダ名"), SerializeField]
        private string[] _removeFolderName;
        public string[] REMOVE_FOLDER_NAME => _removeFolderName;
        
        [SerializeField]
        private TDic _dataDic = new ();
        protected Dictionary<TKey, TValue> _DataDic => _dataDic.DataDic;
        
        /// <summary>
        /// 配列を辞書に上書きしてセット
        /// </summary>
        /// <param name="values"></param>
        public void SetData(TValue[] values)
        {
            _dataDic.SetData(values);
        }
        
        /// <summary>
        /// 辞書型のようにデータ取得
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue GetData(TKey key)
        {
            return _DataDic[key];
        }
    }
}