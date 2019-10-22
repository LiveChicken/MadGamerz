using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[System.Serializable]
[CreateAssetMenu(fileName = "ButtonSpriteMap", menuName = "ScriptableObjects/ButtonSpriteMap", order = 1)]
public class ButtonSpriteMap : ScriptableObject {

   [Header("Xbox")] public Sprite A;
   public                  Sprite B;
   public                  Sprite X;
   public                  Sprite Y;
   public                  Sprite Start;
   public                  Sprite Back;
   public                  Sprite Dup;
   public                  Sprite Ddown;
   public                  Sprite Dleft;
   public                  Sprite Dright;
   public                  Sprite Rtrigger;
   public                  Sprite Ltrigger;
   public                  Sprite Rbumper;
   public                  Sprite Lbumper;

   [Space] [Header("Keyboard")] public Sprite Background;

   [Space] [Header("Switch")] public string OneCanHope;

   public Sprite GetXboxSprite(string map) {

      switch (map) {

         case ("A"):

            return A;

      
         
         case ("B"):

            return B;

         
         
         case ("X"):

            return X;

            
         
         case ("Y"):

            return Y;

         case ("Start"):

            return Start;

         case ("Back"):

            return Back;

         case ("Dup"):

            return Dup;

         case ("Ddown"):

            return Ddown;

         case ("Dleft"):

            return Dleft;

         case ("Dright"):

            return Dright;

         case ("Rtrigger"):

            return Rtrigger;

         case ("Ltrigger"):

            return Ltrigger;

         case ("Rbumper"):

            return Rbumper;

         case ("Lbumper"):

            return Lbumper;
         
         default:

            return Background;
            
         
      }



   }


}
