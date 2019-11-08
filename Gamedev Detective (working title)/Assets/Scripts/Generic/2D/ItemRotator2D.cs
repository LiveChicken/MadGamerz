using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRotator2D : MonoBehaviour {

    private PlayerMovement2D PM2D;

    private float theta;
    // Start is called before the first frame update
    void Start() {

        PM2D = GetComponentInParent<PlayerMovement2D>();

    }

    // Update is called once per frame
    void Update() {

            SetDirection();
        
    }
    
    public void SetDirection(){
    switch (PM2D.direction) {
            
            case (PlayerMovement2D.Direction.North):

                theta = 0f;
                
                break;

            case (PlayerMovement2D.Direction.South):

                theta = 180f;
                
                break;

            case (PlayerMovement2D.Direction.East):

                theta = 270f;
                
                break;

            case (PlayerMovement2D.Direction.West):

                theta = 90f;
                
                break;
            
            
        }

        transform.localRotation = Quaternion.Euler(0, 0, theta);


    }
}
