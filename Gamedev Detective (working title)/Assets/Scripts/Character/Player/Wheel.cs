using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Wheel : MonoBehaviour {

    [HideInInspector]
    public List<Transform> GrabPoints = new List<Transform>();

    [Header("Spawn points")] public bool SpawnPointsOnStart = true;
    public int NumberOfPoints;
    public float Radius;

    [HideInInspector]
    public int HighestIndex;

    private float theta;

    private void Start() {

        if (SpawnPointsOnStart) {

            float thetaOffset = 360f / NumberOfPoints;
            
            for (int i = 0; i < NumberOfPoints; i++) {

                Transform temp = new GameObject().transform;
                temp.position = transform.position;
                temp.SetParent(transform);
                temp.localRotation = Quaternion.Euler(0,0, thetaOffset * i);
                temp.position = transform.position + (temp.up * Radius);
                
                GrabPoints.Add(temp);

            }

        }


    }

    public void ThetaChange(float d) {

        theta += d;

    }

    private void Update() {

        
        transform.localRotation = Quaternion.Euler(0,0, theta);

        if (GrabPoints.Count < 0)
            return;
        
            Transform Highest = GrabPoints[0];
        HighestIndex = 0;

            for (int i = 0; i < GrabPoints.Count; i++){

                //TODO: change compariter for different effect
                if (GrabPoints[i].position.y > Highest.position.y) {

                   Highest = GrabPoints[i];
                   HighestIndex = i;

                }

            }
        
        
             
        

    }

    private void OnDrawGizmos() {
        
        

        for (int i = 0; i < GrabPoints.Count; i++) {


            Gizmos.color = Color.cyan;

            if (i == HighestIndex) {

                Gizmos.color = Color.red;
                
            }

            Gizmos.DrawSphere(GrabPoints[i].position, 0.05f);
            
            
        }
        
        
    }


}
