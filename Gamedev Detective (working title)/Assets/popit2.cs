using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class popit2 : MonoBehaviour {

    public Transform Target;
    public float TrackSpeed;
    
    [Tooltip("min distance from target to move")]
    public float StaticDistance;


    private Vector2 desiredPosition;
    
    void LateUpdate() {

        desiredPosition = Camera.main.WorldToScreenPoint(Target.position);

        if (Vector3.Distance(transform.position, desiredPosition) > StaticDistance) {

            



            transform.position = Vector2.Lerp(transform.position, desiredPosition, TrackSpeed * Time.deltaTime);

        }

    }
}
