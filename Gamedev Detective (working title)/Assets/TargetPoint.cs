using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;


public class TargetPoint : MonoBehaviour {
    //public float Distance;

//    TargetingScript ts;
   // public Type type;


    public enum Type {

       Interactable,
        PointOfInterest
        
        
    }


    void Start() {
       // ts = FindObjectOfType<TargetingScript>();

        if (!GetComponent<Renderer>()) {

            gameObject.AddComponent<SpriteRenderer>();

        }

    }


    //private void Update() {

       // Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
      //  bool    onScreen    = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;


       // if (onScreen) {

            
            
       // }


   // }

  /*  private void OnBecameVisible() {
        

        if (type == Type.HookPoint) {

            Debug.Log("Seeeee meeeee");
            
            if (PlayerAblilities.PA.Theather) {

                
                Debug.Log("Made it");
                if (!ts.screenTargets.Contains(this))
                    ts.screenTargets.Add(this);
                
            }

        } else 

        if (!ts.screenTargets.Contains(this))
            ts.screenTargets.Add(this);
    }

    private void OnBecameInvisible() {
        if (ts.screenTargets.Contains(this))
           ts.screenTargets.Remove(this);
    }

    private void OnDisable() {

        if (ts.screenTargets.Contains(this))
            ts.screenTargets.Remove(this);
        
    } */


}
