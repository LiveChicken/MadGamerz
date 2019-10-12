using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetManager : MonoBehaviour {

    public Gadget gadget; 
    

    // Update is called once per frame
    void Update()
    {
         if (gadget != null) {

              if (Input.GetButtonDown("Fire2")) {

                              gadget.TakeInput();

              }
         }

    }
}
