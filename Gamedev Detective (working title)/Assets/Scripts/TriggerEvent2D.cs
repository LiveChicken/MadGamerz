using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEngine;
using UnityEngine.Events;


public class TriggerEvent2D : MonoBehaviour {

     public bool OneShot;
     private bool triggered;

     public LayerMask LayerMask;
     
     
 public UnityEvent OnTriggerEnterEvent;

     private void OnTriggerEnter2D(Collider2D other) {

          if (!OneShot || !triggered) {

               if (Checks.CompareLayers(LayerMask, other.gameObject)) {

                    OnTriggerEnterEvent?.Invoke();

                    if (OneShot) {

                         triggered = true;


                    }

               }



          }


     }

}
