using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupKey : MonoBehaviour {

    public Key toPickup;
    
    public void Pickup() {

        if (!GameManager.GM.Keychain.Contains(toPickup)) {

            GameManager.GM.Keychain.Add(toPickup);
            
        }

    }
}
