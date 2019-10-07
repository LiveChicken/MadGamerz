using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabPoint : MonoBehaviour {

    public Wheel wheel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

        transform.position = wheel.GrabPoints[wheel.HighestIndex].position;
        transform.rotation = wheel.GrabPoints[wheel.HighestIndex].rotation;


    }


    private void OnDrawGizmos() {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.2f);
        
    }
}
