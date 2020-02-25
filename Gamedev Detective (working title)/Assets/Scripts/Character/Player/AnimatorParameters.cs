using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorParameters : MonoBehaviour
{
    public bool moving;

    void Start()
    {
        moving = false;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            moving = true;
        }
    }
}
