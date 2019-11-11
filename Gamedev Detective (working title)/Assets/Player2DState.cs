using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2DState : MonoBehaviour {

    public static Player2DState P2S;

    public  PlayerState2D state;
    
    public bool OnDirt;

    private Animator anim;
    
    
    // Start is called before the first frame update
    void Awake() {
        P2S = this;
    }

    private void Start() {

        anim = GetComponent<Animator>();
    }


    public void toggleDig(bool under) {

        if (under) {

            if (OnDirt) {


                state = PlayerState2D.Digging;
                anim.SetBool("Underground", true);
                
            }

        } else {

            state = PlayerState2D.Normal;
            anim.SetBool("Underground", false);
            
        }


    }



    public enum PlayerState2D {

        Normal,
        Digging
        
    }

}
