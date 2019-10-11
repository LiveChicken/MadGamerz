using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement2D : MonoBehaviour {

     [SerializeField]
    private float MovementSpeed;

    [Space] [SerializeField] private float dashSpeed;
    [SerializeField] private float dashduration;

    private Rigidbody2D rb;

    [Header("States")]
    public State state;

    [Space] public Direction direction;
    public enum State {

        walking,
        dashing
        
    }

    public enum Direction {
        North,   
        South ,    
        East ,    
        West      
        
    }

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.GM.CanMove2D) {

            if (state == State.walking) {

                Walk();
                BeginDash();
                
            }else if (state == State.dashing) {

                Dash();
                
            }

            direction = SetDirection();

        }

    }


    Vector2 readInput() {
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (inputVector.magnitude > 1f) {

            inputVector.Normalize();


        } else {

            inputVector *= 0.8f; 

        }

        return inputVector;

    }


    Direction SetDirection() {

        Vector2 Input = readInput();

        if (Input.magnitude > 0.1f) {

            if (Mathf.Abs(Input.x) > Mathf.Abs(Input.y)) {

                if (Input.x > 0) {

                    return Direction.East;

                } else {

                    return Direction.West;

                }

            } else {

                if (Input.y > 0) {

                    return Direction.North;

                } else {

                    return Direction.South;

                }

            }
        }

        return direction;

    }

    void Walk() {

        


        Vector2 movementVector = readInput() * MovementSpeed;

        //Vector2 newPosition = (Vector2) transform.position + (movementVector * Time.deltaTime);
        
        //rb.MovePosition(newPosition);
        rb.velocity = movementVector;


    }

    void Dash() {

        Vector2 movementVecotor = readInput() * dashSpeed;

        rb.velocity = movementVecotor;

    }

    void BeginDash() {

        if (Input.GetButtonDown("Jump")) {

            StartCoroutine(DashTimer());

        }

    }

    IEnumerator DashTimer() {

        state = State.dashing;
        
        yield return new WaitForSeconds(dashduration);

        state = State.walking;

    }



}
