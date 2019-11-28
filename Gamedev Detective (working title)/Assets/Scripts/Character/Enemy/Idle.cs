using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : BaseState
{
     
     
     

     public override void OnActivate() {
          //throw new System.NotImplementedException();
     }

     public override System.Type Perform() {

          
          Debug.Log("I'm Idle");
          
          return null;

          //throw new System.NotImplementedException();
     }

     // public override void Perform() {
    //     throw new System.NotImplementedException();
    // }

     public override void OnDeactivate() {
          //throw new System.NotImplementedException();
     }
     
     
}
