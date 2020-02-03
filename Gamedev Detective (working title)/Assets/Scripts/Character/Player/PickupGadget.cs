using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupGadget : MonoBehaviour {

     [Tooltip("Under: Prefabs/Player/Gadgets")]
     public GameObject GadgetPrefab;
    
     public void Pickup() {

          GadgetManager GadMan = FindObjectOfType<GadgetManager>();

          if (GadMan.gadget != null) {

               Destroy(GadMan.gadget.gameObject);
               
          }

          GameObject temp = Instantiate(GadgetPrefab);
          temp.transform.SetParent(GadMan.transform);
          temp.transform.localPosition = Vector3.zero;
          temp.transform.localScale = Vector3.one;
          temp.transform.localRotation = Quaternion.Euler(Vector3.zero);

          GadMan.gadget = temp.GetComponent<Gadget>();


     }


    

}
