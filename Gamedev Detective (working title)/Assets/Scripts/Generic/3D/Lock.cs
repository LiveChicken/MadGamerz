using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Lock : MonoBehaviour {

    public Key RequiredKey;

    public UnityEvent OnUnlock;

    public UnityEvent OnFailedUnlock;

    private bool locked = true;

    public void TryLock() {

       

            if (locked && GameManager.GM.Keychain.Contains(RequiredKey)) {

                OnUnlock?.Invoke();
                Debug.Log("Unlocked: " + gameObject + " with: " + RequiredKey.Name);
                locked = false;
            } else {

                OnFailedUnlock?.Invoke();
                
         }


    }


}
