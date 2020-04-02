using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationParameters : MonoBehaviour
{
    private Controls controls = null;

    private void Awake() => controls = new Controls();
    private void OnEnable() => controls.Player.Enable();
    private void OnDisable() => controls.Player.Disable();

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

    }
    
    void Update()
    {
        Move();
    }

    public float Xvalue;

    private void Move()
    {
        var movementInput = controls.Player.Move.ReadValue<Vector2>();

        var movement = new Vector3
        {
            x = movementInput.x,
            z = movementInput.y
        }.normalized;

        Xvalue = movementInput.y;

        if (movement.z > 0)
        {
            anim.SetBool("Moving", true);
        } else
        {
            anim.SetBool("Moving", false);
        }

        if (movement.x > 0)
        {
            anim.SetBool("Right", true);
        } else
        {
            anim.SetBool("Right", false);
        }

        if (movement.x < 0)
        {
            anim.SetBool("Left", true);
        } else
        {
            anim.SetBool("Left", false);
        }
    }
}
