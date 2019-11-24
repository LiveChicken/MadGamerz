using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

     public int MaxHearts = 3;

     public int PixelsPerHeart = 100;

     [HideInInspector]
     public int currentHealth;


     private void Start() {

          currentHealth = MaxHearts;

     }

     void setUI() {

          
          
     }

}
