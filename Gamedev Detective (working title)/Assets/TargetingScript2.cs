using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TargetingScript2 : MonoBehaviour {

     [Header("Accuisition")] 
     public float ViewRadius;
     [Range(0, 360)]
     public float ViewAngle;
     public LayerMask TargetMask;
     public LayerMask ObstacleMask;
     public List<TargetPoint> VisibleTargetPoints = new List<TargetPoint>();
     public int ChecksPerSecond;

     [Header("Selection")] 
     public static Transform Target;
   //  public bool IsLocked;

    [Header("Default")]
     public Vector3 DefaultTargetOffset;
   private Transform defaultTarget;

     [Header("UI")] public GameObject TargetRet;
    // public Image LockOnRet;
     public Vector2 UIOffset;

     private void Start() {

          StartCoroutine(CheckTargets());
          defaultTarget = new GameObject().transform;

     }

     private void Update() {

          defaultTarget.position = transform.TransformPoint(Vector3.forward + DefaultTargetOffset);

         // if (Target != null) {

               //if (!IsLocked) {

                    if (VisibleTargetPoints.Count > 0) {

                         Target = VisibleTargetPoints[TargetIndex()].transform;

                    } else {

                         Target = defaultTarget;

                    }

              // } else {

                   // if (Target == null || Vector3.Distance(transform.position, Target.position) > ViewRadius) {

                      //   Target = defaultTarget; //null;

                         //LockInterface(false);
                       //  IsLocked = false;
                         //return;
                   //      
                 //  }

              // }


              // if (Input.GetButtonDown("Fire2")) {
                    //LockInterface(true);
                   // IsLocked = true;
           //    }

            //   if (Input.GetButtonUp("Fire2")) {
                  //  LockInterface(false);
                  //  IsLocked = false;
              // }
               
               
               
          //} else {

            //   Target = defaultTarget;
               
        // }
          
          UpdateUI();

     }


     void TryInteract() {
          try {
               Target.GetComponent<Interactable>().Interact();
          } catch {

               Debug.Log("Not able to Interact with: " + Target.gameObject);
               
          }

     }

     IEnumerator CheckTargets() {

          while (true) {

               VisibleTargetPoints.Clear();
               FindVisibleTargets();

               
               
               yield return new WaitForSeconds(1f / ChecksPerSecond);
               
          }


     }

     void UpdateUI() {

          if (GameManager.GM.CanMove && Target != null && Target != defaultTarget){


               if (Target.GetComponent<Inspectable>() || Target.GetComponent<Interactable>()) {
                    TargetRet.SetActive(true);


                    TargetRet.transform.position = Camera.main.WorldToScreenPoint(Target.position + (Vector3) UIOffset);

                    if (GameManager.GM.TS == Mode.S3D && GameManager.GM.controls.Player.A.triggered) {

                         TryInteract();
                         
                    }

               } else {
                    TargetRet.SetActive(false); 
               }


               // if (IsLocked) {

                  //  LockOnRet.enabled = true;

            //   } else {

                 //   LockOnRet.enabled = false;

              // }


          } else {

               TargetRet.SetActive(false); 

          }

     }



     private void FindVisibleTargets() {

          Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, ViewRadius, TargetMask);

          for (int i = 0; i < targetsInViewRadius.Length; i++) {

               Transform target = targetsInViewRadius[i].transform;
               Vector3 dirToTarget = (target.position - transform.position).normalized;

               try {
                    if (Vector3.Angle(transform.forward, dirToTarget) < ViewAngle / 2) {

                         if (target.gameObject.GetComponent<Renderer>().isVisible) {

                              float distToTarget = Vector3.Distance(transform.position, target.position);

                              if (!Physics.Raycast(transform.position, dirToTarget, distToTarget, ObstacleMask)) {

                                   if (target.GetComponent<TargetPoint>()) {

                                        VisibleTargetPoints.Add(target.GetComponent<TargetPoint>());

                                   }

                              }
                         }


                    }
               } catch {

                    Debug.Log("Something went wrong Identifying: " + targetsInViewRadius[i].gameObject);
                    
               }

          }


     }


      int TargetIndex() {


          if (VisibleTargetPoints.Count < 1) {

               return -1;

          }

          float[] distances = new float[VisibleTargetPoints.Count];

          for (int i = 0; i < VisibleTargetPoints.Count; i++) {
               distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(VisibleTargetPoints[i].transform.position), new Vector2(Screen.width / 2, Screen.height / 2));
          }

          float minDistance = Mathf.Min(distances);
          int   index       = 0;



          for (int i = 0; i < distances.Length; i++) {
               if (minDistance == distances[i])
                    index = i;
          }

          return index;

     }



     public Vector3 DirFromAngle(float angleInDegrees, bool globalAngle = false) {


          if (!globalAngle) {

               angleInDegrees += transform.eulerAngles.y;

          }

          return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));

     }

     private void OnDrawGizmos() {

          if (Application.isPlaying) {

               if (Target != null) {
                    Gizmos.color = Color.red;
                    Gizmos.DrawWireSphere(Target.position, 0.3f);

                    Gizmos.DrawLine(transform.position, Target.position);

                    Gizmos.color = Color.magenta;
               }

               // Gizmos.DrawWireSphere(defaultTarget.position, 0.2f);
          }


     }

}
