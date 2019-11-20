using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
//using UnityEngine.UIElements;
//using Button = UnityEngine.UI.Button;


public class Keypad : MonoBehaviour {

    public int Code;
    
    public TMP_Text Output;

     public Button FirstSelected;
     
     [Space]
     
    public string SuccessMessage;
    public string FailureMessage;
     
     
     
     [Space]

    public UnityEvent OnSuccess;
    public UnityEvent OnFailure;


    private string current;

     private bool takingInput;

     public void StartKeypad() {

          takingInput = true;

          FirstSelected.Select();

          current = string.Empty;
          Output.text = current;

     }

     public void AddDigit(int d) {

         if (takingInput) {
              current += d.ToString();

              Output.text = current;
         }

    }


    public void CheckCode() {

         if (takingInput) {

              takingInput = false;
              int currentParce;
              int.TryParse(current, out currentParce);

              if (currentParce == Code) {

                   Output.text = SuccessMessage;

                   OnSuccess?.Invoke();

              } else {

                   Output.text = FailureMessage;
                   OnFailure?.Invoke();

                   StartCoroutine(resetPad());
              }

         }


    }

     IEnumerator resetPad() {

          yield return new WaitForSeconds(2f);

          takingInput = true;
     
          current = String.Empty;

          Output.text = current;


     }


}
