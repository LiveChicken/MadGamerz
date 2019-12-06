using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LoadingSceneManager : MonoBehaviour
{

static int sceneLoadIndex = 1;

     public float FakeTime = 3f;
     
     public Slider ProgressBar;
     
    
    void Start() {

        StartCoroutine(LoadScene());

    }

    IEnumerator LoadScene() {

         float countdown = 0;

         while (countdown < FakeTime) {

              
              yield return null;

              countdown += Time.deltaTime;

              ProgressBar.value = (countdown / FakeTime) * 0.2f;

         }

         AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneLoadIndex);

         while (!loadOperation.isDone) {

              ProgressBar.value = 0.2f + (loadOperation.progress / 0.9f ) * 0.8f;
              
              yield return null;
              
              

         }

         AsyncOperation unloadOperation = Resources.UnloadUnusedAssets();

         while (!unloadOperation.isDone) {

            //  ProgressBar.value = 0.8f + ((loadOperation.progress / 1) * 0.2f);
              
              yield return null;

         }

    }


     public static void BeginLoading(int scene) {

          sceneLoadIndex = scene;
          
          SceneManager.LoadScene(0);


     }



}
