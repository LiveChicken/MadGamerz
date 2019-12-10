using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : BaseState {

     [Space]
    public float Speed;
    public float ThresholdSpeed;   
    
    public float TurningSpeed;

    [Space] public float GiveUpRange;
    

   // private Transform Target;


    private Rigidbody2D rb;
    
    // Start is called before the first frame update
   void Start() {
        rb = GetComponent<Rigidbody2D>();

       myStateMachine = GetComponent<StateMachine>();


   }

   
   

    public override void OnActivate() {

       // Target = myStateMachine.Target;

        // throw new System.NotImplementedException();
    }

    System.Type StopChase() {

        rb.velocity = Vector2.zero;

        return NextState.GetType();
        
    }

    public override System.Type Perform() {
       // throw new System.NotImplementedException();

        if (myStateMachine.Target == null) {

            // findTarget();


            return StopChase();


        }


        if (Vector2.Distance(transform.position, myStateMachine.Target.position) > GiveUpRange) {

            return StopChase();

        }


         Vector2 direction = (Vector2) (myStateMachine.Target.position - transform.position);
         direction.Normalize();
         

        if (rb.velocity.magnitude < ThresholdSpeed) {

            
           // Vector2 DesiredVector = 
            
            rb.velocity = direction * Speed;

            // rb.AddForce(transform.right * Speed * Time.fixedDeltaTime);

        }


        //transform.rotation

        //Vector2 direction = (Vector2) (myStateMachine.Target.position - transform.position);
      //  direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rotateAmount = (float) System.Math.Round(rotateAmount, 4);

        float scaledRotateAmount = (float) (rotateAmount * TurningSpeed);


       // transform.Rotate(0, 0, -scaledRotateAmount);

        return null;

    }

    // public override void Perform() {
      // throw new System.NotImplementedException();
  //  }

    public override void OnDeactivate() {
      //  throw new System.NotImplementedException();
    }
}
