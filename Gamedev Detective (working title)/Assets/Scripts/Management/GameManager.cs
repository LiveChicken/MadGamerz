using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour {

     public  Mode TS;

     public static GameManager GM;

     public CinemachineBrain Brain;
     
     //public char CurrentLevel2D = 'z';
     
     [Space]

     public bool CanMove;

     public bool CartHasChanged;
     
     
     private void Awake() {
          GM = this;
     }


}
public enum Mode{

             S3D,
             Between,
             S2D

}