using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndWait : MonoBehaviour
{

     public void TriggerWaitEnd() {

          TimelineManager.endWaitDelegate?.Invoke();
          
     }

}
