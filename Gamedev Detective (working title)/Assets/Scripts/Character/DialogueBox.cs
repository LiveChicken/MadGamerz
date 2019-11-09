using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class DialogueBox : MonoBehaviour {

    public TMP_Text text;
    public GameObject Box;
    [Space]

    public float CharactersPerSecond;

    public float AutoTime = 1f;
    [Space]

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


        } else {

            Box.SetActive(false);
            
        }

    }

    public void WriteLine(int index) {

        
        //if writing currently add the new lines to the backlog
        if (writing) {


            var Split = getSplitLines(index);

            foreach (string s in Split) {

                backLog.Add(s);
            }

            return;
        }

        var toWrite = getSplitLines(index);
        

        StartCoroutine(writeLine(toWrite[0]));

        if (toWrite.Length > 1) {

            for (int i = 1; i < toWrite.Length; i++) {

                backLog.Add(toWrite[i]);
                
            }

        }

    }

    public string[] getSplitLines(int index) {

        string toBacklog = LanguageManager.LM.GetLine(index);

        var Split = toBacklog.Split('|');

        return Split;


    }

    IEnumerator writeLine(string s) {

        OnTextBegin?.Invoke();

        Box.SetActive(true);
        
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
        
        yield return new WaitForSeconds(AutoTime);
        
        CheckBacklog();
        yield break;

    }

}
