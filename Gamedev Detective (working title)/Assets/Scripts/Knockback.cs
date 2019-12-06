using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Knockback  {

    //public bool Self;

   // public float KnockbackForce;
    
    public void KnockbackSelf(Transform other) {


   //     Vector2 dir = other.position - transform.position;
     //   dir.Normalize();
        
     //   KB(GetComponent<Rigidbody2D>(), dir);
        


    }

    

    public static void KnockBack(Rigidbody2D target, Vector2 from, float force) {

        Vector2 direction =  (Vector2) target.transform.position - from;
        
        target.AddForce(direction * force, ForceMode2D.Impulse);
        
    }

}
