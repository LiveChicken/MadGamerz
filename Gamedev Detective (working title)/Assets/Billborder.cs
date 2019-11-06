using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billborder : MonoBehaviour
{
    

    // Update is called once per frame
    void LateUpdate() {

        transform.rotation = Camera.main.transform.rotation;

         //transform.LookAt(Camera.main.transform.position, Vector3.up);
         
         
    }
}
