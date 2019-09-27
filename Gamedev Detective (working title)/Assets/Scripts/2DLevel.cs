using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class Level2D {

     [Tooltip("For Ease of Development, not necessary")]
     public string Name;

     [Tooltip("Letter of cartridge to activate, (z) is for null")]
     public char Letter;

     [Tooltip("Build Index of 2D Scene. Make sure it is the right Scene")]
     public int Scene2DIndex;
     



}
