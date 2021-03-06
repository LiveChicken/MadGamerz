﻿using System.Collections;
using System.Collections.Generic;
using TFG_Common;
using UnityEngine;
using UnityEngine.Events;


public class EventOnCollision2D : MonoBehaviour
{
   
   
   public    LayerMask layerMask;

   public bool OneShot; 
   
   public UnityEvent OnCollisionEvent;

   private bool shot;

   void OnCollisionEnter2D(Collision2D other) {

      if (!shot) {

         if (Checks.CompareLayers(layerMask, other.gameObject)) {


            OnCollisionEvent?.Invoke();
            
            if (OneShot) {
               shot = true;
            }

         }


      }
   }





}
