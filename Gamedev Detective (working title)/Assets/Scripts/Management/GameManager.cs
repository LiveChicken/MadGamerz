using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class GameManager : MonoBehaviour {

     public Mode TS;

     public static GameManager GM;

     public CinemachineBrain Brain;


     public ButtonSpriteMap MasterBSM;

     //public char CurrentLevel2D = 'z';

     public Controls controls = null;

     [Space] public bool CanMove;

     public bool CartHasChanged;

     public GameObject pauseMenu;
     private bool paused;

     [Space]
     public List<Key>Keychain = new List<Key>();


private void Awake() {
          GM = this;
          controls = new Controls();
          
     }

     private void OnEnable() {
          controls.Player.Enable();
     }

     private void OnDisable() {
          controls.Player.Disable();
     }


     private void Update() {

          if (!paused && controls.Player.Pause.triggered) {

               SetPause(true);
               
          }else if (paused && controls.UI.Cancel.triggered) {

               SetPause(false);
               
          }

     }

     public void SetPause(bool pause) {

          if (pause) {

               Time.timeScale = 0f;
               
               pauseMenu.SetActive(true);

              controls.UI.Enable();
               controls.Player.Disable();
               paused = true;

          } else {

               Time.timeScale = 1f;
               
               pauseMenu.SetActive(false);

              controls.UI.Disable();
               controls.Player.Enable();
               paused = false;


          }

     }


}
public enum Mode{

             S3D,
             Between,
             S2D

}

