using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Cinemachine;
using UnityEditor;
using UnityEngine.EventSystems;


[RequireComponent(typeof(CharacterController))]
public class PlayerMovementController_CC : MonoBehaviour {

  //  public static PlayerMovementController_CC PMC;
    

    [SerializeField] private float MovementSpeed = 4f;

    //   [SerializeField] private float MovementForce = 100f;

    private Vector3 moveDirection;

   [SerializeField] private float slopeForce;
    [SerializeField] private float rayLenght; 
    

    [SerializeField] private float RotationSpeed; 

[Header("Jumping")]
    
    [SerializeField] private float JumpVelocity = 5f;

    [SerializeField] private float FallMulitplier = 2.5f;
   // [SerializeField] private float LowJumpMultiplier = 2f;

   // [SerializeField] private bool hasJumped;


   // private CinemachineFreeLook CVC;  

    [HideInInspector]
   public float XVelocity;
   
  //  [SerializeField]
   // private cameraLockOn _clo;
    
   // private Rigidbody rb;

    private CharacterController cc;

 //  private float distanceToFeet;

  //  private bool jumping;

    //[Header("Targeting")]//public List<TargetPoint> Target = new List<TargetPoint>();
 //  public float TargetMaxDistance = 25f;
   // public bool locked;

  //  private TargetingScript2 TS;

    private float verticleForce;


  //  public State state;
    
    [Header("Sliding")]

    public float groundAngle;
    public Vector3 groundNormal;
   // public Vector3 slopeDirection;

    private bool  isGrounded; // is on a slope or not
    public float slideFriction = 0.3f;
    public float slideSpeed;
    
    public enum State { 
    
    normal,
    swinging,
        rolling
        
    }


    private void Awake() {

       // PMC = this;

        cc = GetComponent<CharacterController>();
        
   
    }

    
    

    // Start is called before the first frame update
    void Start()
    {

     //   TS = GetComponent<TargetingScript2>();

     //  
        
    }

    // 
 

    private void Update() {

        XVelocity = 0f;
        
       // switch (state) {
            
            

//case(State.normal):

    if (GameManager.GM.CanMove3D) {
        //  GetSlopeDirection();
        //  CheckSlide();
        Move();
        Jump();
        LookForward();


        moveDirection.y = verticleForce;

        //CheckSlide();
        //* Time.deltaTime;

        cc.Move(moveDirection * Time.deltaTime);

        //  Debug.Log(moveDirection + " | " + cc.velocity);

    }

    SlopeMove();

       // XVelocity =  transform.InverseTransformDirection(cc.velocity).x;
      //  XVelocity /= MovementSpeed;
     //
      //  XVelocity = Mathf.Clamp(XVelocity, -1f, 1f);
    

  //  break;


//case(State.swinging):


  //  break;


//case (State.rolling):

    //SlideEnd();
    
  //  break;



     //   }

    }


    private void Move() {
        

        Vector3 CameraLookDirection = Camera.main.transform.forward; //CVC.transform.forward;

        CameraLookDirection.y = 0;
        
        CameraLookDirection.Normalize();

        Vector3 CameraLookRight = Camera.main.transform.right;// CVC.transform.right;

        CameraLookRight.y = 0;

        CameraLookRight.Normalize(); 
        
        
       // Vector2 movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); //.normalized;

        Vector3 movementInput = (Input.GetAxis("Horizontal")  *CameraLookRight) + (Input.GetAxis("Vertical") * CameraLookDirection);


       

        if (movementInput.magnitude > 1f) {
            
            movementInput.Normalize();
            
        }
        
        
        
       // LookForward(new Vector2(movementInput.x, movementInput.z));

        movementInput *= MovementSpeed;//* Time.fixedDeltaTime;

       // movementInput *= V

       // moveDirection * slopeDirection;
        
       //movementInput = Vector3.Project(movementInput, slopeDirection);
        
       

        moveDirection = movementInput;
        
        //CheckSlide();

       

    }


    void SlopeMove() {
        
            if (OnSlope()){
                                 
                                 Vector3 movement = Vector3.zero;
                if (moveDirection.magnitude > 0) {

                    movement += Vector3.down * (cc.height / 2) * slopeForce;// * Time.deltaTime;

                 }
                                 
                                 

                                 if (groundAngle > cc.slopeLimit && groundAngle < 90) {

                                     //moveDirection *= 0.3f;

                                     //Debug.Log("I should be sliding");
                                     movement.x += (1f - groundNormal.y) * groundNormal.x * (slideSpeed - slideFriction);
                                     movement.z += (1f - groundNormal.y) * groundNormal.z * (slideSpeed - slideFriction);
                                 }


                                 cc.Move(movement * Time.deltaTime);

                             }


    }


