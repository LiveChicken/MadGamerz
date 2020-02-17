using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitMemory : MonoBehaviour {

     public string MemoryName;

     public void Enter() {

          Debug.Log("attempting to enter memory");
          MemoryManager.beginMemoryDelegate.Invoke(MemoryName);
          
     }

     public void Exit() {

          Debug.Log("attempting to exit memory");
          MemoryManager.endMemoryDelegate.Invoke();
          
     }

}
