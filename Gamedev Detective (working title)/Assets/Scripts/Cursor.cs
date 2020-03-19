using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class Cursor : MonoBehaviour {

    public float Radius;

    public LayerMask layerMask;

    [Space] public float MovementSpeed;
    

    private Animator anim;

    private bool Over;
    // Start is called before the first frame update
    void Start() {
       
        anim = GetComponent<Animator>();
    }


    private void FixedUpdate() {

        if (Physics2D.OverlapCircle(transform.position, Radius, layerMask)) {


            Over = true;



        }else {

            Over = false;

        }

        anim.SetBool("Over", Over);

    }


    void Move() {

         Vector2 InputVector = GameManager.GM.controls.Player.Move.ReadValue<Vector2>();


         if (InputVector.magnitude > 1) {
         InputVector.Normalize();
         }

        if (InputVector.magnitude > 0.05) {

          transform.position = transform.position + new Vector3(InputVector.x * MovementSpeed, InputVector.y * MovementSpeed, 0);
        }

       // Vector2 input = GameManager.GM.controls.Player.MousePos.ReadValue<Vector2>() ;

       // transform.position = Camera.main.ScreenToWorldPoint(input);


    }

    void Click() {

        Collider2D hit;
        hit = Physics2D.OverlapCircle(transform.position, Radius, layerMask);

        if (hit != null) {

            Debug.Log("I hit: " + hit.gameObject);
            
            hit.GetComponent<Interactable2D>().Click();

        } else {

            Over = false;

        }

        anim.SetTrigger("Click");
        
    }
    

    // Update is called once per frame
    void Update() {
        
        
        
        Move();

        if (GameManager.GM.controls.Player.A.triggered) {

                 Click();
        }


    }


}

#if UNITY_EDITOR
[CustomEditor(typeof(Cursor))]
public class CursorSizeEditor : Editor {



    private void OnSceneGUI() {

        Cursor Selected = (Cursor) target;
        
        //Debug.Log("I'm doing my thing");

        Handles.color = Color.cyan;

        Handles.DrawWireDisc(Selected.transform.position, Vector3.forward, Selected.Radius);
       // Handles.DrawWireArc(Selected.transform.position, Vector3.forward, Vector3.forward, 360, Selected.Radius);

    }




    
}
#endif
