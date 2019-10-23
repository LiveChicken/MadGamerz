using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowGadget : Gadget
{

     public override void TakeInputDown() {

          
          Debug.Log("I'm a bow and I have shot my load");
          
     }

     public override void TakeInputHold() {
          throw new System.NotImplementedException();
     }

     public override void TakeInputUp() {
          throw new System.NotImplementedException();
     }


}
