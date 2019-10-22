using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour {

     public  Mode TS;

     public static GameManager GM;

     public CinemachineBrain Brain;


     public ButtonSpriteMap MasterBSM;
     //public char CurrentLevel2D = 'z';

     public Controls controls = null;
     
     [Space]

     public bool CanMove;

     public bool CartHasChanged;
     
     
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


}
public enum Mode{

             S3D,
             Between,
             S2D

}