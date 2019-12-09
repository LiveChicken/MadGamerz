using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   
   public void TriggerDialogue(int index) {

     // Debug.Log("Made it this far");

        try {
             DialogueBox.writeLineDelegate?.Invoke(index);

        } catch {

             Debug.Log("Could not write line: " + index);
             
        }

   }
}
