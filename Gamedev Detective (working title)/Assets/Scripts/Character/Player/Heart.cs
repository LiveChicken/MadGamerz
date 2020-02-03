using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{


    
    public void GivePlayerHealth() {

        try {
            GameObject player = FindObjectOfType<PlayerMovement2D>().gameObject;

            Debug.Log(player);
               
               player.GetComponent<Health>().ChangeHealth(1);
        } catch {

            Debug.Log("Could not give player health for some reason");
            
        }
    }

}
