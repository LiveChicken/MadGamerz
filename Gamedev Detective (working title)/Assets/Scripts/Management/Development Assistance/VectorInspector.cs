using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorInspector : MonoBehaviour {

    public Vector3 Forward;
    public Vector3 Right;

     [Header("Camera")] public Vector3 CamForward;
     public Vector3 CamRight;

    // Update is called once per frame
    void Update() {

         Forward = transform.forward;
         Right = transform.right;

         CamForward = Camera.main.transform.forward;
         CamRight = Camera.main.transform.right;

    }
}
