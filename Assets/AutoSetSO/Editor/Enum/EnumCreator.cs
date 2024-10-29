#if UNITY_EDITOR
using System.IO;
using UnityEditor;
using System.Collections.Generic;
using System.Text;

namespace AutoSet
{
    public static class EnumCreater
    {
        private const string SAVE_PATH_FORMAT = "{0}/{1}.cs";

        private const string LINE_BREAK = "\n";
        private const string TAB = "\t";
        private const string START_CURLY_BRACE = "{";
        private const string END_CURLY_BRACE = "}";
        
        private const string NAMESPACE_FORMAT = "namespace {0}";
        private const string ENUM_NAME_FORMAT = "public enum {0}";
        private const string ENUM_CONTENT_FORMAT = "{0},";

        /// <summary>
        /// Enum生成
        /// </summary>
        /// <param name="enumList"> 設定するEnumリスト </param>
        /// <param name="folderPath"> Enumのファイルを格納するフォルダのパス </param>
        /// <param name="enumFileName"> Enumのファイル名 </param>
        /// <returns></returns>
        public static void CreateEnum(string[] enumList, string folderPath, string nameSpace, string enumFileName)
        {
            string enumCode = GetEnumCode(enumList, nameSpace, enumFileName);
            
            string savePath =GetPath(SAVE_PATH_FORMAT, folderPath, enumFileName);

            File.WriteAllText(savePath, enumCode);
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// Enumのコードを取得
        /// </summary>
        /// <param name="enumList"> 設定するEnumリスト </param>
        /// <param name="enumFileName"> Enumのファイル名 </param>
        /// <returns></returns>
        private static string GetEnumCode(string[] enumList, string nameSpace, string enumFileName)
        {
            var codeBuilder = new StringBuilder();

            codeBuilder.AppendFormat(NAMESPACE_FORMAT, nameSpace);
            codeBuilder.Append(LINE_BREAK);
                
            codeBuilder.Append(START_CURLY_BRACE);
            codeBuilder.Append(LINE_BREAK);
                
            codeBuilder.Append(TAB);
            codeBuilder.AppendFormat(ENUM_NAME_FORMAT, enumFileName);
            codeBuilder.Append(LINE_BREAK);
                
            codeBuilder.Append(TAB);
            codeBuilder.Append(START_CURLY_BRACE);
            codeBuilder.Append(LINE_BREAK);

            int paramLength = enumList.Length;
            for (int i = 0; i < paramLength; i++)
            {
                codeBuilder.Append(TAB);
                codeBuilder.Append(TAB);
                codeBuilder.AppendFormat(ENUM_CONTENT_FORMAT, enumList[i]);
                codeBuilder.Append(LINE_BREAK);
            }
                
            codeBuilder.Append(TAB);
            codeBuilder.Append(END_CURLY_BRACE);
                
            codeBuilder.Append(END_CURLY_BRACE);

            return codeBuilder.ToString();
        }

        private static string GetPath(string format, params string[] args)
        {
            var pathBuilder = new StringBuilder();
            pathBuilder.AppendFormat(format, args);
            return pathBuilder.ToString();
        }
    }
}
#endif

