using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimerEvent : MonoBehaviour {

    public float TimerDurationDefault = 1f;
    
    public UnityEvent OnTimerEnd;

     private bool TimerActive;

     public void StartTimer() {

          StartCoroutine(Timer(TimerDurationDefault));

     }

     public void StartTimer(float duration) {

          StartCoroutine(Timer(duration));

     }

     IEnumerator Timer(float duration) {

          if (TimerActive) {
            yield break;
          }

          TimerActive = true;
          
          yield return  new WaitForSeconds(duration);
          
          OnTimerEnd?.Invoke();

          TimerActive = false;

     }




}
