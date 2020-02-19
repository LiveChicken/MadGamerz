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

          transform.position = (Vector2) transform.position +  (Random.insideUnitCircle * randRadi); 
          
          Text.gameObject.SetActive(true);//(Screen.height * Camera.main.orthographicSize


     }
     
     public void EndText(){
     
     try{
     DialogueSpawner.spawnTextDelegate?.Invoke();
     } catch {
     
     UnityEngine.Debug.Log("Something went wrong here");
     
     }
     
     Destroy(gameObject);
     
     
     }




}
