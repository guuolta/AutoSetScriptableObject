# AutoSetScriptableObject
自動でファイルやオブジェクトを設定してくれるスクリプタブルオブジェクト  
保存されるデータは辞書型のように保存され、キーがEnum、データは自由な形式です。
## 使い方
### 1. スクリプタブルオブジェクトの準備
AutoSet.AutoSetDataSOというクラスを継承したスクリプトを作成  
ジェネリックは、<Enum, データ, AutoSetData<Enum, データ>>です。(ここでの、Enumとデータは両方同じ型)  
Enumとデータは適当なものを作成していください。
### 2. Editorの準備
AutoSet.AutoSetDataSOEditorというクラスを継承したスクリプトを**Editorフォルダ**に作成。(Editorフォルダがない場合は自身で作成)  
ジェネリックは、<Enum, データ, 取得したいファイル, AutoSetData<Enum, データ>, 先ほど作成したスクリプタブルオブジェクト>です。(ここでの、Enumとデータは両方同じ型)
