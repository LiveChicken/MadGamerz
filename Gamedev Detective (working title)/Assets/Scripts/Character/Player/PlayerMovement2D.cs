using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour {

     [SerializeField]
    private float MovementSpeed;

    private Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.GM.CanMove2D) {

            Move();
            
        }

    }


    void Move() {

        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (inputVector.magnitude > 1f) {

            inputVector.Normalize();
            
            
        }


        Vector2 movementVector = inputVector * MovementSpeed;

        //Vector2 newPosition = (Vector2) transform.position + (movementVector * Time.deltaTime);
        
        //rb.MovePosition(newPosition);
        rb.velocity = movementVector;


    }

}
