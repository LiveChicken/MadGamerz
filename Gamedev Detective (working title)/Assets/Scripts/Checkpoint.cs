using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public static Checkpoint Active;


    public void SetActiveCheckpoint() {

        Active = this;

    }

    private void OnDrawGizmos() {
        
        #if UNITY_EDITOR
        if (Active == this) {
            UnityEditor.Handles.color = Color.red;
        } else {
          UnityEditor.Handles.color = Color.green;
        }

        UnityEditor.Handles.DrawSolidDisc(transform.position, transform.forward, 0.3f);
        
        #endif
        
    }


}
