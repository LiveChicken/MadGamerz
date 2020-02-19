using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityScript.Macros;


public class LanguageManager : MonoBehaviour {


     public static string CurrentLanguage = "English";

     //TODO: add way to change this!
     
     

     //  DialogueBox.

     //public static LanguageManager LM;

     //public  Language language;

     //  public  DialogueMarlin DialogueMarlin;

     //TODO: potential resources.load / unlad to manage memory better. 


     //  private void Awake() {

     //  LM = this;

     // }

     /*   public  string GetLine(int index) {
   
           //  DialogueBox.writeLineDelegate?.Invoke(1);
             
             string output = "No Line Found @ " + language + " " + index;
   
             try {
                  switch (language) {
   
                       case (Language.English):
                            output = DialogueMarlin.dataArray[index].English;
                            break;
   
                       case (Language.French):
                            output = DialogueMarlin.dataArray[index].French;
                            break;
   
                       case (Language.Irish):
                            output = DialogueMarlin.dataArray[index].Irish;
                            break;
   
                  }
             } catch {
   
             }
   
             return output;
   
   
        }*/

}

//public enum Language {

    //English = 1,
   // French = 2,
  //  Irish = 3
    
//}

