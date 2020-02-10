﻿
           using UnityEngine;
           using UnityEngine.Rendering.Universal;


           public class PSBoundariesOrthographic : MonoBehaviour {
               public Camera MainCamera;
               private Vector2 screenBounds;
               private float objectWidth;
               private float objectHeight;
           
               // Use this for initialization
               void Start () {
                   screenBounds = MainCamera.transform.position + MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
                   
                   //MainCamera.GetComponent<UniversalAdditionalCameraData>().

                   var vertExtent = MainCamera.orthographicSize;
                   var horzExtent = vertExtent * Screen.width / Screen.height;
                   //screenBounds = new Vector2(horzExtent,vertExtent);
                   
                   
                   objectWidth = transform.GetComponentInChildren<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
                   objectHeight = transform.GetComponentInChildren<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
                   
                   Debug.Log(screenBounds + " | " + objectHeight + " " +objectWidth);
                   Debug.Log("min: " + (screenBounds.x * -1) + objectWidth + " Max: " + (screenBounds.x - objectWidth));
                   Debug.Log("min: " + (screenBounds.y * -1) + objectWidth + " Max: " + (screenBounds.y - objectWidth));
                   
                   
               }
           
               // Update is called once per frame
               void LateUpdate(){
                   Vector3 viewPos = transform.position;
                   viewPos.x = Mathf.Clamp(viewPos.x, (screenBounds.x * -1) + objectWidth, screenBounds.x - objectWidth);
                   viewPos.y = Mathf.Clamp(viewPos.y, (screenBounds.y * -1) + objectHeight, screenBounds.y  - objectHeight);
                   transform.position = viewPos;
                   
                   //Debug.Log(viewPos);
               }
           }
