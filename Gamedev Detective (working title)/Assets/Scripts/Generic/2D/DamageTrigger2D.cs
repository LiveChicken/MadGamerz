using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEngine;

public class DamageTrigger2D : MonoBehaviour {

     [Tooltip("Oneshot or per Second")]
     public int Damage;
     
       [Space]
     public bool DamageOverTime;

     public bool UseCollision;
     
     public LayerMask Mask;


     private void OnTriggerEnter2D(Collider2D other) {

          if (!DamageOverTime) {

               
               DamageOther(other, Damage);
          }

     }

     private void OnCollisionEnter2D(Collision2D other) {

          if (UseCollision) {

               
               DamageOther(other.collider, Damage);
               
          }

     }


     private void OnTriggerStay2D(Collider2D other) {

          if (DamageOverTime) {

              DamageOther(other, (int) (Damage / Time.fixedDeltaTime));

          }

     }

     void DamageOther (Collider2D other, int damage) {

          if (Checks.CompareLayers(Mask, other.gameObject)) {

               if (other.gameObject.GetComponent<Health>()) {

                    other.gameObject.GetComponent<Health>().ChangeHealth(-damage);
                    
                    Debug.Log(other.gameObject + " Took damage");
                    
               }

          }
          
     }


}
