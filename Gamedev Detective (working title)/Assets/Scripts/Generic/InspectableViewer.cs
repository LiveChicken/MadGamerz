using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class InspectableViewer : MonoBehaviour {

    public Inspectable current;

    public Transform ViewPoint;

    private bool Inspecting;

    public void ToggleInspection() {

        if (!Inspecting) {
            
            
            //Begin Inspection
            Inspecting = true;
           // ViewPoint.rotation = current.transform.rotation;
            
            current.transform.SetParent(ViewPoint);
            current.transform.DOMove(ViewPoint.position, 1f);
            current.transform.DORotate(ViewPoint.rotation.eulerAngles, 1f);
        } else {

            //End Inspection
            current.transform.SetParent(null);
            current.ReturnToOrigin();
            Inspecting = false;

        }


    }

}
