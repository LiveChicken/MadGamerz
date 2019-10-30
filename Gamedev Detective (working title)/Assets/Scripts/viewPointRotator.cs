using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class viewPointRotator : MonoBehaviour
{
    public float MaxSpeed;

    private float currentSpeedX;
     private float currentSpeedY;

    private float thetaX, thetaY;

 public GameObject visCam;
 
    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

     if (visCam.activeSelf) {

      Vector2 input = GameManager.GM.controls.Player.Move.ReadValue<Vector2>();

      currentSpeedX = Mathf.Lerp(currentSpeedX, -input.x * MaxSpeed, 0.95f * Time.deltaTime);

      currentSpeedX = Mathf.Clamp(currentSpeedX, -MaxSpeed, MaxSpeed);

      thetaX += currentSpeedX * Time.deltaTime;

      currentSpeedY = Mathf.Lerp(currentSpeedY, -input.y* MaxSpeed, 0.95f * Time.deltaTime);

      currentSpeedY = Mathf.Clamp(currentSpeedY, -MaxSpeed, MaxSpeed);

      thetaY += currentSpeedY * Time.deltaTime;

      // Debug.Log(Hoz + " | " + currentSpeed + " | " + theta);


      transform.rotation = Quaternion.Euler(thetaX, thetaY, 0); //Quaternion.AngleAxis(thetaX, Vector3.up);

     }
    }
}
