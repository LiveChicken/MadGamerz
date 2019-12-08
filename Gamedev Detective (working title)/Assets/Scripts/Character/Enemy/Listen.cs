using System;
using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEditor;
using UnityEngine;

public class Listen : BaseState {

    [Space] public float ListenRange;

    public LayerMask ListenForMask;

   
    
    public override void OnActivate() {
        
        
        
    }

    public override Type Perform() {
       // throw new NotImplementedException();

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, ListenRange);

        foreach (var H in hits) {

            if (Checks.CompareLayers(ListenForMask, H.gameObject)) {

                myStateMachine.Target = H.transform;
                   //myStateMachine.SwitchToNewState(NextState.GetType());
                return NextState.GetType();

            }
            


        }
        
        
        return null;

    }

    public override void OnDeactivate() {
        //throw new NotImplementedException();
    }

    void OnDrawGizmosSelected() {
        //GameObject[] objs = FindObjectsOfType(typeof(GameObject)) as GameObject[];

        #if UNITY_EDITOR
        
        //foreach (GameObject g in objs) {
            UnityEditor.Handles.color = Color.green;
            UnityEditor.Handles.DrawWireDisc(transform.position, transform.forward, ListenRange);
        //}
        
        #endif
        
    }
   

}




