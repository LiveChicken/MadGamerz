using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Popit : MonoBehaviour {

     public Transform Target;
     
     [SerializeField]
    private float StaticDistance = 1f;
     [SerializeField]
    private float CatchupLerpSpeed = 1f;

 private Vector3 offestTarget;

    // Update is called once per frame
    void Update() {

      //   Vector3 offset = Target.position - Camera.main.transform.position;

        //  offestTarget = Target.position + offset;
         
         if (Vector3.Distance(transform.position, Target.position) > StaticDistance) {

             var MoveDirection =  transform.position - Target.position;
              MoveDirection.Normalize();
              MoveDirection *= StaticDistance;

              transform.position = Vector3.Lerp(transform.position, Target.position + MoveDirection, CatchupLerpSpeed * Time.deltaTime);



         }

    }


     private void OnDrawGizmos() {
          
          Gizmos.color = Color.blue;
          Gizmos.DrawSphere(Target.position, 0.3f);
          
     }

}
