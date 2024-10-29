# AutoSetScriptableObject
自動でファイルやオブジェクトを設定してくれるスクリプタブルオブジェクト  
保存されるデータは辞書型のように保存され、キーがEnum、データは自由な形式です。
Enumは、ファイルの名前で自動生成されます。

## 構成
### 名前空間
AutoSet
### クラス
#### SerializableDictionary
インスペクターで触れる辞書型  
**DataDic**  
辞書を取得できる  
**SetData**  
辞書に値を設定  

#### AutoSetDictionary
外部から値を設定できるようにしたSerializableDictionary  
**SetData**  
辞書に値を設定  
**AddSet**  
辞書にデータを登録する  

#### AutoSetDataSO
ボタンを押すと自動でデータを設定してくれるスクリプタブルオブジェクト  
**SetData**  
配列を辞書に上書きしてセット  
**GetData**  
辞書型のようにデータ取得  

#### AutoSetDataSOEditor
AutoSetDataSOのエディタ拡張を行う  
**SetData**  
配列を辞書に上書きしてセット  

#### EnumCreater
Enumファイルの生成を行う  
**CreateEnum**  
Enumファイルの生成  

## 使い方
### 1. スクリプタブルオブジェクトの準備
AutoSet.AutoSetDataSOというクラスを継承したスクリプトを作成  
ジェネリックは、<Enum, データ, AutoSetData<Enum, データ>>です。(ここでの、Enumとデータは両方同じ型)  
Enumとデータは適当なものを作成していください。
### 2. Editorの準備
AutoSet.AutoSetDataSOEditorというクラスを継承したスクリプトを**Editorフォルダ**に作成。(Editorフォルダがない場合は自身で作成)  
ジェネリックは、<Enum, データ, 取得したいファイル, AutoSetData<Enum, データ>, 先ほど作成したスクリプタブルオブジェクト>です。(ここでの、Enumとデータは両方同じ型)
### 3. Editorの書き変え
先ほど作成したスクリプトのSetData関数で、_Target.SetData関数にデータの配列を設定する。
