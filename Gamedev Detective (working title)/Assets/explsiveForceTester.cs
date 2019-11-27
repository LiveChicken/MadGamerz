using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explsiveForceTester : MonoBehaviour {

    public float Range;

    public float Force;


    public void Explode() {

         Collider2D[] C2D = Physics2D.OverlapCircleAll(transform.position, Range);

         //rigidbody2D.DO
         
         
    }
}
