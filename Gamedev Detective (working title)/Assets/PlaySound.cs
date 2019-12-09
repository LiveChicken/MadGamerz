using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{

    FMOD.Studio.EventInstance Music2D;
    bool playerEnter;
    // Start is called before the first frame update
    void Start()
    {
        Music2D = FMODUnity.RuntimeManager.CreateInstance("event:/Marlon's 2D Music");
    }

    // Update is called once per frame
    void Update()
    {
        FMODUnity.RuntimeManager.AttachInstanceToGameObject(Music2D, GetComponent<Transform>(), GetComponent<Rigidbody>());

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //FMODUnity.RuntimeManager.PlayOneShot("event:/RainA", GetComponent<Transform>().position);
            FMODUnity.RuntimeManager.PlayOneShotAttached("event:/RainA", this.gameObject);
        }

        if (playerEnter && Input.GetKeyDown(KeyCode.Space))
        {
                Debug.Log("Play SOund!");
                Music2D.start();
                //FMODUnity.RuntimeManager.PlayOneShot("event:/RainA", GetComponent<Transform>().position);
                FMODUnity.RuntimeManager.PlayOneShotAttached("event:/RainA", this.gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Music2D.start();

        if(other.CompareTag("Player"))
        {
            playerEnter = true;
            Debug.Log("Player Is In Me!");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerEnter = false;
            Debug.Log("Player Is Out!");
            Music2D.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