    private void Jump() {
        
        

        if (cc.isGrounded) {

           verticleForce = 0f;
            //hasJumped = false;
            
       /* if (Input.GetButtonDown("Jump")) {


           

            verticleForce = JumpVelocity;
            hasJumped = true;
           // return;

            //  jumping = true;

        }*/


        }

        //   if (jumping) {

        if (!cc.isGrounded) {

            

          //  if (verticleForce < 0f) {

                verticleForce +=  Physics.gravity.y * (FallMulitplier -1 ) * Time.deltaTime;

           /* } else if (verticleForce >= 0f && !Input.GetButton("Jump")) {

               verticleForce +=  Physics.gravity.y * (LowJumpMultiplier -1 ) * Time.deltaTime;

            }*/
            
            
            
        }

        verticleForce += Physics.gravity.y * Time.deltaTime;

    }


    private void LookForward() {


        Vector2 HorizontalVelocity = Vector2.zero;

        
      //  if (!TS.IsLocked || TS.Target == null) {

           HorizontalVelocity = new Vector2(cc.velocity.x, cc.velocity.z);

      //  } else {

        //    Vector3 direction = (TS.Target.position - transform.position);
         //   HorizontalVelocity = new Vector2(direction.x, direction.z);

 

       // }

        if (HorizontalVelocity.magnitude > cc.minMoveDistance) {

                HorizontalVelocity.Normalize();

                float theta = Mathf.Atan2(HorizontalVelocity.x, HorizontalVelocity.y) * 180 / Mathf.PI;

                // Debug.Log(theta);

                Quaternion desired = Quaternion.Euler(0f, theta, 0f); // seting only y axis rotation

                Quaternion newRot = Quaternion.Lerp(transform.rotation, desired, RotationSpeed * Time.deltaTime);


                transform.rotation = newRot;



            }
        

      

    }


    bool OnSlope() {

       // if (hasJumped) {
         //   return false;
      //  }

        RaycastHit hit;
         

        if (Physics.Raycast(cc.transform.position - new Vector3(0, (cc.height / 2) - 0.1f, 0), Vector3.down, out hit, rayLenght)) {

           
            if (hit.normal != Vector3.up) {
                groundNormal = hit.normal;
                groundAngle  = Vector3.Angle(Vector3.up, hit.normal);

                 
                 Debug.Log("ground Detected");
//                if (hit.transform.CompareTag("Slide")) {

                  //  BeginRoll();
              //      
               //     return false;

              //  }

                //hit.transform.tag; 
                
                return true;
            }
             
             Debug.Log("B");

        }
         
         
         Debug.Log("C" + hit.collider.gameObject);

        return false;

    }

   void SlideEnd() {

       // if (hasJumped) {
            return; // false;
      //  }

        RaycastHit hit;

        if (Physics.Raycast(cc.transform.position - new Vector3(0, cc.height / 2, 0), Vector3.down, out hit, rayLenght)) {

          //  if (!hit.transform.CompareTag("Slide")) {

               // EndRoll();//();

          //  }

        }

    }


    public void BeginRoll() {


        cc.enabled = false;

      //  state = State.rolling;

        
        //TODO: attach a ball 

    }

    public void EndRoll() {

        cc.enabled = true;

    //    state = State.normal;

    }



    /* void CorrectPosition() {
 
         if (!cc.isGrounded) {
 
             Vector3 bottom = cc.transform.position - new Vector3(0, cc.height / 2, 0);
 
             RaycastHit hit;
 
             if (Physics.Raycast(bottom, Vector3.down, out hit, 1f)) {
 
                 //moveDirection.y += -hit.distance;
                 cc.Move(new Vector3(0, -hit.distance, 0)* Time.deltaTime);
 
                 //Debug.Log("ResettingPos");
 
             }
 
         }
 
 
     }*/

   /* void GetSlopeDirection() {

        if (cc.isGrounded) {

           slopeDirection = Vector3.Cross(groundNormal, Vector3.Cross(groundNormal, Vector3.up));

         

            slopeDirection.Normalize();
            
            
            groundAngle = ((Vector3.Angle(Vector3.up, slopeDirection.normalized)) - 90f);

            if (groundAngle >= 90f) {

                groundAngle = 0f;

            }

            if (groundAngle < 1f) {

                slopeDirection = transform.forward;

            }

        }

    }*/



  /*  private void OnControllerColliderHit(ControllerColliderHit hit) {
        groundNormal = hit.normal;
        
      groundAngle = Vector3.Angle(Vector3.up, hit.normal);
    }*/


}

/*
 
 (0, 0, 1) + (0, 0.9, 0.1) = (0, 0.9, 1.1)
 
 => (0, 0.45, 0.55)
 
 */
