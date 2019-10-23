using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGadget : Gadget
{
    public override void TakeInputDown() {

        Debug.Log("I'm a TestGadget and I'm a useless member of society");
        
    }

    public override void TakeInputHold() {
        Debug.Log("I'm a TestGadget and I'm a continuous member of society");
    }

    public override void TakeInputUp() {
        Debug.Log("I'm a TestGadget, goodbye");
    }
}
