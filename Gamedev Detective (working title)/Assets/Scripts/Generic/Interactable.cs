using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Interactable : MonoBehaviour {

     public UnityEvent OnInteract;
     
     public void Interact() {

          if (GameManager.GM.TS == Mode.S3D) {

               OnInteract.Invoke();
          }

     }


}
