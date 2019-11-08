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
    
    

    // Update is called once per frame
    void Update()
    {

         if (Vector3.Distance(transform.position, Target.position) > StaticDistance) {

             var MoveDirection =  transform.position - Target.position ;
              MoveDirection.Normalize();
              MoveDirection *= StaticDistance;

              transform.position = Vector3.Lerp(transform.position, Target.position + MoveDirection, CatchupLerpSpeed * Time.deltaTime);



         }

    }
}
