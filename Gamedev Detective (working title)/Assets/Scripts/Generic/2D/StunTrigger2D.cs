using System.Collections;
using System.Collections.Generic;
using TFG_SP;
using UnityEngine;

public class StunTrigger2D : MonoBehaviour
{

     public LayerMask layerMask;

     public float Stunduration = 2f;

     private void OnTriggerEnter2D(Collider2D other) {

          if (Checks.CompareLayers(layerMask, other.gameObject)) {

               if (other.GetComponent<Stunable>()) {

                    other.GetComponent<Stunable>().StunMe(Stunduration);
                    
               }

          }

     }

}
