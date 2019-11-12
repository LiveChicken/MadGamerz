using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace TFG_Common {



     public class EnableTrigger : MonoBehaviour {

          public UnityEvent OnEnableEvent;

          public UnityEvent OnDisableEvent;

          private void OnEnable() {

               OnEnableEvent?.Invoke();

          }

          private void OnDisable() {
               OnDisableEvent?.Invoke();
          }


     }
}
