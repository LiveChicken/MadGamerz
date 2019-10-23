using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldGadget : Gadget {
    public GameObject Shield;

    public override void TakeInputDown() {
        Shield.SetActive(true);
    }

    public override void TakeInputHold() {
    }

    public override void TakeInputUp() {
        
        
        Shield.SetActive(false);
        
    }
}
