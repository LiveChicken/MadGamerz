using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
[CreateAssetMenu(fileName = "Cart", menuName = "ScriptableObjects/Cart", order = 1)]
public class Level2D : ScriptableObject{

     [Tooltip("For Ease of Development, not necessary")]
     public string Name;

    
     [Tooltip("Build Index of 2D Scene. Make sure it is the right Scene")]
     public int Scene2DIndex;

     [Tooltip("Art on the Cart")]
     public Texture2D CartArt;




}
