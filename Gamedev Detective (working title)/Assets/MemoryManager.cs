using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MemoryManager : MonoBehaviour {

    public Transform Player;

    public GameObject CameraScreen;

    public GameObject PCCam;

    public float DelayUntillTeleport= 3f;

    public Transform TeleportPoint;
    
   // public PC pc;

    public void BeginMemory(string memorySceneName) {

        if (GameManager.GM.TS == Mode.S2D) return;


        GameManager.GM.TS = Mode.S2D;
        
        //Loading 2D Scene
        if (SceneManager.sceneCount > 1) {

            SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1));

        }

        SceneManager.LoadScene(memorySceneName, LoadSceneMode.Additive);
      //  GameManager.GM.CartHasChanged = false;

        Debug.Log("Loaded Successfully");
        
        //Activate MemoryScreen

        CameraScreen.gameObject.SetActive(true);
        StartCoroutine(Teleport());

    }


    IEnumerator Teleport() {

        yield return new WaitForSeconds(DelayUntillTeleport);

        Player.position = TeleportPoint.position;
        Player.rotation = TeleportPoint.rotation;

        yield return null;
        
        PCCam.SetActive(true);
        CameraScreen.SetActive(false);

    }


    public void EndMemory() {

        PCCam.SetActive(false);

        GameManager.GM.TS = Mode.S3D;

    }

}
