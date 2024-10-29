#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace AutoSet
{
    public abstract class AutoSetDataSOEditor<TKey, TValue, TFile, TDic, TSO> : Editor
        where TKey : Enum
        where TFile : UnityEngine.Object
        where TDic : AutoSetDictionary<TKey, TValue>, new()
        where TSO : AutoSetDataSO<TKey, TValue, TDic>
    {
        /// <summary>
        /// Enumの最初の値
        /// </summary>
        private const string DEFAULT = "None";
        
        protected TSO _Target;

        private void OnEnable()
        {
            _Target = target as TSO;
        }
        
        public override void OnInspectorGUI()
        {
            EditorGUILayout.LabelField("取得するファイル名を数字で始めない(0_aaaとかにするとEnumに変換できない)");
            var button = GUILayout.Button("SetData");
            
            base.OnInspectorGUI();
            
            if (button)
            {
                LoadFiles();
            }
        }
        
        protected void LoadFiles()
        {
            string[] filePaths = GetPaths();
            string[] enumParams;
            TFile[] files;
            
            LoadFiles(filePaths, out enumParams, out files);

            CreateEnumFile(enumParams);
            
            SetData(files);
            
            AssetDatabase.SaveAssets();
            Debug.Log("Load Complete");
        }
        
        private string[] GetPaths()
        {
            List<string> paths = new List<string>();

            foreach (var extention in _Target.FILE_EXTENTIONS)
            {
                var allPaths = Directory.GetFiles(_Target.FolderPath, extention, SearchOption.AllDirectories);
                Debug.Log($"Get {allPaths.Length} files with {extention} extention.");
                foreach (var path in allPaths)
                {
                    if(ContainsFolder(path, _Target.REMOVE_FOLDER_NAME))
                    {
                        Debug.Log($"{path} is removed.");
                        continue;
                    }
                    
                    Debug.Log($"{path} is added.");
                    paths.Add(path);
                }
            }
            
            return paths.ToArray();
        }
        
        private bool ContainsFolder(string path, string[] folderNames)
        {
            var directories = path.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

            foreach (var folderName in folderNames)
            {
                bool isContain = directories.Contains(folderName, StringComparer.OrdinalIgnoreCase);
                
                if (isContain)
                {
                    return true;
                }
            }

            return false;
        }

        private void LoadFiles(string[] paths, out string[] enumParams, out TFile[] clips)
        {
            int clipCount = paths.Length;
            enumParams = new string [clipCount+1];
            clips = new TFile[clipCount];

            enumParams[0] = DEFAULT;
            for (int i = 0; i < clipCount; i++)
            {
                string path = paths[i];
                
                var fileName = Path.GetFileNameWithoutExtension(path);
                enumParams[i + 1] = fileName.Replace(" ", "").Replace("/", "");
                
                clips[i] = AssetDatabase.LoadAssetAtPath<TFile>(path);
            }
        }
        
        private void CreateEnumFile(string[] enumParams)
        {
            EnumCreater.CreateEnum(enumParams, _Target.ENUM_PATH, _Target.ENUM_NAME_SPACE, _Target.ENUM_FILE_NAME);
        }
        
        protected abstract void SetData(TFile[] filess);
    }
}

#endif