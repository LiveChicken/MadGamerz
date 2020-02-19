using System.Collections;
using System.Collections.Generic;
using FMOD;
using TMPro;
using UnityEngine;

public class FloatingTextBox : MonoBehaviour {


     public TMP_Text Text;

     private const float randRadi = 5f;//1080f;

     public void BeginText(string s) {

          Text.text = s;

          transform.position = (Vector2) Random.insideUnitCircle * randRadi; 
          
          Text.gameObject.SetActive(true);//(Screen.height * Camera.main.orthographicSize


     }




}
