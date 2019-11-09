using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;
using UnityQuickSheet;

///
/// !!! Machine generated code !!!
///
public class DialogueMarlinAssetPostprocessor : AssetPostprocessor 
{
    private static readonly string filePath = "Assets/Text/ExcelFiles/Dialogue Marlon.xlsx";
    private static readonly string assetFilePath = "Assets/Text/ExcelFiles/DialogueMarlin.asset";
    private static readonly string sheetName = "DialogueMarlin";
    
    static void OnPostprocessAllAssets (string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string asset in importedAssets) 
        {
            if (!filePath.Equals (asset))
                continue;
                
            DialogueMarlin data = (DialogueMarlin)AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(DialogueMarlin));
            if (data == null) {
                data = ScriptableObject.CreateInstance<DialogueMarlin> ();
                data.SheetName = filePath;
                data.WorksheetName = sheetName;
                AssetDatabase.CreateAsset ((ScriptableObject)data, assetFilePath);
                //data.hideFlags = HideFlags.NotEditable;
            }
            
            //data.dataArray = new ExcelQuery(filePath, sheetName).Deserialize<DialogueMarlinData>().ToArray();		

            //ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
            //EditorUtility.SetDirty (obj);

            ExcelQuery query = new ExcelQuery(filePath, sheetName);
            if (query != null && query.IsValid())
            {
                data.dataArray = query.Deserialize<DialogueMarlinData>().ToArray();
                ScriptableObject obj = AssetDatabase.LoadAssetAtPath (assetFilePath, typeof(ScriptableObject)) as ScriptableObject;
                EditorUtility.SetDirty (obj);
            }
        }
    }
}
