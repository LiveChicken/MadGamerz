using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics.Eventing.Reader;
using TFG_Common;
using UnityEngine;
using UnityEngine.Events;

public class Explode : MonoBehaviour {
    public float Radius;

    public int Damage;
    
   

    public LayerMask layerMask;

     public LayerMask BlockingMask;

    public UnityEvent OnExplode;


     

     public void ExplodeMe() {
          
          Debug.Log("I Have Exploded");

        OnExplode?.Invoke();
        
        List<Health>damagables= new List<Health>();

        var hitColliders  = Physics2D.OverlapCircleAll(transform.position, Radius, layerMask);

         foreach (Collider2D C in hitColliders) {

              if (C.GetComponent<Health>()) {

                   damagables.Add(C.GetComponent<Health>());

              }

         }

         foreach (Health H in damagables) {

              if (H.CompareTag("Player")) {

                   if (Checks.LineOfSight2D(BlockingMask, gameObject, H.gameObject)) {

                        H.ChangeHealth(-Damage, true);
                        
                   }

              } else {

                   H.ChangeHealth(-Damage, true);
              }

         }




    }

}
