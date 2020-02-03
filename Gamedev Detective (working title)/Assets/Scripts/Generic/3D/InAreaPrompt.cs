using System.Collections;
using System.Collections.Generic;
using TFG_SP;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


[RequireComponent(typeof(Collider))]
public class InAreaPrompt : MonoBehaviour {

     [Tooltip("The name of the button in the inputManager")]
     public string ButtonName = "Give me a name";
     
     [Tooltip("Is this only able to be activated once")]
    public bool OneShot;
     private bool locked;


     public Mode mode;


   //  public Controls.IPlayerActions Actions; 

     //public InputActionMap Action; 
     
    public LayerMask TriggerLayer;
    
    public UnityEvent OnInteract;


     private void OnTriggerStay(Collider other) {
          if (!locked) {
               if (GameManager.GM.TS == mode) {


                    if (Checks.CompareLayers(TriggerLayer, other.gameObject)) {

                         if (GameManager.GM.controls.Player.A.triggered) {

                              OnInteract?.Invoke();

                              if (OneShot) {

                                   locked = true;

                              }

                         } else {

                              Debug.Log("you're ready to go but no input my dood");

                         }

                    }

               }

          }

     }

}
