using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimerEvent : MonoBehaviour {

    public float TimerDurationDefault = 1f;
    public bool BeginOnEnable;
    
    public UnityEvent OnTimerEnd;

     private bool TimerActive;


     private void OnEnable() {

          if (BeginOnEnable) {

               StartTimer();
               
          }

     }

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

          Debug.Log("Timer Active");
          
          yield return  new WaitForSeconds(duration);

          Debug.Log("Timer Ended");
          
          OnTimerEnd?.Invoke();
          

          TimerActive = false;

     }




}
