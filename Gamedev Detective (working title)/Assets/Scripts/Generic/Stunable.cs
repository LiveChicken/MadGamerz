using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;
using UnityEngine.Events;


public class Stunable : MonoBehaviour {

     public UnityEvent OnStunBegun;

     public UnityEvent OnStunEnd;


     public bool stunned; 
     
     public void StunMe(float duration) {

          if (!stunned) {

               StartCoroutine(StunCountdown(duration));

          }


     }

     IEnumerator StunCountdown(float t) {

          OnStunBegun?.Invoke();
          
          stunned = true;
          
          yield return new WaitForSeconds(t);

          stunned = false;

          OnStunEnd?.Invoke();
          
     }

}
