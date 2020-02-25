using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    public KeyCode Forward = KeyCode.W;
    public KeyCode Lefty = KeyCode.A;
    public KeyCode Righty = KeyCode.D;

    public Animator anim;

    public bool move;
    public bool left;
    public bool right;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKey(Forward))
        {
            move = true;
        } else
        {
            move = false;
        }

        if (Input.GetKey(Lefty))
        {
            left = true;
        } else
        {
            left = false;
        }

        if (Input.GetKey(Righty))
        {
            right = true;
        } else
        {
            right = false;
        }

        anim.SetBool("Moving", move);
        anim.SetBool("Left", left);
        anim.SetBool("Right", right);
    }
}
