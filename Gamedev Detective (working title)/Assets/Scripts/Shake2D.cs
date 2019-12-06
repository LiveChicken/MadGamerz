using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Shake2D : MonoBehaviour {

    //public CameraShakeInstance CSI;

     public float Magnitude, Roughness, FadeIn, FadeOut;
     
     public void Shake() {

          CameraShaker.Instance.ShakeOnce(Magnitude, Roughness, FadeIn, FadeOut);
     }

}
