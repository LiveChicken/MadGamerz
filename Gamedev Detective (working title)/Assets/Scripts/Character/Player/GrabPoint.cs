using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TFG_Common;

public class GrabPoint : MonoBehaviour {

    public Wheel wheel;

    [Tooltip("midpoint of the movement curve")]
    public Transform CurvePosition;
    

    private bool transitioning;

    private Transform currentTransform;

    private Vector3 launchPosition;
    private Vector3 targetPosition;
    //private Vector3 curvePositionOut;

    private Quaternion startRotation;
    
   

   

    // Update is called once per frame
    void Update() {

        if (transitioning)
            return;
        
        if (currentTransform != wheel.GrabPoints[wheel.HighestIndex]) {

           // transitioning = true;
            StartCoroutine(Move());
            currentTransform = wheel.GrabPoints[wheel.HighestIndex];
            return;


        }

            transform.position = wheel.GrabPoints[wheel.HighestIndex].position;
            transform.rotation = wheel.GrabPoints[wheel.HighestIndex].rotation;
        


        currentTransform = wheel.GrabPoints[wheel.HighestIndex];

    }


    IEnumerator Move() {
       // Moving = true;
        transitioning = true;
        float outTime = 0f;


        launchPosition = transform.position;
        targetPosition = wheel.GrabPoints[wheel.HighestIndex].position;
        startRotation = transform.rotation;
       

        while (outTime < (WheelchairContoller.HandMoveSpeed)) {

            float shiftedTime = outTime / WheelchairContoller.HandMoveSpeed;

           

            targetPosition = wheel.GrabPoints[wheel.HighestIndex].position;

            

            transform.position =  Curve.GetQuadraticCurvePoint(shiftedTime, launchPosition, CurvePosition.position, targetPosition);
            
            
            transform.rotation = Quaternion.Slerp(startRotation, wheel.GrabPoints[wheel.HighestIndex].rotation, shiftedTime);
            
            outTime            += Time.deltaTime;
            
            
            
            yield return null;


        }

        transitioning = false;
    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 0.2f);


        if (transitioning) {

            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(CurvePosition.position, 0.3f);

            Gizmos.DrawLine(launchPosition, CurvePosition.position);
            Gizmos.DrawLine(CurvePosition.position, targetPosition);
            
        }

    }
}
