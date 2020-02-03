using System.Collections;
using System.Collections.Generic;
using TFG_SP;
using UnityEngine;

public class KnockbackOnCollide : MonoBehaviour {


    public float Force;

    public LayerMask KnockbackMask;

    public bool UseCollisionPoint;

     public bool UseTrigger;


     private void OnCollisionEnter2D(Collision2D other) {
          
          if (Checks.CompareLayers(KnockbackMask, other.gameObject)){

               if (other.gameObject.GetComponent<Rigidbody2D>()) {

                    Vector2 pos = transform.position;

                    if (UseCollisionPoint) {

                         pos = other.contacts[0].point;

                    }

                    Knockback.KnockBack(other.rigidbody, pos, Force);
                    
               }

          }

     }


     private void OnTriggerEnter2D(Collider2D other) {

          if (UseTrigger) {

               if (Checks.CompareLayers(KnockbackMask, other.gameObject)) {

                    if (other.gameObject.GetComponent<Rigidbody2D>()) {

                         Vector2 pos = transform.position;



                         Knockback.KnockBack(other.gameObject.GetComponent<Rigidbody2D>(), pos, Force);

                    }

               }

          }
     }


}
