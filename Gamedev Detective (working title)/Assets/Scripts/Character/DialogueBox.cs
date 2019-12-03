using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;


public class DialogueBox : MonoBehaviour {

    public TMP_Text text;
    public GameObject Box;
    [Space]

    public float CharactersPerSecond;

    public float AutoTime = 1f;

    public Mode mode;
    [Space]

    public UnityEvent OnTextBegin;
    public UnityEvent OnTextEnd;
    public UnityEvent OnCharacterShow;

    
    //this is likely to break
    private int lastIndex = -1;

    private Coroutine LineWriting; // = new Coroutine();

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

       //if (LineWriting != null)  StopCoroutine(LineWriting);

        stopWriting();
        
        if (backLog.Count > 0) {

            if (!writing) {

                string toWrite = backLog[0];
                backLog.Remove(toWrite);

                LineWriting = StartCoroutine(writeLine(toWrite));
            }


        } else {

            lastIndex = -1;
            Box.SetActive(false);
            
        }

    }

    public void WriteLine(int index) {

       // Debug.Log("Made it this far");
        
       

        
        if (mode != GameManager.GM.TS) {

            backLog.Clear();
            
            return;

        }

        if (index == lastIndex) {

            // CheckBacklog();
            return;

        }
        

        //if writing currently add the new lines to the backlog
        if (writing) {

           

            lastIndex = index;

            var Split = getSplitLines(index);

            foreach (string s in Split) {

                backLog.Add(s);
            }

            return;
        }

        lastIndex = index;
        
        var toWrite = getSplitLines(index);

       stopWriting();
        LineWriting = StartCoroutine(writeLine(toWrite[0]));

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


    private void Update() {


        if (writing) {
            if (GameManager.GM.controls.Player.A.triggered) {

                   CheckBacklog();

            }
        }

    }

    void stopWriting() {

        if (LineWriting != null) StopCoroutine(LineWriting);
        LineWriting = null;

        OnTextEnd?.Invoke();

        writing = false;
        
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
        
        
        Debug.Log("Auto Advanced");
        CheckBacklog();
        yield break;

    }

}
