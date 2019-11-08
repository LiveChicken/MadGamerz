using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestoyOnParticleFinish : MonoBehaviour {

    private ParticleSystem myParticleSystem;
    // Start is called before the first frame update
    void Start() {
        myParticleSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (myParticleSystem.isStopped) {

            Destroy(gameObject);
            
        }

    }
}
