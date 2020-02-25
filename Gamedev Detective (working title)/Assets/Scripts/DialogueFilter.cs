using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DialogueFilter : MonoBehaviour {
     [System.Serializable]
   public  struct Line {

          public string Name;
          public string Dialogue;

     }

   public string FileName;
   
     private string Source;
     
     //[SerializeField]
     public List<Line> Lines = new List<Line>();


     private void Start() {
          
          SplitSource();
          
     }


     

     void SplitSource() {
          
          Lines.Clear();
          TextAsset tempFile = Resources.Load("Dialogue/English/" + FileName) as TextAsset; 
         // Debug.Log(tempFile.text);
        
          Source = tempFile.text;
       
          if (string.IsNullOrEmpty(Source)) {

               Debug.LogError("CANNOT FIND SOURCE");
               return;

          }
               
        
          string[] input = Source.Split("\n"[0]);

          for (int i = 0; i < input.Length; i++) {

               Line tempLine = new Line();
               
                tempLine.Name = String.Empty;
                tempLine.Dialogue = String.Empty;
               
               if (input[i].Contains(":")) {

                    string[] temp = input[i].Split(":"[0]);

                    tempLine.Name = temp[0];
                    tempLine.Dialogue = temp[1].TrimStart(' ');


               } else {

                    tempLine.Dialogue = input[i];

               }

               Lines.Add(tempLine);
               

          }


     }


}
