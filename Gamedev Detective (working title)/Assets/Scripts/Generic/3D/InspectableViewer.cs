using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;


public class InspectableViewer : MonoBehaviour {

    private Inspectable current;
    private Transform nogo;

    public Transform ViewPoint;

    public GameObject InspectableCamera;

    private bool Inspecting;
    
  //  [Header("Detection")]

  //  public LayerMask layerMask;

 //   public float Range;
    
    

    public void ToggleInspection() {

        if (current != null) {

            if (!Inspecting) {


                //Begin Inspection
                Inspecting = true;

                // ViewPoint.rotation = current.transform.rotation;

                if (current.CVCamera == null) {
                    current.transform.SetParent(ViewPoint);
                    current.transform.DOMove(ViewPoint.position, 1f);
                    current.transform.DORotate(ViewPoint.rotation.eulerAngles, 1f);
                    

                    InspectableCamera.SetActive(true);
                }

                GameManager.GM.CanMove = false;
                current.OnInspect?.Invoke();

            } else {

                //End Inspection
                //current.transform.SetParent(current.);
                current.ReturnToOrigin();
                InspectableCamera.SetActive(false);
                GameManager.GM.CanMove = true;
                Inspecting = false;

            }
        }


    }

    private void Update() {

        if (GameManager.GM.TS == Mode.S3D) {

            try {

                if (TargetingScript2.Target != nogo) {
                    current = TargetingScript2.Target.GetComponent<Inspectable>();
                }
            } catch {

                nogo = TargetingScript2.Target;

            }

            if (!Inspecting && current != null) {

              //  AnalyseForward();
                
                

                if (GameManager.GM.controls.Player.A.triggered) {

                    ToggleInspection();

                }

            } else {

                if (GameManager.GM.controls.Player.B.triggered) {

                    ToggleInspection();

                }

            }
        }

    }

   /* private Ray myRay;

    private void AnalyseForward() {

        //TODO: Launch Ray, check hit for compoent, add to Current if true.

//        Debug.Log("I'm being done hard!");
        
        myRay = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(myRay, out hit, Range, layerMask)) {


            current = hit.collider.gameObject.GetComponent<Inspectable>() ? hit.collider.gameObject.GetComponent<Inspectable>() : null;

        } 


        //TODO: Launch Only if camera moves? or after 1 second. Only check component if hit != current.

    }


    private void OnDrawGizmos() {
        
      //  Gizmos.color = Color.magenta;
       // Gizmos.DrawLine(Camera.main.transform.position, Camera.main.transform.position + (Camera.main.transform.forward * Range));
     //   Gizmos.DrawLine(myRay.origin, myRay.origin + (myRay.direction * Range));
        
    }*/

}
