using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour {

     public UnityEvent OnInteract;

     public void Interact() {
          try {

               if (GameManager.GM.TS == Mode.S3D) {

                    //Debug.Log("Made it this far");

                    OnInteract.Invoke();
               }

          } catch {

               Debug.Log("Could not Interact @: " + gameObject);
               
          }


     }
}
