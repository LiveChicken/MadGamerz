using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gadget : MonoBehaviour {

     public bool CanUse;

     public Mode mode = Mode.S2D;

     public abstract void TakeInput();


}
