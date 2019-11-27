using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : Behavior {


    public float Speed;
    public float TurningSpeed;

    public Transform Target;


    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Target == null) {

           // findTarget();

            return;

        }
        
        

        if (rb.velocity.magnitude < Speed) {

            rb.AddForce(transform.right * Speed * Time.fixedDeltaTime);
            
        }
        
        
        //transform.rotation

        Vector2 direction = (Vector2) (Target.position - transform.position);
        direction.Normalize();

        float rotateAmount = Vector3.Cross(direction, transform.right).z;

        rotateAmount = (float) System.Math.Round(rotateAmount, 4);

        float scaledRotateAmount = (float) (rotateAmount * TurningSpeed);


        transform.Rotate(0, 0, -scaledRotateAmount);


    }


   

    public override void OnActivate() {
        throw new System.NotImplementedException();
    }

   // public override void Perform() {
      // throw new System.NotImplementedException();
  //  }

    public override void OnDeactivate() {
        throw new System.NotImplementedException();
    }
}
