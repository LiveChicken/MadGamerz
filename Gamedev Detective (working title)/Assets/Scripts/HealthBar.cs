using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour {

    // public int MaxHearts = 3;

   //  public int PixelsPerHeart = 100;


     public Health RefHealthBar;
     
     [HideInInspector]
     public int currentHealth;

     public Image Heart1, Heart2, Heart3;
     

     private void Start() {

         // currentHealth = MaxHearts;

     }

     private void Update() {
          setUI();
     }

     void setUI() {

          if (currentHealth != RefHealthBar.currentHealth) {

               currentHealth = RefHealthBar.currentHealth;

               switch (currentHealth) {

                    case 3:

                         Heart1.enabled = true;
                         Heart2.enabled = true;
                         Heart3.enabled = true;

                         break;

                    case 2:

                         Heart1.enabled = true;
                         Heart2.enabled = true;
                         Heart3.enabled = false;


                         break;

                    case 1:

                         Heart1.enabled = true;
                         Heart2.enabled = false;
                         Heart3.enabled = false;


                         break;


                    case 0:

                         Heart1.enabled = false;
                         Heart2.enabled = false;
                         Heart3.enabled = false;

                         break;




               }


          }
     }

}
