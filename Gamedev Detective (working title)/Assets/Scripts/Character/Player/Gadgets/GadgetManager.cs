using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GadgetManager : MonoBehaviour {

    public Gadget gadget;

     public static bool GadgetInUse;
    

    // Update is called once per frame
    void Update()
    {
         if (gadget != null) {

              if (GameManager.GM.controls.Player.B.triggered) {

                              gadget.TakeInputDown();

                   GadgetInUse = true;

              }

              if (GameManager.GM.controls.Player.Bhold.triggered) {

                   gadget.TakeInputHold();
                   
              }

              if (GameManager.GM.controls.Player.Bup.triggered) {

                   gadget.TakeInputUp();

                   GadgetInUse = false;


              }

         }

    }
}
