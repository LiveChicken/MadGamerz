using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class TimelineManager : MonoBehaviour {
    private PlayableDirector PD;

    private bool paused;
    private bool waiting;

    //public DialogueBox DialogueBox;

    public delegate void EndWaitDelegate();

    public static EndWaitDelegate endWaitDelegate = delegate {

    };


    private void OnEnable() {

         endWaitDelegate += EndWait;

    }

    private void OnDisable() {

         endWaitDelegate -= EndWait;

    }

    private void Start() {

        PD = GetComponent<PlayableDirector>();

    }


    private void ContinueTimeline() {

                if (!waiting){
       
      PD.Play();
      paused = false;
      }

    }

   public void PauseTimeLine() {

         PD.Pause();

         paused = true;

   }

   public void WaitFor() {

        PauseTimeLine();
        waiting = true;
        Debug.Log("Waiting");
        

   }

   private void EndWait() {

        waiting = false;
        ContinueTimeline();


   }


   private void Update() {

        if (paused) {

            

        }


   }


}
