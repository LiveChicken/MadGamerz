//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Web;
//using UnityEditor;
//using UnityEditor.UIElements;
using UnityEngine;
//using UnityEngine.UI;
//using UnityEngine.XR.WSA.Persistence;


[System.Serializable]
[CreateAssetMenu(fileName = "New Key", menuName = "ScriptableObjects/Key", order = 1)]
public class Key : ScriptableObject
{
   // [System.Serializable]
   // public class Key {

     public string Name;
     [TextArea(3,20)]
     public string Description;


     //public uint Code;
          
    


    

     
     public Sprite KeySprite;

     
   //  public string UniqueID;


          // #if UNITY_EDITOR
     void SetUniqueID() {
          //UniqueID = Name + " | " + System.DateTime.Now + " | " + Code;
         // UniqueID = Guid.NewGuid().ToString();

     }

 /*
#if UNITY_EDITOR

     [CustomEditor(typeof(Key))]
     class CustomTypeEditor : Editor {
          public override void OnInspectorGUI() {
               Key customType = (Key) target;

               DrawDefaultInspector();

               if (GUILayout.Button("Set Unique ID")) {

                    customType.SetUniqueID();
                    
               }


          }
     }

#endif */
     
     
    // #endif



     //public Hash128 Hash;



     //}
}
