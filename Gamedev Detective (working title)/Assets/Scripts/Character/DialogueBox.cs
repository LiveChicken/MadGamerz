using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class DialogueBox : MonoBehaviour {

    public TMP_Text text;

    public float CharactersPerSecond;

    public UnityEvent OnTextBegin;
    public UnityEvent OnTextEnd;
    public UnityEvent OnCharacterShow;

    private bool writing;
    
    //System.Action<>
    public  delegate void WriteLineDelegate(int index);
            public static WriteLineDelegate writeLineDelegate = delegate(int index) {
                
            };

    
    List<string>backLog = new List<string>();

    private void OnEnable() {

        writeLineDelegate += WriteLine;

    }

    private void OnDisable() {
        writeLineDelegate -= WriteLine;
    }

    void CheckBacklog() {

        if (backLog.Count > 0) {

            if (!writing) {

                string toWrite = backLog[0];
                backLog.Remove(toWrite);

                StartCoroutine(writeLine(toWrite));
            }


        }

    }

    public void WriteLine(int index) {

        if (writing) {

            //TODO: Queue?
            string toBacklog = LanguageManager.LM.GetLine(index);
            
            backLog.Add(toBacklog);
            
            return;
        }

        string toWrite = LanguageManager.LM.GetLine(index);

        StartCoroutine(writeLine(toWrite));

    }

    IEnumerator writeLine(string s) {

        OnTextBegin?.Invoke();
        
        writing = true;

       // int totalVisibleCharacters = text.textInfo.characterCount;
        int counter = 0;

        while (counter < s.Length) {

           // int visibleCount = counter % (totalVisibleCharacters + 1);


            text.text = s;
            text.maxVisibleCharacters = counter;
           // text.maxVisibleWords
            
            OnCharacterShow?.Invoke();

            //if (visibleCount >= totalVisibleCharacters) {

                yield return new WaitForSeconds(1/ CharactersPerSecond);

                counter++;

            //}

        }


        


        
        
        OnTextEnd?.Invoke();

        writing = false;
        
        yield return new WaitForSeconds(1f);
        
        CheckBacklog();
        yield break;

    }

}
