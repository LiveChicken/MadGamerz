using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ShovelGadget : Gadget {


    //private bool underground;

    private terrainManager tm;

     public UnityEvent OnFailedToDig;
     
     private void OnEnable() {

          tm = transform.GetComponentInParent<terrainManager>();


     }

     // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



     void AttemptDig() {


          if (tm.isOnDirt) {

               
               
               
               
          } else {

               
               OnFailedToDig?.Invoke();
          }

     }


     public override void TakeInputDown() {
      
          
          AttemptDig();
          
    }

    public override void TakeInputHold() {
        
    }

    public override void TakeInputUp() {
        
    }
     
     
     
}
