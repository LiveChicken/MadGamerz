using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class WheelchairContoller : MonoBehaviour
{
     [SerializeField] private float MovementSpeed = 4f;
     [SerializeField] private float RotationSpeed = 4f;
     
     [Header("Slopes")] [SerializeField] private float slopeForce;
     [SerializeField]                    private float rayLenght;

     private CharacterController cc;
     private Vector3 moveDirection;


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

          Vector3 movementInput = (Input.GetAxis("Horizontal") * CameraLookRight) + (Input.GetAxis("Vertical") * CameraLookDirection);




          if (movementInput.magnitude > 1f) {

               movementInput.Normalize();

          }
          
          
          

          Vector3 targetVector3 = (movementInput.x * transform.right) + (movementInput.z * transform.forward); //transform.forward * movementInput.magnitude;


          moveDirection.x = -targetVector3.z * MovementSpeed;

          
          
        //TODO: Get desired direction, lerp rotation?
          

     }


}
