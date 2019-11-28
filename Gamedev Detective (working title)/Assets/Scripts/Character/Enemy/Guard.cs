using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class Guard : BaseState {



    [Space] public GameObject ToGuard;
    public float MaxRangeFromPost;
    public float DesiredRangeFromPost;

    private Vector2 TargetPosition;
    private StateMachine myMachine;
    
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update() {

        if (myMachine.CurrentState != this) {
            float distanceFromPost = Vector2.Distance(transform.position, ToGuard.transform.position);

            if (distanceFromPost > MaxRangeFromPost) {

                myMachine.SwitchToNewState(this.GetType());

            }
        }


    }

    public override void OnActivate() {
       // throw new NotImplementedException();
        
       
        
    }

    public override Type Perform() {
       // throw new NotImplementedException();
        float distanceFromPost = Vector2.Distance(transform.position, ToGuard.transform.position);

        if (distanceFromPost > MaxRangeFromPost) {

            
            
        } 

        return null;
    }

    public override void OnDeactivate() {
        //throw new NotImplementedException();
    }
}
