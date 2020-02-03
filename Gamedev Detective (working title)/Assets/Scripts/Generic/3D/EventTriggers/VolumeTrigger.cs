using System.Collections;
using System.Collections.Generic;
using TFG_SP;
using UnityEngine;
using UnityEngine.Events;


[RequireComponent(typeof(Collider))]
public class VolumeTrigger : MonoBehaviour {


    public bool OneShotEnter;

    private bool triggered;
    
    public LayerMask LayerMask;
    
    public UnityEvent EventOnTriggerEnter;
    public UnityEvent EventOnTriggerStay;
    public UnityEvent EventOnTriggerExit;

    private Collider trig;

   


    private void OnTriggerEnter(Collider other) {

        if (!triggered) {

            if (Checks.CompareLayers(LayerMask, other.gameObject)) {

                EventOnTriggerEnter?.Invoke();

                if (OneShotEnter) {

                    triggered = true;

                }

            }
        }




    }

    private void OnTriggerStay(Collider other) {

        if (Checks.CompareLayers(LayerMask, other.gameObject)) {

            EventOnTriggerStay?.Invoke();

        }
        
        
    }

    private void OnTriggerExit(Collider other) {

        if (Checks.CompareLayers(LayerMask, other.gameObject)) {

            EventOnTriggerExit?.Invoke();

        }
        
    }

    private void OnDrawGizmos() {
        
        //Gizmos.DrawWireMesh(trig.bounds);
        
    }


}
