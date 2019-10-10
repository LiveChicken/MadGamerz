using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class GameManager : MonoBehaviour {

     public  TransitionState TS;

     public static GameManager GM;

     public CinemachineBrain Brain;
     
     public char CurrentLevel2D = 'z';

     public bool CanMove3D;
     public bool CanMove2D;
     
     private void Awake() {
          GM = this;
     }


}
public enum TransitionState{

             S3D,
             Between,
             S2D

}