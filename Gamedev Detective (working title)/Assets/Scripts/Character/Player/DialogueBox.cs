using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

            [RequireComponent(typeof(DialogueFilter))]
public class DialogueBox : MonoBehaviour {

    public TMP_Text text;
    public TMP_Text name;
    public GameObject Box;
    [Space]

    public float CharactersPerSecond;

  //  public float AutoTime = 1f;

    public Mode mode;
    [Space]

    public UnityEvent OnTextBegin;
    public UnityEvent OnTextEnd;
    public UnityEvent OnCharacterShow;

    
    //this is likely to break
   // private int lastIndex = -1;

    private Coroutine LineWriting; // = new Coroutine();
    
    
    private static bool writing;

    public static bool IsWriting {
        get { return writing;}
        set { IsWriting = writing; }
    }


    private int index;
    private DialogueFilter Filter;


    public delegate void WriteLineDelegate(int i);

    public static WriteLineDelegate writeLineDelegate = delegate {

    };


    private void OnEnable() {

       writeLineDelegate += WriteLine;

    }

    private void OnDisable() {

       writeLineDelegate -=WriteLine;

    }


    private void Start() {

        Filter = GetComponent<DialogueFilter>();

    }

    public void HideBox() {

        Box.SetActive(false);
        
    }



    public void WriteLine(int i) {

        if (i >= 0) {
            index = i;
        }

        WriteNextLine();

    }

    public void WriteNextLine() {

  
        if (writing) {

       
            return;
        }

      

       stopWriting();
        LineWriting = StartCoroutine(writeLine(Filter.Lines[index].Dialogue));
        name.text = Filter.Lines[index].Name;

        index++;
    }

    private void LateUpdate() {

        if (GameManager.GM.controls.Player.A.triggered && writing) {

           stopWriting();

        }
        
        
    }


    void stopWriting() {

        if (LineWriting != null) {
            
            
            StopCoroutine(LineWriting);
        }

        LineWriting = null;

        text.maxVisibleCharacters = int.MaxValue;
        
        OnTextEnd?.Invoke();

        writing = false;
        
    }

    IEnumerator writeLine(string s) {

        OnTextBegin?.Invoke();

        Box.SetActive(true);
        
        writing = true;

       // int totalVisibleCharacters = text.textInfo.characterCount;
        int counter = 0;

        while (counter <= s.Length) {

           // int visibleCount = counter % (totalVisibleCharacters + 1);

           



           text.text = s;
            text.maxVisibleCharacters = counter;
   
            
            OnCharacterShow?.Invoke();
            

                yield return new WaitForSeconds(1/ CharactersPerSecond);

                counter++;

      

        }

        OnTextEnd?.Invoke();
        
        writing = false;
        
     
    }

}
