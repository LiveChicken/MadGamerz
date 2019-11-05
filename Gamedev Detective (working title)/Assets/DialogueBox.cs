using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueBox : MonoBehaviour {

    public TMP_Text text;

    private bool writing;
    
    //System.Action<>
    public  delegate void WriteLineDelegate(int index);
            public static WriteLineDelegate writeLineDelegate = delegate(int index) {
                
            };


    private void OnEnable() {

        writeLineDelegate += WriteLine;

    }

    private void OnDisable() {
        writeLineDelegate -= WriteLine;
    }

    public void WriteLine(int index) {

        if (writing) {

            //TODO: Queue?
            return;
        }

        string toWrite = LanguageManager.LM.GetLine(index);

        StartCoroutine(writeLine(toWrite));

    }

    IEnumerator writeLine(string s) {

        writing = true;
        
        text.text = s;


        writing = false;
        yield break;

    }

}
