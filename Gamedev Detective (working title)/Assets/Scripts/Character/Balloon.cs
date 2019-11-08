using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour {

    public float GravityMultiplier;

    private Rigidbody rb;

    void Start() {

        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate() {

        rb.AddForce(Vector3.up * (Physics.gravity.y * GravityMultiplier));

    }
}
