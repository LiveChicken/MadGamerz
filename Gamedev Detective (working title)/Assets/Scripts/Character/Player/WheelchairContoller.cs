using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;


[RequireComponent(typeof(CharacterController))]
public class WheelchairContoller : MonoBehaviour {
     [SerializeField] private float MovementSpeed = 4f;
     [SerializeField] private float RotationSpeed = 4f;

     public static float HandMoveSpeed = 0.3f;
    // public static float LiftHeight    = 0.03f;

     [Header("Wheels")]

[SerializeField]
     private float WheelRotationSpeed;

     public Wheel WheelL, WheelR;
     
     private CharacterController cc;
     private Vector3 moveDirection;
     private Vector3 movementInput;

     


     private void Awake() {

       cc = GetComponent<CharacterController>();

     }


     private void Update() {
          if (GameManager.GM.CanMove3D) {

               Move();
               
               
               cc.Move(moveDirection * Time.deltaTime);

             

          }
     }

     void Move() {

          Vector3 CameraLookDirection = Camera.main.transform.forward; //CVC.transform.forward;

          CameraLookDirection.y = 0;

          CameraLookDirection.Normalize();

          Vector3 CameraLookRight = Camera.main.transform.right; // CVC.transform.right;

          CameraLookRight.y = 0;

          CameraLookRight.Normalize();


          // Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //.normalized;

           movementInput = (Input.GetAxis("Horizontal") * CameraLookRight) + (Input.GetAxis("Vertical") * CameraLookDirection);




          if (movementInput.magnitude > 1f) {

               movementInput.Normalize();

          }


          if (movementInput.magnitude > 0.05f) {


               Vector3 newDir = Vector3.RotateTowards(transform.forward, movementInput, RotationSpeed * Time.deltaTime, 0.0f);

               //Debug.Log(transform.forward - newDir);



               //transform.forward = newDir * movementInput.magnitude;

               float cross = Vector3.Cross(transform.forward, newDir).y;
               
//               Debug.Log(cross);

               if (cross < 0.5f) {

                    moveDirection = transform.forward * MovementSpeed * movementInput.magnitude;

               } else {

                    moveDirection = Vector3.zero;

               }

               transform.forward = newDir * movementInput.magnitude;

               float LSpeed = movementInput.magnitude * WheelRotationSpeed;
               float RSpeed = movementInput.magnitude * WheelRotationSpeed;

               float crossMag = Mathf.Sqrt(cross * cross);
               
               if (cross > 0.05) {
                    LSpeed *= 2 - crossMag;
                    RSpeed *= 0.2f + crossMag;
               }

               if (cross < -0.05) {
                    RSpeed *= 2 - crossMag;
                    LSpeed *= 0.2f + crossMag;
               }
               
               WheelL.ThetaChange(-LSpeed);
               WheelR.ThetaChange(-RSpeed);
               


          } else {

               moveDirection = Vector3.zero;

          }

          


          // moveDirection = Vector3.Lerp(transform.forward, movementInput, RotationSpeed * Time.deltaTime);

          //moveDirection = ((transform.forward * movementInput) / 2);



          //TODO: Get desired direction, lerp rotation?

          moveDirection.y += Physics.gravity.y * 2;


     }

   

     private void OnDrawGizmos() {
          
          Gizmos.color = Color.magenta;
          Gizmos.DrawSphere(transform.position + movementInput, 0.3f);
          
     }


}


