using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
   
   public void TriggerDialogue(int index) {

     // Debug.Log("Made it this far");
      DialogueBox.writeLineDelegate?.Invoke(index);
      
   }
}
