using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EventOnEnemiesDead : MonoBehaviour
{
   
     public List<Health> EnemiesToKill = new List<Health>();

     public UnityEvent OnAllEnemiesDead;

     private bool triggered;


     private void Update() {

          if (!triggered) {



               foreach (Health H in EnemiesToKill) {

                    if (!H.hasDied) {
                         return;
                    }

               }

               triggered = true;
               
               OnAllEnemiesDead?.Invoke();


              
               
          }



     }


}
