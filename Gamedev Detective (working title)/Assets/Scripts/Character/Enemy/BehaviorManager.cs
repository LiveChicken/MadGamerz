using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BehaviorManager : MonoBehaviour
{
    
    public List<Behavior> Behaviors = new List<Behavior>();

     private void OnEnable() {

          
          Behaviors.Clear();
          
          Behavior[] B = GetComponents<Behavior>();

          
          foreach (var Bh in B) {
               
               Behaviors.Add(Bh);
               
          }

         Behaviors =  Behaviors.OrderBy(i => i.Importance).ToList();

         // Behaviors[0].OnActivate();

          Behaviors[0].enabled = true;
          if (Behaviors.Count > 1) {
               for (int i = 1; i < Behaviors.Count; i++) {
                    Behaviors[i].enabled = false;
               }
          }


     }


     




}
