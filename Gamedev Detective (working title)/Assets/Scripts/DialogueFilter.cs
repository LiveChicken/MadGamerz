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

    
   
    [Space]

     private string Source;
     
     //[SerializeField]
     public List<Line> Lines = new List<Line>();
     
     public List<Choice> Choices = new List<Choice>();

    [System.Serializable]
      public class Choice {

       // public string FileName;
         public Line Option;
         public List<Line> ChoiceLines = new List<Line>();
      
      }
     private void Start() {
          
          SplitSource();
          
     }



   string GetChoices(string source)
    {

        string top;
        string mid;
        string bot;

        top = source.TrimEnd('{');
        bot = source.TrimStart('}');
        //  mid = source.Trim();

        string comb = top + bot;

        Debug.Log(top);
        Debug.Log(bot);
        Debug.Log(comb);

        return comb;
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

        // string seperatedChoices = Source.Contains 

        

        
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

        for (int i = 0; i < Choices.Count; i++)
        {

            string FilePath = "Dialogue/English/" + FileName + "_Choice_" + i;

            //Resources.Load;
            TextAsset tempChoiceFile = Resources.Load(FilePath) as TextAsset;
            // Debug.Log(tempFile.text);

            string ChoiceSource = tempChoiceFile.text;

            if (string.IsNullOrEmpty(ChoiceSource))
            {

                Debug.LogError("CANNOT FIND SOURCE");
                return;

            }

            
            string[] choiceInput = ChoiceSource.Split("\n"[0]);



           // for (int i = 0; i < Choices.Count; i++)

            for (int j = 0; j < choiceInput.Length; j++)
            {

                Line tempLine = new Line();

                tempLine.Name = String.Empty;
                tempLine.Dialogue = String.Empty;

                if (choiceInput[j].Contains(":"))
                {

                    string[] temp = choiceInput[j].Split(":"[0]);

                    tempLine.Name = temp[0];
                    tempLine.Dialogue = temp[1].TrimStart(' ');


                }
                else
                {

                    tempLine.Dialogue = choiceInput[j];

                }


                if (j == 0)
                {
                    Choices[i].Option = tempLine;
                }
                else
                {

                    Choices[i].ChoiceLines.Add(tempLine);

                }


            }




        }
          


     }

    public void AddChoices(int index)
    {
        for (int i = 0; i < Choices[index].ChoiceLines.Count; i++)
        {

            Lines.Add(Choices[index].ChoiceLines[i]);

        }
        //Lines.Add(Choices[0].ChoiceLines)


    }


}
