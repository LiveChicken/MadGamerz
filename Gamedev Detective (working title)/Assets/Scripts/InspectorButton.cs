using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class InspectorButton : MonoBehaviour {

     public bool Trigger;
     
     public UnityEvent OnTrigger;

     private void Update() {

          if (Trigger) {

               OnTrigger.Invoke();
               Trigger = false;

          }
     }


}

 