using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnCollisionSpawner : MonoBehaviour {

    public GameObject ToSpawn;
    
    private void OnCollisionEnter(Collision other) {

       GameObject temp = Instantiate(ToSpawn);
         temp.transform.position = transform.position;

    }
}
