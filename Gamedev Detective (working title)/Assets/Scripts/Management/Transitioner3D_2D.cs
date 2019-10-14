using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transitioner3D_2D : MonoBehaviour {
  /*
     public GameObject ScreenCamera;
     
     //public List<Level2D> Levels = new List<Level2D>();

     public Level2D ToLoad;


     public void Launch2DGame() {

          if (GameManager.GM.TS == TransitionState.S2D) {

          } else {
            return;
          }

          //Unload previous 2D
          
          //Load new 2D

          if (SceneManager.sceneCount > 1) {

               SceneManager.UnloadScene(SceneManager.GetSceneAt(1));

          }


         // Level2D ToLoad = Levels.Find(Level2D => Level2D.Letter == GameManager.GM.CurrentLevel2D);

          if (ToLoad == null) {

//               Debug.Log("No Cartridege of the letter " + GameManager.GM.CurrentLevel2D);
               
               return;
               
               
               
          }

          SceneManager.LoadScene(ToLoad.Scene2DIndex, LoadSceneMode.Additive);


     }

     public void Transition() {

          StartCoroutine(Trans());

     }

     public IEnumerator Trans(){
     
     if (GameManager.GM.TS == TransitionState.S3D) {

               GameManager.GM.TS = TransitionState.Between;
               
               ScreenCamera.SetActive(true);

          yield return null;
          
          float time; //= 0.5f; 
          time = GameManager.GM.Brain.ActiveBlend.Duration;

          yield return new WaitForSeconds(time);

          GameManager.GM.TS = TransitionState.S2D;

          }

         else if (GameManager.GM.TS == TransitionState.S2D) {

               GameManager.GM.TS = TransitionState.Between;

               ScreenCamera.SetActive(false);

               yield return null;
               
               float time;// = 0.5f;
               time = GameManager.GM.Brain.ActiveBlend.Duration;
               
               yield return new WaitForSeconds(time);

               GameManager.GM.TS = TransitionState.S3D;

          }


     }*/

}

