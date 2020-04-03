using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MemoryManager : MonoBehaviour {

    public Transform Player;

    public GameObject CameraScreen;

    public GameObject PCCam;

    public float DelayUntillTeleport= 3f;

    public Transform TeleportPoint;

    private bool Teleporting;

    public delegate void BeginMemoryDelegate(string sceneName);
      
          public static BeginMemoryDelegate beginMemoryDelegate = delegate {
      
          };

          public delegate void EndMemoryDelegate();

          public static EndMemoryDelegate endMemoryDelegate = delegate {

          };
    
   // public PC pc;

  // void Start { }

  private void OnEnable() {

      beginMemoryDelegate += BeginMemory;
      endMemoryDelegate += EndMemory;
  }


  private void BeginMemory(string memorySceneName) {

        if (GameManager.GM.TS == Mode.S2D) return;


        GameManager.GM.TS = Mode.S2D;
        
        //Loading 2D Scene
        if (SceneManager.sceneCount > 1) {

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));

        }
        
        Debug.Log("made it this far");

        if (memorySceneName != null) SceneManager.LoadScene(memorySceneName, LoadSceneMode.Additive);

        //  GameManager.GM.CartHasChanged = false;
        if (SceneManager.sceneCount > 1) {
            Debug.Log("Loaded Successfully");
        } else {
            Debug.Log("Failed to Load scene");
            GameManager.GM.TS = Mode.S3D;
            return;
        }

        //Activate MemoryScreen

        CameraScreen.gameObject.SetActive(true);

        try {
            CameraScreen.GetComponent<Animator>().SetTrigger("TriggerIntro");
        } catch {

            Debug.Log("No animator attached to screen");
            
        }

        StartCoroutine(Teleport());

    }


    IEnumerator Teleport() {

        Teleporting = true;
        yield return new WaitForSeconds(DelayUntillTeleport);

        Player.position = TeleportPoint.position;
        Player.rotation = TeleportPoint.rotation;

        yield return null;
        
        PCCam.SetActive(true);
        CameraScreen.SetActive(false);
        Teleporting = false;

        Player.GetComponentInChildren<InspectableViewer>().ToggleInspection();

    }


    private void EndMemory() {

        Debug.Log("I am trying to end memory");
        
        if (!Teleporting) {

            PCCam.SetActive(false);

            GameManager.GM.TS = Mode.S3D;

        } else {
            
          Debug.Log("You have not finished teleporting yet");
          
        }
    }

}
